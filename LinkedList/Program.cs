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
            LinkedList linkedList = new LinkedList();
            //linkedList.AddAtLast(6);
            //linkedList.AddAtLast(-6);
            //linkedList.AddAtLast(8);
            //linkedList.AddAtLast(4);
            //linkedList.AddAtLast(-12);
            //linkedList.AddAtLast(9);
            //linkedList.AddAtLast(8);
            //linkedList.AddAtLast(-8);
            //linkedList.AddAtLast(8);
            //linkedList.AddAtLast(10);
            //linkedList.AddAtLast(4);
            //linkedList.AddAtLast(-1);
            //linkedList.AddAtLast(-3);
            //linkedList.AddAtLast(4);
            //linkedList.AddAtLast(6);
            //linkedList.AddAtLast(-10);
            //linkedList.AddAtLast(8);
            //linkedList.AddAtLast(9);
            //linkedList.AddAtLast(10);
            //linkedList.AddAtLast(-19);
            //linkedList.AddAtLast(10);
            //linkedList.AddAtLast(-18);
            //linkedList.AddAtLast(20);
            //linkedList.AddAtLast(25);
            //Duplicate nodes
            //linkedList.AddAtLast(20);
            //linkedList.AddAtLast(13);
            //linkedList.AddAtLast(13);
            //linkedList.AddAtLast(11);
            //linkedList.AddAtLast(11);
            //linkedList.AddAtLast(11);  
            //Add one to node
            //linkedList.AddAtLast(1);
            //linkedList.AddAtLast(9);
            //linkedList.AddAtLast(9);
            //linkedList.AddAtLast(9);
            //ReverseBasedOnSize
            //linkedList.AddAtLast(1);
            //linkedList.AddAtLast(2);
            //linkedList.AddAtLast(3);
            //linkedList.AddAtLast(4);
            //linkedList.AddAtLast(5);
            //linkedList.AddAtLast(6);
            //linkedList.AddAtLast(7);
            //linkedList.AddAtLast(8);
            //linkedList.AddAtLast(9);
            //linkedList.AddAtLast(10);
            //linkedList.AddAtLast(11);
            //Detect Loop
            linkedList.AddAtLast(20);
            linkedList.AddAtLast(4);
            linkedList.AddAtLast(15);
            linkedList.AddAtLast(10);
            Node head = linkedList.GetHead();
            //creating loop for testing
            head.Address.Address.Address.Address = head;
            var res = linkedList.DetectLoop();
            Console.WriteLine("Has loop" + res);
            linkedList.Display(head);
            var FinalNode = linkedList.ReverseBasedOnSize(head,5);
            linkedList.Display(FinalNode);
            linkedList.AddOneToNode();
            linkedList.Display(head);
            linkedList.RemoveDuplicateEleFromSortedLinkedList();
            linkedList.Display(head);
            linkedList.DeleteMiddleNode();
            linkedList.Display(head);
            linkedList.RemoveCancellableNode();
            linkedList.DisplayMiddleNode();
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Address { get; set; }
    }

    public class LinkedList
    {
        private  Node Head = null;
        private  Node Tail = null;
        private int count = 0;

        public Node GetNode()
        {
            Node newNode = new Node();
            newNode.Address = null;
            return newNode;
        }

        public Node GetTopNode()
        {
            return Tail;
        }

        public void AddAtLast(int ele)
        {
            Node newNode = GetNode();
            newNode.Data = ele;
            if (Head == null)
            {
                Head = newNode;
                Tail = Head;
            }
            else
            {
                Tail.Address = newNode;
                Tail = newNode;
            }
            count++;
        }

        //Ex: 1->9->9->9 input
        //output should be 1999+1 = 2000 so 2->0->0->0
        //This can be done by reversing the linked list then adding 1 to the head if there is a carry add 1 to the next and so on
        //Here I am doing using recursion
        public void AddOneToNode()
        {
            int carry = AddWithCarry(Head);
           
            //After processing if carry is greater than 1 then add new node
            if(carry>0)
            {
                Node newNode = GetNode();
                newNode.Data = 1;
                newNode.Address = Head;    
            }
        }

        //Palindrome
        //traverse the list push each node to stack
        //again traverse the list ,pop the element from the list and compare

        //get the nth node from end of the list
        //reverse the list
        //traverse the reversed list and get the nth element



        //Recursive method for add one to node
        public int AddWithCarry(Node head)
        {
            if(head==null)
            {
                return 1;
            }

            int res = head.Data + AddWithCarry(head.Address);
            head.Data = res % 10;
            return res / 10;
        }

        //Detect Loop
        //This can be done by pushing node to hash table and checking whether it contains the next node when we encounter that.
        //Here it is implemented using 2 pointers
        public Boolean DetectLoop()
        {
            Node firstPtr = Head;
            Node secPtr = Head;
            while(firstPtr!=null && secPtr!=null&&secPtr.Address!=null)
            {
                firstPtr = firstPtr.Address;
                secPtr = secPtr.Address.Address;
                if(firstPtr==secPtr)
                {
                    RemoveLoop(firstPtr, Head);
                    return true;
                }
            }
            return false;
        }

        //Remove loop
        public void RemoveLoop(Node node_with_loop,Node head)
        {
            Node firstPtr = head;
            Node secPtr = node_with_loop;
            while(firstPtr!=null )
            {
                while(secPtr.Address!=node_with_loop && secPtr.Address!=firstPtr)
                {
                    secPtr = secPtr.Address;
                }
                if (secPtr.Address == firstPtr)
                {
                    break;
                }
                firstPtr = firstPtr.Address;
            }

            secPtr.Address = null;
            
        }

        //Reverse a linked list in group of given size
        //if given size is 5 and input is 1->2->3->4->5->6->7->8->9->10->null
        //output should be 5->4->3->2->1->10->9->8->7->6->null
        public Node ReverseBasedOnSize(Node head,int size)
        {
            Node current = head;
            int count = 0;
            Node next = null;
            Node prev = null;
            while(count<size && current!=null)
            {
                next = current.Address;
                current.Address = prev;
                prev = current;
                current = next;
                count++;
            }
            if(next!=null)
            {
                Head.Address = ReverseBasedOnSize(next, size);
            }
            return prev;
        }

        //Remove duplicates from sorted linked list
        public void RemoveDuplicateEleFromSortedLinkedList()
        {
            Node Current = Head;
            Node NextNode = null;
            while(Current.Address!=null)
            {
                if(Current.Data == Current.Address.Data)
                {
                    NextNode = Current.Address.Address;
                    Current.Address = null;
                    Current.Address = NextNode;
                }
                else
                {
                    Current = Current.Address;
                }
            }

        }

        //Delete the elements in linked list whose sum is zero
        public void RemoveCancellableNode()
        {
            Node start = Head;
            Stack stack = new Stack();
            List<int> list = new List<int>();
            while (start != null)
            {
                if (Convert.ToInt32(start.Data) > 0)
                {
                    stack.Push(start.Data);
                }
                else
                {
                    bool isSumZero = false;
                    int sum = Convert.ToInt32(start.Data);
                    while (!stack.IsEmpty())
                    {
                        int temp = stack.Pop();
                        sum = sum + temp;
                        if(sum ==0)
                        {
                            isSumZero = true;
                            list.Clear();
                            break;
                        }
                        list.Add(temp);
                    }
                    if(!isSumZero)
                    {
                        list.Reverse();
                        list.ForEach(x => stack.Push(x));
                        stack.Push(start.Data);
                    }
                }
                start = start.Address;
            }
            
            stack.Display();
        }

        public int Size()
        {
            return count;
        }

        public Node GetHead()
        {
            return Head;
        }

        public int RemoveAtLast()
        {            
            if(Head.Address==null)
            {
                int temp = Head.Data;
                Head = null;
                Tail = null;
                count--;
                return temp;
            }
            else
            {
                int data = Tail.Data;
                Node temp_node = Head;
                while(temp_node.Address.Address!=null)
                {
                    temp_node = temp_node.Address;
                }
                temp_node.Address = null;
                Tail = temp_node;
                count--;
                return data;
            }
            
        }

        public void Display(Node head)
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Address;
            }
        }

        //Display middle element
        public void DisplayMiddleNode()
        {
            Node firstPtr = Head;
            Node secPtr = Head;
            while (secPtr != null)
            {
                firstPtr = firstPtr.Address;
                secPtr = secPtr.Address.Address;
            }

            Console.WriteLine("Middle node is " + firstPtr.Data);
        }

        public void DeleteMiddleNode()
        {
            Node firstPtr = Head;
            Node secPtr = Head;
            Node PrevPtr = null;
            while (secPtr.Address != null)
            {
                PrevPtr = firstPtr;
                firstPtr = firstPtr.Address;
                secPtr = secPtr.Address.Address;
            }
            PrevPtr.Address = firstPtr.Address; 
        }
    }
}