using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile<T> : List<T> {
    private List<T> list = new List<T>();

    //Fisher-Yates Shuffle.
    void Shuffle()
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            T temp = list[i];
            list[i] = list[r];
            list[r] = temp;
        }
    }
}