using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MyDoublyLinkedList
{
    public class DoubleLinkedList
    {
        private ListNode head;
        private ListNode tail;

        public int Count { get; private  set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                ListNode newHead = new ListNode(element);
                ListNode oldHead = this.head;

                this.head = newHead;
                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;

            }

            this.Count++;
        }

        public void AddLast(int element)

        {
            if (this.Count == 0 )
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            { 
                ListNode newTail = new ListNode(element);
                ListNode oldTail = this.tail;

                this.tail = newTail;
                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;
            }

            Count++;
        }

        public int RemoveFirst()
        {
           

            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
            int removedElement = this.head.Value;
            
            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode newNode = this.head.NextNode;
                newNode.PreviousNode = null;
                this.head = newNode;
            }

            this.Count--;

            return removedElement; 
        }

        public int RemoveLast()
        {
           
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            int removedEl = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode newTail = this.tail.PreviousNode;
                newTail.NextNode = null;
                this.tail = newTail;
            }

            Count--;

            return removedEl;
        }

        public void ForEach(Action<int> action)
        {
            ListNode currentEl = this.head;

            while (currentEl != null)
            {
                action(currentEl.Value);
                currentEl = currentEl.NextNode;
            }
        }

    }

}
 