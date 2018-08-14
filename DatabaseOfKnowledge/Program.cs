using DatabaseOfKnowledge.Classes;
using DatabaseOfKnowledge.Classes.Tests;

namespace DatabaseOfKnowledge
{
	class Program
	{
		static public string fileNameXML = "file.xml";
		static public string fileNameJSON = "file.json";
		static public string fileNameBinJSON = "fileJSON.dat";
		static public string fileNameBinXML = "fileXML.dat";
		static public string fileNameBinXML_new = "fileXMLnew.dat";
		static public string fileNameSave = "file2.txt";
		static public string test = "test.txt";

		static void Main(string[] args)
		{
			Testing();
		}

		static void Testing()
		{
			PersonXML p1XML = new PersonXML("Somebody", 15);
			PersonJSON p1JSON = new PersonJSON("Somebody2", 17);
			//PersonXML p2XML = null;
			//PersonJSON p2JSON = null;

			Serialization.SerializeBinary(p1JSON, fileNameBinJSON);
			Serialization.SerializeBinary(p1XML, fileNameBinXML);
			Serialization.SerializeBinaryT(p1JSON, fileNameBinJSON);
			Serialization.SerializeBinaryT(p1XML, fileNameBinXML);
			SerializationGeneric<PersonJSON>.SerializeBinary(p1JSON, fileNameBinJSON);
			SerializationGeneric<PersonXML>.SerializeBinary(p1XML, fileNameBinXML);
			var x1 = Serialization.DeserializeBinary(fileNameBinXML);
			var j1 = Serialization.DeserializeBinary(fileNameBinJSON);
			var x2 = SerializationGeneric<PersonXML>.DeserializeBinary(fileNameBinXML);
			var j2 = SerializationGeneric<PersonJSON>.DeserializeBinary(fileNameBinJSON);
			Serialization.SerializeJSON(p1JSON, fileNameJSON);
			Serialization.SerializeXML(p1XML, fileNameXML);
			var x3 = SerializationGeneric<PersonXML>.DeserializeXML(fileNameXML);
			var j3 = SerializationGeneric<PersonJSON>.DeserializeJSON(fileNameJSON);
		}
	}
}
