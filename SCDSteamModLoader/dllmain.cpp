// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include <memory>
#include <thread>
#include <algorithm>
#include "IniFile.hpp"
#include "FileMap.hpp"
#include "FileSystem.h"
#include <MemAccess.h>
#include "Trampoline.h"
#include <fstream>
#include "CodeParser.hpp"
#include "Direct3DHook.h"

using std::ifstream;
using std::string;
using std::wstring;
using std::unique_ptr;
using std::vector;
using std::unordered_map;

FileMap fileMap;
char packExists;

intptr_t baseAddress = (intptr_t)GetModuleHandle(nullptr);
DataPointer(char, UseRSDKFile, (0x7E8D5C + baseAddress));
FunctionPointer(char, OpenDataFile, (const char *filename, void *fileInfo), (0x15C70 + baseAddress));
FunctionPointer(char, SetFileInfo, (const char *filename), (0x175F0 + baseAddress));


DataPointer(void*, ImageARC, (0x2B7988 + baseAddress));
DataPointer(void*, SfxARC, (0x2B7834 + baseAddress));
DataPointer(void*, FontARC, (0x2B7838 + baseAddress));
FunctionPointer(void*, LoadARCImage, (const char* filename), (0xBE90 + baseAddress));
FunctionPointer(void*, LoadARCSFX, (const char* filename), (0x6420 + baseAddress));

static int loc_LoadARCFont = baseAddress + 0xBE90;
static __declspec(naked) void* LoadARCFont(void* a1, double a2, const char* filename)
{
	__asm
	{
		mov ecx, [ESP + 4]
		fld [ESP + 8]
		push[ESP + 16]
		call loc_LoadARCFont
		add ESP, 4
		ret
	}
}


inline bool ends_with(std::string const& value, std::string const& ending)
{
	if (ending.size() > value.size()) return false;
	return std::equal(ending.rbegin(), ending.rend(), value.rbegin());
}

char OpenDataFile_r(const char *filename, void * fileInfo)
{
	if (fileMap.getModIndex(filename) != 0)
	{
		UseRSDKFile = 0;
		filename = fileMap.replaceFile(filename);
	}
	else if (string(filename).rfind("Data/Scripts/", 0) == 0 && ends_with(string(filename), "txt")) {
		//is a script, since those dont exist normally, load them from "scripts/"
		UseRSDKFile = 0;
		string fStr = string(filename);
		fStr.erase(fStr.begin(), fStr.begin() + 5); //remove "Data/"
		return OpenDataFile(fStr.c_str(), fileInfo);
	}
	else
	{
		UseRSDKFile = packExists;
		if (string(filename).find("\\") != -1)
			UseRSDKFile = 0;
	}
	return OpenDataFile(filename, fileInfo);
}

char SetFileInfo_r(const char *filename)
{
	if (fileMap.getModIndex(filename) != 0)
	{
		UseRSDKFile = 0;
		filename = fileMap.replaceFile(filename);
	}
	else if (string(filename).rfind("Data/Scripts/") == 0 && ends_with(string(filename), "txt")) {
		//is a script, since those dont exist normally, load them from "scripts/"
		UseRSDKFile = 0;
		string fStr = string(filename);
		fStr.erase(fStr.begin(), fStr.begin() + 5); //remove "Data/"
		return SetFileInfo(fStr.c_str());
	}
	else
	{
		UseRSDKFile = packExists;
		if (string(filename).find("\\") != -1)
			UseRSDKFile = 0;
	}
	return SetFileInfo(filename);
}

void* LoadARCImage_r(const char* filename)
{
	if (fileMap.getModIndex(filename) != 0)
	{
		filename = fileMap.replaceFile(filename);
		void* ptr = ImageARC;
		ImageARC = NULL;
		void* result = LoadARCImage(filename);
		ImageARC = ptr;
		return result;
	}

	return LoadARCImage(filename);
}

