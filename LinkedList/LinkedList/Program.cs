using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add First:");
            LinkedList myList1 = new LinkedList();

            myList1.AddFirst("Hello");
            myList1.AddFirst("Magical");
            myList1.AddFirst("World");
            myList1.PrintAllNodes();

            Console.WriteLine();

            Console.WriteLine("Add Last:");
            LinkedList myList2 = new LinkedList();

            myList2.AddLast("Hello");
            myList2.AddLast("Magical");
            myList2.AddLast("World");
            myList2.PrintAllNodes();


            GenericList<int> gll = new GenericList<int>();
            gll.AddNode(5);
            gll.AddNode(4);
            gll.AddNode(3);
            gll.PrintAll();


            GenericList<string> gll2 = new GenericList<string>();
            gll2.AddNode("one");
            gll2.AddNode("two");
            gll2.AddNode("three");
            gll2.PrintAll();



            Console.ReadLine();
        }

    }



    public class Node
    {
        public Node next;
        public Object data;
    }

    public class LinkedList
    {
        private Node head;


        public void PrintAllNodes()
        {
            Node current = head;
            while(current!=null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }


        public void AddFirst(Object data)
        {
            Node toAdd = new Node();

            toAdd.data = data;
            toAdd.next = head;

            head = toAdd;
        }

        public void AddLast(Object data)
        {

            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {

                Node toAdd = new Node();
                toAdd.data = data;

                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }
        }
    }



    // T is the type of data stored in a particular instance of GenericList.
    public class GenericList<T>
    {
        private class Node
        {
            // Each node has a reference to the next node in the list.
            public Node Next;
            // Each node holds a value of type T.
            public T Data;
        }

        // The list is initially empty.
        private Node head = null;

        // Add a node at the beginning of the list with t as its data value.
        public void AddNode(T t)
        {
            Node newNode = new Node();
            newNode.Next = head;
            newNode.Data = t;
            head = newNode;
        }

        // The following method returns the data value stored in the last node in
        // the list. If the list is empty, the default value for type T is
        // returned.
        public T GetFirstAdded()
        {
            // The value of temp is returned as the value of the method. 
            // The following declaration initializes temp to the appropriate 
            // default value for type T. The default value is returned if the 
            // list is empty.
            T temp = default(T);

            Node current = head;
            while (current != null)
            {
                temp = current.Data;
                current = current.Next;
            }
            return temp;
        }

        public void PrintAll() {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

}
