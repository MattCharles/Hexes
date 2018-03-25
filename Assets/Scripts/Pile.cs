using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile<T> : List<T> {

    //Fisher-Yates Shuffle.
    public Pile<T> Shuffle()
    {
        for (int i = this.Count - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            T temp = this[i];
            this[i] = this[r];
            this[r] = temp;
        }
        return this;
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
        T item = this[0];
        this.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        return this[0];
    }
}