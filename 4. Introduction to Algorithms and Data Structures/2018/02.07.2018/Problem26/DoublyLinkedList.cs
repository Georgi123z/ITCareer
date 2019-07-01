﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem26
{
    class DoublyLinkedList<T>:IEnumerable<T>
    {
        private class ListNode<T>
        {
            public T Value { get; set; }
            public ListNode<T> Prev { get; set; }
            public ListNode<T> Next { get; set; }
            public ListNode(T Value)
            {
                this.Value = Value;
                this.Next = null;
                this.Prev = null;
            }
        }

        private ListNode<T> Head { get; set; }
        private ListNode<T> Tail { get; set; }
        public int Count { get; private set; }

        public DoublyLinkedList()
        {

        }

        public void AddFirst(T element)
        {
            if (Count==0)
            {
                this.Head = this.Tail = new ListNode<T>(element);
            }
            else
            {
                var newone = new ListNode<T>(element);
                newone.Next = this.Head;
                this.Head.Prev = newone;
                this.Head = newone;
            }
            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count==0)
            {
                this.Head = this.Tail = new ListNode<T>(element);
            }
            else
            {
                var newone = new ListNode<T>(element);
                newone.Prev = this.Tail;
                this.Tail.Next = newone;
                this.Tail = newone;
            }
            this.Count++;
        }

        public T RemoveFirst()
        {
            var elementoreturn = this.Head.Value;
            this.Head.Prev = null;
            this.Head = this.Head.Next;
            this.Count--;
            return elementoreturn;
        }

        public T RemoveLast()
        {
            T  elementoreturn = this.Tail.Value;
            this.Tail = this.Tail.Prev;
            this.Tail.Next = null;
            this.Count--;
            return elementoreturn;
        }

        public T[] ToArray()
        {
            var curr = this.Head;
            var index = 0;
            var arr = new T[this.Count];
            while (curr != null)
            {
                arr[index++] = curr.Value;
                curr = curr.Next;
            }
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curr = this.Head;
            while (curr!=null)
            {
                yield return curr.Value;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
