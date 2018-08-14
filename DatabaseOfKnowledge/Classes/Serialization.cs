using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace DatabaseOfKnowledge.Classes
{
	static class Serialization
	{
		static public bool SerializeBinary(object _object, string fileName)
		{
			try
			{
				BinaryFormatter biForm = new BinaryFormatter();
				using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
					biForm.Serialize(fs, _object);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
				return false;
			}
			return true;
		}

		static public bool SerializeBinaryT<T>(T _object, string fileName)
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

		static public object DeserializeBinary(string fileName)
		{
			Object _object = null;
			try
			{
				BinaryFormatter binForm = new BinaryFormatter();
				using (FileStream fs = new FileStream(fileName, FileMode.Open))
				{
					_object = binForm.Deserialize(fs);   // ??
					return _object;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine);
				return _object;
			}
		}

		static public bool SerializeJSON<T>(T _object, string fileName)
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

		static public bool SerializeXML<T>(T _object, string fileName)
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
	}
}