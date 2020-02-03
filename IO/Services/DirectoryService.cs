using System;
using System.IO;

namespace IO.Services {

	public class DirectoryService {

		public static void PrintAllSubdirectoriesIn(string path) {
			try {
				string pattern = "*.*";
				var folders = Directory.EnumerateDirectories(path, pattern, SearchOption.AllDirectories);
				foreach (var folder in folders) {
					Console.WriteLine(folder);
				}
			} catch (Exception e) {
				System.Console.WriteLine("Error: " + e.Message);
			}
		}

		public static void PrintAllFilesIn(string path) {
			try {
				string pattern = "*.*";
				var folders = Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories);
				foreach (var folder in folders) {
					Console.WriteLine(folder);
				}
			} catch (Exception e) {
				System.Console.WriteLine("Error: " + e.Message);
			}
		}

		public static void CreateDirectory(string path, string directoryName) {
			try {
				Directory.CreateDirectory(path + Path.DirectorySeparatorChar + directoryName);
			} catch (Exception e) {
				System.Console.WriteLine("Error: " + e.Message);
			}
		}
	}
}
