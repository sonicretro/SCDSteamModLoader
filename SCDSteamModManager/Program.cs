using Microsoft.Win32;
using ModManagerCommon;
using ModManagerCommon.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SCDSteamModManager
{
	static class Program
	{
		private const string pipeName = "scdsteam-mod-manager";
		private const string protocol = "scdsteammm:";
		private static readonly Mutex mutex = new Mutex(true, pipeName);
		public static UriQueue UriQueue;

		static async Task CheckGetScrUpdates()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			try
			{
				Octokit.GitHubClient client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("SonicCDScripts"));
				var releases = await client.Repository.Commit.GetAll("Rubberduckycooly", "Sonic-CD-2011-Script-Decompilation");
				var latest = releases[0];

				string ver = "none";
				if (File.Exists("cdscrver.txt"))
					ver = File.ReadAllText("cdscrver.txt");

				if ((ver != latest.Sha || !Directory.Exists("Scripts/")) && ver != "dev")
				{
					//Clone & download scripts
					if (Directory.Exists("Scripts/"))
						Directory.Delete("Scripts/", true);

					using (var webclient = new WebClient())
					{
						webclient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
						webclient.DownloadFile(
							"https://github.com/Rubberduckycooly/Sonic-CD-2011-Script-Decompilation/archive/refs/heads/main.zip",
							"cdscr.zip");

						Process process = Process.Start(
							new ProcessStartInfo("7z.exe", $"x {"cdscr.zip"}")
							{
								UseShellExecute = false,
								CreateNoWindow = true
							});

						if (process != null)
						{
							process.WaitForExit();
						}
						else
						{
							if (File.Exists("cdscr.zip"))
								File.Delete("cdscr.zip");
							throw new NullReferenceException("Failed to create 7z process");
						}

						if (File.Exists("cdscr.zip"))
							File.Delete("cdscr.zip");

						File.WriteAllText("cdscrver.txt", latest.Sha);
					}
				}
			}
			catch (Exception ex)
			{
				if (File.Exists("cdscr.zip"))
					File.Delete("cdscr.zip");
				throw new Exception($"Error Updating Scripts folder! error msg:{ex.Message}");
			}
		}

		static async Task MainAsync()
		{
			await CheckGetScrUpdates();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length > 0 && args[0] == "urlhandler")
			{
				using (var hkcr = Registry.ClassesRoot)
				using (var key = hkcr.CreateSubKey("scdsteammm"))
				{
					key.SetValue(null, "URL:SCD Steam Mod Manager Protocol");
					key.SetValue("URL Protocol", string.Empty);
					using (var k2 = key.CreateSubKey("DefaultIcon"))
						k2.SetValue(null, Application.ExecutablePath + ",1");
					using (var k3 = key.CreateSubKey("shell"))
					using (var k4 = k3.CreateSubKey("open"))
					using (var k5 = k4.CreateSubKey("command"))
						k5.SetValue(null, $"\"{Application.ExecutablePath}\" \"%1\"");
				}
				return;
			}

			bool alreadyRunning;
			try { alreadyRunning = !mutex.WaitOne(0, true); }
			catch (AbandonedMutexException) { alreadyRunning = false; }

			if (args.Length > 1 && args[0] == "doupdate")
			{
				if (alreadyRunning)
					try { mutex.WaitOne(); }
					catch (AbandonedMutexException) { }
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new LoaderManifestDialog(args[1]));
				return;
			}

			if (args.Length > 1 && args[0] == "cleanupdate")
			{
				if (alreadyRunning)
					try { mutex.WaitOne(); }
					catch (AbandonedMutexException) { }
				alreadyRunning = false;
				Thread.Sleep(1000);
				try
				{
					File.Delete(args[1] + ".7z");
					Directory.Delete(args[1], true);
				}
				catch { }
			}

			if (!alreadyRunning)
			{
				UriQueue = new UriQueue(pipeName);
			}

			List<string> uris = args
				.Where(x => x.Length > protocol.Length && x.StartsWith(protocol, StringComparison.Ordinal))
				.ToList();

			if (uris.Count > 0)
			{
				using (var pipe = new NamedPipeClientStream(".", pipeName, PipeDirection.Out))
				{
					pipe.Connect();

					var writer = new StreamWriter(pipe);
					foreach (string s in uris)
					{
						writer.WriteLine(s);
					}
					writer.Flush();
				}
			}

			if (alreadyRunning)
			{
				return;
			}

			//TODO: inform the user that its downloading scripts (probably)
			MainAsync().GetAwaiter().GetResult();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
			UriQueue.Close();
		}
	}
}
