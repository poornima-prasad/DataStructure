using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
   public class Stack
    {
       private LinkedList linkedList = null;
       public Stack()
       {
           linkedList = new LinkedList();
       }      
       public void Push(int ele)
       {
           linkedList.AddAtLast(ele);
       }

       public Boolean IsEmpty()
       {
           return linkedList.Size() == 0;
       }

       public Node Peek()
       {
           if (IsEmpty())
           {
               throw new Exception("Empty Stack");
           }
           else
           {
               return linkedList.GetTopNode();
           }
       }

       public void Display()
       {
           linkedList.Display(linkedList.GetHead());
       }

       public int Pop()
       {
           if(IsEmpty())
           {
               throw new Exception("Empty Stack");
           }
           else
           {
               return linkedList.RemoveAtLast();
           }
       }
    }
}
