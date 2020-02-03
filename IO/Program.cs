using System;
using System.IO;
using IO.Services;

namespace IO {

	class Program {

		static void Main(string[] args) {
			string root = Directory.GetCurrentDirectory();
			string sourcePath = root + @"\file1.txt";
			string targetPath = root + @"\file2.txt";

			FileTests(sourcePath, targetPath);
			DirectoryTests(root);
		}

		private static void DirectoryTests(string path) {
			DirectoryService.PrintAllSubdirectoriesIn(path);
			DirectoryService.PrintAllFilesIn(path);
			DirectoryService.CreateDirectory(path, "new");
		}

		private static void FileTests(string sourcePath, string targetPath) {
			FileService.CopyFileWithFileInfo(sourcePath, targetPath);
			FileService.ReadWithFile(sourcePath);
			FileService.ReadWithFileStream(sourcePath);
			FileService.AppendtWithStreamWriter(sourcePath, targetPath);
		}
	}
}
