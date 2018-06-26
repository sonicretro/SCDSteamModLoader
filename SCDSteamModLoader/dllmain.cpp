// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include <memory>
#include <thread>
#include <algorithm>
#include "IniFile.hpp"
#include "FileMap.hpp"
#include "FileSystem.h"
#include "MemAccess.h"

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
	packExists = CheckRSDKFile(a1);
	WriteJump((void*)(0x111D + baseAddress), OpenDataFile_r);
	WriteJump((void*)(0x105A + baseAddress), OpenDataFile2_r);
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