void* LoadARCSfx_r(const char* filename)
{
	if (fileMap.getModIndex(filename) != 0)
	{
		filename = fileMap.replaceFile(filename);
		void* ptr = SfxARC;
		SfxARC = NULL;
		void* result = LoadARCSFX(filename);
		SfxARC = ptr;
		return result;
	}

	return LoadARCSFX(filename);
}

void* LoadARCFont_r(void* a1, double a2, const char* filename)
{
	if (fileMap.getModIndex(filename) != 0)
	{
		filename = fileMap.replaceFile(filename);
		void* ptr = FontARC;
		FontARC = NULL;
		void* result = LoadARCFont(a1, a2, filename);
		FontARC = ptr;
		return result;
	}

	return LoadARCFont(a1, a2, filename);
}

unordered_map<string, unsigned int> musicloops;
Trampoline *musictramp;
int __cdecl SetMusicTrack(const char *name, int slot, bool loop, unsigned int loopstart)
{
	string namestr = name;
	std::transform(namestr.begin(), namestr.end(), namestr.begin(), tolower);
	auto iter = musicloops.find(namestr);
	if (iter != musicloops.cend())
		loop = (loopstart = iter->second) != 0;
	return ((decltype(SetMusicTrack)*)musictramp->Target())(name, slot, loop, loopstart);
}

// Code Parser.
static CodeParser codeParser;

FunctionPointer(int, MainGameLoop, (), (0x187F + baseAddress));
static int __cdecl ProcessCodes()
{
	codeParser.processCodeList();
	return MainGameLoop();
}

