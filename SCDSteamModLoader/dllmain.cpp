// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include <memory>
#include <thread>
#include <algorithm>
#include "IniFile.hpp"
#include "FileMap.hpp"
#include "FileSystem.h"
#include "MemAccess.h"
#include <fstream>
#include "CodeParser.hpp"

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
FunctionPointer(char, OpenDataFile, (const char *a1, char *a2), (0x15C70 + baseAddress));
FunctionPointer(char, OpenDataFile2, (const char *a1), (0x175F0 + baseAddress));
char OpenDataFile_r(const char *a1, char *a2)
{
	if (fileMap.getModIndex(a1) != 0)
	{
		UseRSDKFile = 0;
		a1 = fileMap.replaceFile(a1);
	}
	else
	{
		UseRSDKFile = packExists;
		if (string(a1).find("\\") != -1)
			UseRSDKFile = 0;
	}
	return OpenDataFile(a1, a2);
}

char OpenDataFile2_r(const char *a1)
{
	if (fileMap.getModIndex(a1) != 0)
	{
		UseRSDKFile = 0;
		a1 = fileMap.replaceFile(a1);
	}
	else
	{
		UseRSDKFile = packExists;
		if (string(a1).find("\\") != -1)
			UseRSDKFile = 0;
	}
	return OpenDataFile2(a1);
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
		const string modSysDirA = mod_dirA + "\\data";
		if (DirectoryExists(modSysDirA))
			fileMap.scanFolder(modSysDirA, i);
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
	WriteJump((void*)(0x105A + baseAddress), OpenDataFile2_r);
	WriteCall((void*)(0x3F30 + baseAddress), ProcessCodes);
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

