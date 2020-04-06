using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MyDoublyLinkedList
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                T[] arr = this.ToArray();

                if (index < 0 || index>= arr.Length)
                {
                    throw new ArgumentException("Index outside of the bounds of the list!", nameof(index));
                }

                return arr[index];
            }
        }
        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element); 
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                ListNode<T> oldHead = this.head;

                this.head = newHead;
                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;

            }

            this.Count++;
        }

        public void AddLast(T element)

        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                ListNode<T> oldTail = this.tail;

                this.tail = newTail;
                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;
            }

            Count++;
        }

        public T RemoveFirst()
        {


            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
            T removedElement = this.head.Value;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newNode = this.head.NextNode;
                newNode.PreviousNode = null;
                this.head = newNode;
            }

            this.Count--;

            return removedElement;
        }

        public T RemoveLast()
        {

            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            T removedEl = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newTail = this.tail.PreviousNode;
                newTail.NextNode = null;
                this.tail = newTail;
            }

            Count--;

            return removedEl;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentEl = this.head;

            while (currentEl != null)
            {
                action(currentEl.Value);
                currentEl = currentEl.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];

            int cnt = 0;

            ListNode<T> currentEl = this.head;
            while (currentEl != null)
            {
                arr[cnt++] = currentEl.Value;
                currentEl = currentEl.NextNode;

            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
