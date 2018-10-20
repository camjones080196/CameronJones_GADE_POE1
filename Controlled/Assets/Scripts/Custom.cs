using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomQueue<T>
{
    protected List<T> list;
    private int count;


    public int Count
    {
        get
        {
            return list.Count;
        }
    }

    public CustomQueue()
    {
        list = new List<T>();
    }

    public void Enqueue(T item)
    {
        list.Add(item);
        count++;
    }

    public T Peek()
    {
        return list[0];
    }



    public virtual T Dequeue()
    {
        T returnVal = default(T);
        var first = list[0];
        if (first != null)
        {
            returnVal = list[0];
            list.RemoveAt(0);
        }
        count--;
        return returnVal;
    }

    public void Clear()
    {
        list.Clear();
    }

    public bool IsEmpty()
    {
        if (list.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}