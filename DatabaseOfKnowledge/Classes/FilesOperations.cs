using System;
using System.IO;

namespace DatabaseOfKnowledge.Classes
{
	static class FilesOperations
	{

		public static bool CreateFile(string fileName)
		{
			try
			{
				if (!File.Exists(fileName))
				{
					File.CreateText(fileName);
					return true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return false;
			}
			return false;
		}

		public static string ReadFromFile_ToEnd(string fileName)
		{
			string s = "";
			try
			{
				using (StreamReader sr = new StreamReader(fileName))
					s = sr.ReadToEnd();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return null;
			}
			return s;
		}

		public static string ReadFromFile_AllText(string fileName)
		{
			string s = "";
			try
			{
				s = File.ReadAllText(fileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return null;
			}
			return s;
		}

		public static string[] ReadFromFile_AllLines(string fileName)
		{
			string[] tab;
			try
			{
				tab = File.ReadAllLines(fileName);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return null;
			}
			return tab;
		}

		public static string ReadFromFile_LineAfterLine(string fileName)
		{
			string line, result = "";
			try
			{
				StreamReader sr = new StreamReader(fileName);
				while ((line = sr.ReadLine()) != null)
					result += line;
				sr.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return null;
			}
			return result;
		}

		public static bool SaveToFile_AppendT<T>(T data, string fileName)
		{
			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
				using (StreamWriter sw = new StreamWriter(fs))
					sw.Write(data.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return false;
			}
			return true;
		}

		public static bool SaveToFile_CreateT<T>(T data, string fileName)
		{
			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
				using (StreamWriter sw = new StreamWriter(fs))
					sw.Write(data.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return false;
			}
			return true;
		}

		public static bool SaveToFile_CreateNewT<T>(T data, string fileName)
		{
			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write))
				using (StreamWriter sw = new StreamWriter(fs))
					sw.Write(data.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return false;
			}
			return true;
		}

		public static bool SaveToFile_TruncateT<T>(T data, string fileName)
		{
			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Truncate, FileAccess.Write))
				using (StreamWriter sw = new StreamWriter(fs))
					sw.Write(data.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine);
				return false;
			}
			return true;
		}
	}
}
