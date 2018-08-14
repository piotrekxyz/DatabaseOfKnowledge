using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DatabaseOfKnowledge.Classes.Tests
{
	[DataContract, Serializable]
	public class PersonXML
	{
		public PersonXML() { }
		public PersonXML(string name, int number)
		{
			Name = name;
			age = number;
			tabOfNumbers = new int[number];

			for (int i = 0; i < number; i++)
			{
				//digits.Add(i);
				numbers.Add(i * 10);
				tabOfNumbers[i] = i + 2;
				arrayList.Add(i + 3);
				//linkedList.AddLast(i + 4);
				//sortedListSI.Add(string.Format("{0} squared = ", i), i * i);
				//dictionary.Add(i.ToString(), i);
				//sortedDictionary.Add(i.ToString(), i);
				//queueI.Enqueue(i);
			}
		}

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		internal int age;

		//[DataMember]
		//public IList<int> digits = new List<int>();

		[DataMember]
		public List<int> numbers = new List<int>();

		[DataMember]
		public int[] tabOfNumbers;

		//[DataMember]
		//public int[,] twoDimensionalArrayOfNumbers = new int[5, 2];

		//[DataMember]
		//public int[][] otherDimensionalArrayOfNumbers = new int[3][];

		//[DataMember]
		//public Array array;

		[DataMember]
		public ArrayList arrayList = new ArrayList();

		//[DataMember]
		//public LinkedList<int> linkedList = new LinkedList<int>();

		//[DataMember]
		//public LinkedListNode<int> linkedListNode = new LinkedListNode<int>(5);

		//[DataMember]
		//public SortedList sortedList;

		//[DataMember]
		//public SortedList<string, int> sortedListSI = new SortedList<string, int>();

		//[DataMember]
		//public Dictionary<string, int> dictionary = new Dictionary<string, int>();

		//[DataMember]
		//public SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();

		//[DataMember]
		//public Queue queue = new Queue();

		//[DataMember]
		//public Queue<int> queueI = new Queue<int>();

		//[DataMember]
		//public Stack stack = new Stack();

		//[DataMember]
		//public Stack<int> stackI = new Stack<int>();

		[DataMember]
		public HashSet<int> hashSet = new HashSet<int>();

		//[DataMember]
		//public Hashtable hashTable = new Hashtable();

		[DataMember]
		public KeyValuePair<string, int> keyValuePair = new KeyValuePair<string, int>();

		//[DataMember]
		//public Tuple<int> tuple;

		//[DataMember]
		//public Tuple<int, int, int> tuple3;
	}
}
