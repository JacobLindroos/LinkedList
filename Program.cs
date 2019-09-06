
using System;

namespace LinkedListTutorial
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkedList list = new LinkedList();

			list.AddLast("Hello");
			list.AddLast("Test1");
			list.AddLast("Test2");
			list.AddLast("Test3");

			object test2 = list[2];

			object remove = list.Remove(0);

			list.ClearList();


			Console.ReadKey();
		}
	}
}