FunctionPointer(char, CheckRSDKFile, (const char *a1), (0x15BA0 + baseAddress));
char InitMods(const char *a1)
{
	HookDirect3D();
	FILE *f_ini = _wfopen(L"mods\\SCDSteamModLoader.ini", L"r");
	if (!f_ini)
	{
		MessageBox(nullptr, L"mods\\SCDSteamModLoader.ini could not be read!", L"SCD Steam Mod Loader", MB_ICONWARNING);
		return CheckRSDKFile(a1);
	}
	unique_ptr<IniFile> ini(new IniFile(f_ini));
	fclose(f_ini);

	// Get exe's path and filename.
	wchar_t pathbuf[MAX_PATH];
	GetModuleFileName(nullptr, pathbuf, MAX_PATH);
	wstring exepath(pathbuf);
	wstring exefilename;
	string::size_type slash_pos = exepath.find_last_of(L"/\\");
	if (slash_pos != string::npos)
	{
		exefilename = exepath.substr(slash_pos + 1);
		if (slash_pos > 0)
			exepath = exepath.substr(0, slash_pos);
	}

	// Convert the EXE filename to lowercase.
	transform(exefilename.begin(), exefilename.end(), exefilename.begin(), ::towlower);

	// Process the main Mod Loader settings.
	const IniGroup *settings = ini->getGroup("");

	for (unsigned int i = 1; i <= 999; i++)
	{
		char key[8];
		snprintf(key, sizeof(key), "Mod%u", i);
		if (!settings->hasKey(key))
			break;

		const string mod_dirA = "mods\\" + settings->getString(key);
		const wstring mod_dir = L"mods\\" + settings->getWString(key);
		const wstring mod_inifile = mod_dir + L"\\mod.ini";
		FILE *f_mod_ini = _wfopen(mod_inifile.c_str(), L"r");
		if (!f_mod_ini)
			continue;
		unique_ptr<IniFile> ini_mod(new IniFile(f_mod_ini));
		fclose(f_mod_ini);

		const IniGroup *const modinfo = ini_mod->getGroup("");
		const string mod_nameA = modinfo->getString("Name");

		// Check for Data replacements.
		string modSysDirA = mod_dirA + "\\data";
		if (DirectoryExists(modSysDirA))
			fileMap.scanFolder(modSysDirA, i, 0);

		//PC port rubbish that should be supported
		modSysDirA = mod_dirA + "\\images";
		if (DirectoryExists(modSysDirA))
			fileMap.scanFolder(modSysDirA, i, 1);

		modSysDirA = mod_dirA + "\\help";
		if (DirectoryExists(modSysDirA))
			fileMap.scanFolder(modSysDirA, i, 2);

		modSysDirA = mod_dirA + "\\sounds";
		if (DirectoryExists(modSysDirA))
			fileMap.scanFolder(modSysDirA, i, 3);

		modSysDirA = mod_dirA + "\\fonts";
		if (DirectoryExists(modSysDirA))
			fileMap.scanFolder(modSysDirA, i, 4);

		modSysDirA = mod_dirA + "\\videos";
		if (DirectoryExists(modSysDirA))
			fileMap.scanFolder(modSysDirA, i, 5);

		if (ini_mod->hasGroup("MusicLoops"))
		{
			const IniGroup *const gr = ini_mod->getGroup("MusicLoops");
			for (auto iter = gr->cbegin(); iter != gr->cend(); ++iter)
			{
				string name = iter->first;
				std::transform(name.begin(), name.end(), name.begin(), tolower);
				name.append(".ogg");
				musicloops[name] = std::stoi(iter->second);
			}
		}
		if (ini_mod->getBool("", "TxtScripts", false))
		{
			// Prevents the game from using bytecode in favour of compiling the users code
			WriteData((BYTE*)(0x15C52 + baseAddress), (BYTE)FALSE);
		}

	}

	// Check for patches.
	ifstream patches_str("mods\\Patches.dat", ifstream::binary);
	if (patches_str.is_open())
	{
		CodeParser patchParser;
		patchParser.setOffset(baseAddress);
		static const char codemagic[6] = { 'c', 'o', 'd', 'e', 'v', '5' };
		char buf[sizeof(codemagic)];
		patches_str.read(buf, sizeof(buf));
		if (!memcmp(buf, codemagic, sizeof(codemagic)))
		{
			int codecount_header;
			patches_str.read((char*)&codecount_header, sizeof(codecount_header));
			patches_str.seekg(0);
			int codecount = patchParser.readCodes(patches_str);
			if (codecount >= 0)
			{
				patchParser.processCodeList();
			}
			else
			{
				switch (codecount)
				{
				case -EINVAL:
					break;
				default:
					break;
				}
			}
		}
		patches_str.close();
	}

	// Check for codes.
	ifstream codes_str("mods\\Codes.dat", ifstream::binary);
	if (codes_str.is_open())
	{
		codeParser.setOffset(baseAddress);
		static const char codemagic[6] = { 'c', 'o', 'd', 'e', 'v', '5' };
		char buf[sizeof(codemagic)];
		codes_str.read(buf, sizeof(buf));
		if (!memcmp(buf, codemagic, sizeof(codemagic)))
		{
			int codecount_header;
			codes_str.read((char*)&codecount_header, sizeof(codecount_header));
			codes_str.seekg(0);
			int codecount = codeParser.readCodes(codes_str);
			if (codecount >= 0)
			{
				codeParser.processCodeList();
			}
			else
			{
				switch (codecount)
				{
				case -EINVAL:
					break;
				default:
					break;
				}
			}
		}
		codes_str.close();
	}

	packExists = CheckRSDKFile(a1);
	WriteJump((void*)(0x111D + baseAddress), OpenDataFile_r);
	WriteJump((void*)(0x105A + baseAddress), SetFileInfo_r);
	WriteJump((void*)(0x113B + baseAddress), LoadARCImage_r);
	WriteJump((void*)(0x1672 + baseAddress), LoadARCSfx_r);
	//WriteJump((void*)(0x1D2A + baseAddress), LoadARCFont_r); //Unimplimented due to issues calling it (__userpurge)
	WriteCall((void*)(0x3F30 + baseAddress), ProcessCodes);
	musictramp = new Trampoline((baseAddress + 0x14070), (baseAddress + 0x14078), SetMusicTrack);
	return packExists;
}

BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		WriteJump((void*)(0x10FA + baseAddress), InitMods);
		break;
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

