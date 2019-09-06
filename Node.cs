using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListTutorial
{
	public class Node
	{
		/* Construtor
		 * [x] Node(Object data, Node next)
		 * 
		 * Private fields:
		 * [x] Object data - contains the data of the node, what we want to sore in the list
		 * [x] Node next - reference to the next node in the list
		 * 
		 * Public properties:
		 * [x] Data - get/set the data field
		 * [x] next - get/set the next field
		 */

		//reference to the node data type
		private object data;
		//reference to the next node in the list
		private Node nextNode;

		/// <summary>
		/// Creates a new node, constructor to Node class
		/// </summary>
		/// <param name="data"> sets the data type of the object </param>
		/// <param name="nextNode"> sets the link to the next node </param>
		public Node(object data, Node nextNode)
		{
			this.data = data;
			this.nextNode = nextNode;
		}

		/// <summary>
		/// Makes the data variable reachable
		/// </summary>
		public object Data
		{
			get { return this.data; }
			set { this.data = value; }
		}

		/// <summary>
		/// Makes the nextnode variable reachable
		/// </summary>
		public Node NextNode
		{
			get { return this.nextNode; }
			set { this.nextNode = value; }
		}

	}
}
