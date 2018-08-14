using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace DatabaseOfKnowledge.Classes
{
	static class SerializationGeneric<T>
	{
		static public bool SerializeBinary(T _object, string fileName)
		{
			try
			{
				BinaryFormatter binForm = new BinaryFormatter();
				using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
					binForm.Serialize(fs, _object);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
				return false;
			}
			return true;
		}

		static public T DeserializeBinary(string fileName)
		{
			T _object = default(T);
			try
			{
				BinaryFormatter binForm = new BinaryFormatter();
				using (FileStream fs = new FileStream(fileName, FileMode.Open))
				{
					_object = (T)binForm.Deserialize(fs);
					return _object;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
				return _object;
			}
		}

		static public bool SerializeJSON(T _object, string fileName)
		{
			try
			{
				DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
				using (FileStream fs = new FileStream(fileName, FileMode.Create))
					jsonSerializer.WriteObject(fs, _object);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
				return false;
			}
			return true;
		}

		static public T DeserializeJSON(string fileName)
		{
			T _object = default(T);
			try
			{
				string data = "";
				if (File.Exists(fileName))
					data = File.ReadAllText(fileName);

				DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
				MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(data));
				_object = (T)jsonSerializer.ReadObject(ms);
				return _object;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
				return _object;
			}
		}

		static public bool SerializeXML(T _object, string fileName)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				using (Stream stream = File.Create(fileName))
					xmlSerializer.Serialize(stream, _object);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
				return false;
			}
			return true;
		}

		static public T DeserializeXML(string fileName)
		{
			T _object = default(T);
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				using (Stream stream = File.OpenRead(fileName))
					_object = (T)xmlSerializer.Deserialize(stream);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
				return _object;
			}
			return _object;
		}

		//static public T DeserializeXML_T_new<T>(string fileName) where T : new()
		//{
		//	T _object = new T();
		//	try
		//	{
		//		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		//		using (Stream stream = File.OpenRead(fileName))
		//			_object = (T)xmlSerializer.Deserialize(stream);
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex);
		//		return default(T);
		//	}
		//	return _object;
		//}
	}
}