using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListTutorial
{
	public class LinkedList
	{
		/* a-> b-> c-> d
		 * 
		 * Construtor
		 * [x] Linkedlist() - initialze private fields
		 * 
		 * Private fields:
		 * [x] Node head - Is a reference to the first node in the list
		 * [x] int size - current size of the list
		 * 
		 * Public properties:
		 * [x] Empty - if the list is empty
		 * [x] Count - how many iteams in the list
		 * [x] index - index the data as an array
		 * 
		 * Methods:
		 * [x] Add(int index, object o) - Add an iteam at specific index
		 * [x] AddLast(object o) - Add an iteam in the END of the list
		 * [x] Remove(int index) - remove iteam in the list at specific index
		 * [x] ClearList() - clear the list
		 * [x] IndexOf(object o) - gets the index of iteam in list, if not return -1
		 * [x] Contains(object o) - if the list contains the object 
		 * [x] Get(int index) - gets iteam in specific index
		 */


		//reference to the first node in the list
		private Node head;
		//keeps count of all the nodes in the list
		private int count;

		/// <summary>
		/// Creates a new linked list, constructor to class linkedList
		/// </summary>
		public LinkedList() 
		{
			this.head = null;
			this.count = 0;
		}

		/// <summary>
		/// Gets a value indicating if the list is empty
		/// </summary>
		public bool Empty
		{
			get { return this.count == 0; }
		}

		/// <summary>
		/// Gets a value indicating the amount of objects in the list
		/// </summary>
		public int Count
		{
			get { return this.count; }
		}

		/// <summary>
		/// Indexer to use Get-method
		/// </summary>
		/// <param name="index"> index to object to get </param>
		/// <returns> the object data </returns>
		public object this[int index]
		{
			get { return this.Get(index); }
		}

		/// <summary>
		/// Adds an object in the list at an specified index
		/// </summary>
		/// <param name="index"> Index where to add object </param>
		/// <param name="o"> object to add </param>
		/// <returns> the object added to the list </returns>
		public object Add(int index, object o)
		{
			//Checks if index value is greater then 0
			if (index < 0)
			{ throw new ArgumentOutOfRangeException("Index " + index); }

			//If index value is greater or equal to 0, index value is set to the last value in the list
			if (index >= this.count)
			{ index = this.count; }

			//Gets the starting node of the list. current node is set to the head, now the current node is the start node
			Node current = this.head;

			//IF list is empty or index is equal to 0, insert the node at the beginning. ELSE new list.
			if(this.Empty || index == 0 )
			{
				this.head = new Node(o, this.head);
			}
			else
			{
				//For-loop that gets the node right before the node we want to insert into 
				for (int i = 0; i < index - 1; i++)
				{
					//current node is set to next node
					current = current.NextNode;
				}
				//Inserts the new node
				current.NextNode = new Node(o, current.NextNode);
			}
			//Adds a value to the list count
			count++;
			//returns the added object we inserted
			return o;
		}

		/// <summary>
		/// Adds an object at the END of the list
		/// </summary>
		/// <param name="o"> Object to add </param>
		/// <returns> the object added to the list </returns>
		public object AddLast(object o)
		{
			return this.Add(Count, o);
		}

		/// <summary>
		/// Removes an object in the list at an specified index
		/// </summary>
		/// <param name="index"> Index where to remove object </param>
		/// <returns> the object removed to the list </returns>
		public object Remove(int index)
		{
			//Checks if index value is greater then 0
			if (index < 0)
			{ throw new ArgumentOutOfRangeException("Index " + index); }

			//Checks if empty is true, then return null
			if (this.Empty)
			{ return null; }

			//If index value is greater or equal to 0, index value is set to the last value in the list minus 1 beacuse we are removing a node in this method
			if (index >= this.count)
			{ index = this.count - 1; }

			//Gets the starting node of the list. current node is set to the head, now the current node is the start node
			Node current = this.head;
			//object the method returns, which has to be set to null beacuse we´re removing that node
			object result = null;

			//IF index is equal to 0, object result gets the current data and sets the head-node to the next node. ELSE new list.
			if (index == 0)
			{
				result = current.Data;
				this.head = current.NextNode;
			}
			else
			{
				//For-loop that gets the node right before the node we want to remove 
				for (int i = 0; i < index - 1; i++)
				{
					//current node is set to next node
					current = current.NextNode;
				}
				//Sets result to the current next nodes data
				result = current.NextNode.Data;
				//Sets the current next to the current next next node, so the reference to node we remove is gone
				current.NextNode = current.NextNode.NextNode;
			}
			//removes a value from the list count
			count--;
			//returns the object we want to remove
			return result;
		}

		/// <summary>
		/// Clears the list of nodes
		/// </summary>
		public void ClearList()
		{
			//Sets the head-node to null and all other references to the other nodes are gone
			this.head = null;
			//Sets the count value to 0, which shows the list is empty
			this.count = 0;
		}

		/// <summary>
		/// Gets the index of an object and returns that index or -1 if not found
		/// </summary>
		/// <param name="o"> object to get index of </param>
		/// <returns> the index of the searched object </returns>
		public int IndexOf(object o)
		{
			//Sets the current node to the star/head node
			Node current = this.head;

			//for-loop that searches the list of nodes
			for (int i = 0; i < this.count; i++)
			{
				//IF current object is equal to searched object return that object index
				if(current.Data.Equals(o))
				{
					//returns object index
					return i;
				}
				//Sets the current node to the next node in the for-loop, so that the for-loop searches through all nodes in the list
				current = current.NextNode;
			}
			//returns -1 if the serached object wasn´t found in the list
			return -1;
		}

		/// <summary>
		/// Checks if list contains a specified object
		/// </summary>
		/// <param name="o"> object searched for </param>
		/// <returns> true or false </returns>
		public bool Contains(object o)
		{
			//Initilize IndexOf-method if method not returns -1 it´s true that the object exsist in the list otherwise false
			return this.IndexOf(o) != -1;
		}

		/// <summary>
		/// Gets the object at a specified index
		/// </summary>
		/// <param name="index"> index of object to get </param>
		/// <returns> object data </returns>
		public object Get(int index)
		{
			//Checks if index value is greater then 0
			if (index < 0)
			{ throw new ArgumentOutOfRangeException("Index " + index); }

			//Checks list is empty return null
			if (this.Empty)
			{ return null; }

			//If index value is greater or equal to count value, index value is set to the last value in the list minus 1 beacuse we want to get the value in the last iteam in the list
			if (index >= this.count)
			{ index = this.count - 1; }

			//Gets the starting node of the list. Current node is set to the head, now the current node is the start node
			Node current = this.head;

			//for-loop that gets the specified object
			for (int i = 0; i < index; i++)
			{
				//current node is set to next node
				current = current.NextNode;
			}
			//returns the specified objects data
			return current.Data;
		}
	}
}
