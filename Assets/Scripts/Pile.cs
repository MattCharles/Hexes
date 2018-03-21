using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile<T> : List<T> {
    private List<T> list = new List<T>();

    //Fisher-Yates Shuffle.
    public Pile<T> Shuffle()
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            T temp = list[i];
            list[i] = list[r];
            list[r] = temp;
        }
        return (Pile<T>) list;
    }

    //Shuffle a pile and then clear it out. Used to transfer discard to deck.
    public Pile<T> ShuffleAndClear()
    {
        Pile<T> pile = this.Shuffle();
        this.Clear();
        return pile;
    }

    public T Pop()
    {
        T item = list[0];
        list.RemoveAt(0);
        return item;
    }
}