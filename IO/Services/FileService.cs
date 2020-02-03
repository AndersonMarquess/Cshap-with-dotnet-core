using System;
using System.IO;

namespace IO.Services {

	public class FileService {

		// FileReader => Binário (No block Try, sempre fechar)
		// StreamReader => Caracteres (No block Try, sempre fechar)
		// Como alternativa, é possível usar o File.OpenText()
		public static void ReadWithFileStream(string sourcePath) {
			using (var streamReader = new StreamReader(new FileStream(sourcePath, FileMode.Open))) {
				var firstLine = streamReader.ReadLine();
				Console.WriteLine(firstLine);
			}
		}

		public static void AppendtWithStreamWriter(string sourcePath, string targetPath) {
			using (var streamWriter = new StreamWriter(new FileStream(sourcePath, FileMode.Append))) {
				streamWriter.WriteLine("\nNew line");
			}
		}

		public static void ReadWithFile(string sourcePath) {
			try {
				Console.WriteLine($"Trying to read all content from {sourcePath}");
				// File é um pouco mais lento, pois realiza validações de segurança a cada operação.
				string[] lines = File.ReadAllLines(sourcePath);
				Array.ForEach(lines, Console.WriteLine);
				Console.WriteLine("Read with success");
			} catch (Exception e) {
				Console.WriteLine("Error: " + e.Message);
			}
		}

		public static void CopyFileWithFileInfo(string sourcePath, string targetPath) {
			try {
				Console.WriteLine($"Trying to copy content from {sourcePath} to {targetPath}");
				// FileInfo é mais rápido que o File
				var fileInfo = new FileInfo(sourcePath);
				fileInfo.CopyTo(targetPath);
				Console.WriteLine("Copied with success");
			} catch (Exception e) {
				Console.WriteLine("Error: " + e.Message);
			}
		}
	}
}
