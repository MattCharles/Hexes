﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HexMetrics {
    public const float outerRadius = 10f;
    public const float innerRadius = outerRadius * .866025404f;

    public static Vector3[] corners = {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(0f, 0f, outerRadius)
    };
}


public class HexCell : MonoBehaviour {

    public HexCoordinates coordinates;

    public Color color;

    private void Awake()
    {
        
    }
}
