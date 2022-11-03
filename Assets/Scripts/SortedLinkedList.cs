using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A sorted linked list
/// </summary>
public class SortedLinkedList<T> : LinkedList<T> where T:IComparable
{
    #region Constructor

    public SortedLinkedList() : base()
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Adds the given item to the list
    /// </summary>
    /// <param name="item">item to add to list</param>
    public void Add(T item)
    {
        //add your code here
        // add your code here
        if (First == null)
        {
            AddFirst(item);
        }
        //else if (Contains(item))
        //{

        //}
        else if (First.Value.CompareTo(item) > 0)
        {
            AddFirst(item);
        }
        else
        {
            Reposition(item);
        }
    }

    /// <summary>
    /// Repositions the given item in the list by moving it
    /// forward in the list until it's in the correct
    /// position. This is necessary to keep the list sorted
    /// when the value of the item changes
    /// </summary>
    public void Reposition(T item)
    {
        // add your code here
        LinkedListNode<T> list = Find(item);
        if (Contains(item))
        {
            if (list == null)
            {
                throw new Exception("Null exception");
            }
            else if (First.Value.CompareTo(list.Value) >= 0)
            {
                AddFirst(item);
            }
            else
            {
                LinkedListNode<T> previousNode = null;
                LinkedListNode<T> currentNode = First;
                while (currentNode != null && currentNode.Value.CompareTo(item) <= 0)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }
                if (currentNode == null)
                {
                    AddLast(item);
                }
                else
                {
                    AddBefore(currentNode, item);
                }
            }
        }
    }

    #endregion
}
