using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackUsingLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] a = new int[] { 1, 2, 3 };
            /*
            Linkedlist list = new Linkedlist(a);
            list.Print();
            */

            /*
            Stack s = new Stack();
            s.Push(0);
            s.Push(5);
            s.Push(2);
            s.Push(3);
            s.Pop();
            //s.Push(8);

            s.Print();
            */


            /*
        try
            {
                //int userVal = Convert.ToInt32(args[0]);
            }
            catch (NotFiniteNumberException e)
            {
                Console.WriteLine("Error: Inputs can only be numbers. ");
                 if(args == null) { 
            Console.WriteLine("What is your input");
            }
            */

            Stack s = new Stack();
            Console.WriteLine("Welcome to Stack Linklist!");

            int count = 0;
            bool pressedQ = false;
           
            while (pressedQ == false)
            {
                Console.WriteLine("You have the option to q-quit, p-pop, ps-push, pr - print");
                Console.WriteLine("Type in a command: ");
                String userInput = Console.ReadLine();

                if (userInput == "q")
                {
                    pressedQ = true;
                }   
                if(userInput == "ps")
                {
                    Console.Write("Type in an integer: ");
                    String val = Console.ReadLine();
                    try
                    {
                        int v = Convert.ToInt32(val);
                        s.Push(v);
                        count++;
                        Console.WriteLine("You have pushed {0} into the Linked List", val);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("This input is not a number");
                    }
                }
                if (userInput == "p")
                {
                    if (count == 0)
                    {
                        Console.WriteLine("You can't pop with an empty Linked List");
                    }
                    else
                    {
                        s.Pop();
                        Console.WriteLine("You have popped a value");
                        count--;
                    }
                }
                if (userInput == "pr")
                {
                    if (count == 0)
                    {
                        Console.WriteLine("You have an empty Linked List");
                    }
                    else {
                        Console.Write("Your Linked List current have the values: ");
                        s.Print();
                    }
                }
            }







        }

        public class Node
        {
            public Node next;
            public int data;

            public Node(int data, Node next)
            {
                this.data = data;
                this.next = next;

            }

            public int Data
            {
                get { return this.data; }

            }
            public Node Next
            {
                get { return this.next; }
                set { this.next = value; }
            }
/*
            public Node Previous
            {
                get { return this.Previous; }
                set { this.Previous = value; }
            }
  */          
        }

        public class Linkedlist
        {
            public Node head;
            public Node top;
           // public Node prev;
            public int count;

            public Linkedlist()
            {
                head = null;
                count = 0;

            }

            public Linkedlist(int[] a)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    Insert(count, a[i]);

                }
                Add(4);
                Remove(2);
                Insert(1, 4);
            }

            public bool Insert(int index, int data)
            {
                Node current = this.head;
               // Node prev = this.top;
                top = current;

                // assumes that the first reference is empty
                if (current == null)

                    this.head = new Node(data, this.head);
                

                // adding reference in the midle 
                else
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                      //  before = before.Previous;

                    }
                    current.Next = new Node(data, current.Next);
                   
                }

                count++;
                return true;
            }

            public void Add(int data)
            {
                Insert(count, data);

            }

            public int Remove(int index)
            {
              
                Node current = this.head;
                int result;
               // int preResult;

                // removing the first reference
                if (index == 0)
                {
                    result = current.Data;
                    this.head = current.Next;


                }
                else
                {
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }
                 
                    
                    
                        result = current.Next.Data;
                        current.Next = current.Next.Next;
                    
                }
                count--;

                return result;
            }

            public Node deleteLast (Node head)
            {
                if (head == null)
                {
                    return head;
                }

                Node last = head;
                Node prev = null;
                while (last.next != null)
                {
                    prev = last;
                    last = last.next;
                }
              //  prev.Next = null;
                count--;
                return last;
            }

            public void pop()
            {
                
                deleteLast(head);

            }

            public int[] Arr()
            {
                int[] a = new int[count];
                Node temp = head;
                int i = 0;
                while (temp != null)
                {

                    a[i] = temp.data;
                    temp = temp.Next;
                    i++;
                }
                return a;
            }

            public void Print()
            {
                int[] a = Arr();

                Console.Write(a[0]);
                for (int i = 1; i < a.Length; i++)
                {
                    Console.Write(" " + a[i]);

                }
            }
        }

        public class Stack
        {
            public Linkedlist stack;
            public Stack()
            {
                stack = new Linkedlist();
            }
            public void Push(int data)
            {
                stack.Add(data);
            }

            public void Pop()
            {
                if (stack.head == null)
                {
                    throw new Exception("Error: You cannot pop data that you don't have");
                }
                else
                {
                    stack.pop();
                   // stack.count = stack.count-1;
                }
            }


            public int[] Arr()
            {
                int[] a = new int[stack.count];
                Node temp = stack.head;
                int i = 0;
                while (temp != null && i != stack.count)
                {

                    a[i] = temp.data;
                    temp = temp.Next;
                    i++;
                }
                return a;
            }

            public void Print()
            {
                int[] a = Arr();

                Console.Write(a[0]);
                for (int i = 1; i < a.Length; i++)
                {
                    Console.Write(" " + a[i]);

                }
                Console.ReadLine();
            }
        }

    }
}


