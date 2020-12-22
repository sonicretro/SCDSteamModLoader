/**
 * SADX Mod Loader
 * File remapper.
 */

#ifndef FILEMAP_HPP
#define FILEMAP_HPP

#include <string>
#include <unordered_map>

class FileMap
{
	public:
		FileMap();
		~FileMap();

	private:
		// Disable the copy and assign constructors.
		FileMap(const FileMap &);
		FileMap &operator=(const FileMap &);

	public:
		/**
		 * Normalize a filename for the file replacement map.
		 * @param filename Filename.
		 * @return Normalized filename.
		 */
		static std::string normalizePath(const std::string &filename);

		/**
		 * Normalize a filename for the file replacement map.
		 * @param filename Filename.
		 * @return Normalized filename.
		 */
		static std::string normalizePath(const char *filename);

		/**
		 * Ignore a file.
		 * @param ignoreFile File to ignore.
		 * @param modIdx Index of the current mod.
		 */
		void addIgnoreFile(const std::string &ignoreFile, int modIdx);

		/**
		 * Add a file replacement.
		 * @param origFile Original filename.
		 * @param modFile Mod filename.
		 */
		void addReplaceFile(const std::string &origFile, const std::string &modFile);

		/**
		 * Recursively scan a directory and add all files to the replacement map.
		 * Destination is always relative to system/.
		 * @param srcPath Path to scan.
		 * @param modIdx Index of the current mod.
		 * @param folder id to scan.
		 */
		void scanFolder(const std::string &srcPath, int modIdx, int folder);

	protected:
		/**
		 * Recursively scan a directory and add all files to the replacement map.
		 * Destination is always relative to system/.
		 * (Internal recursive function)
		 * @param srcPath Path to scan.
		 * @param srcLen Length of original srcPath. (used for recursion)
		 * @param modIdx Index of the current mod.
		 * @param folder id to scan.
		 */
		void scanFolder_int(const std::string &srcPath, int srcLen, int modIdx, int folder);

		/**
		 * Set a replacement file in the map.
		 * Filenames must already be normalized!
		 * (Internal function; handles memory allocation)
		 * @param origFile Original file.
		 * @param modFile Mod filename.
		 * @param modIdx Index of the current mod.
		 */
		void setReplaceFile(const std::string &origFile, const std::string &modFile, int modIdx);

	public:
		/**
		 * Get a filename from the file replacement map.
		 * @param lpFileName Filename.
		 * @return Replaced filename, or original filename if not replaced by a mod.
		 */
		const char *replaceFile(const char *lpFileName) const;

		/**
		* Get the index of the mod that replaced a given file.
		* @param lpFileName Filename.
		* @return Index of the mod that replaced a file, or 0 if no mod replaced it.
		*/
		int getModIndex(const char *lpFileName) const;

		/**
		 * Clear the file replacement map.
		 */
		void clear(void);

	protected:

		struct Entry
		{
			std::string fileName;
			int modIndex;
		};

		/**
		 * File replacement map.
		 * - Key: Original filename.
		 * - Value: New filename.
		 */
		std::unordered_map<std::string, Entry> m_fileMap;
};

#endif /* FILEMAP_HPP */
