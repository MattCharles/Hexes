using UnityEngine;

// Unity can store Serializable object. Survives recompiles in play mode.
[System.Serializable]
public struct HexCoordinates
{
    [SerializeField]
    private int x, z;
    //public read = object is immutable
    public int X {
        get
        {
            return x;
        }
    }

    public int Y {
        get {
            return -X - Z;
        }
    }

    public int Z
    {
        get
        {
            return z;
        }
    }

    public HexCoordinates(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    /* 
     * Create HexCoordinates that correspond to offset coordinates.
     * Instead of having zig-zag X coordinates that try to map to Cartesian coordinates,
     * this will align Cartesian coordinates to cubic coordinates.
     */
    public static HexCoordinates FromOffsetCoordinates(int x, int z)
    {
        return new HexCoordinates(x - z/2, z);
    }

    public override string ToString()
    {
        return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeperateLines()
    {
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }
    
    public static HexCoordinates FromPosition(Vector3 position)
    {
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float y = -x;
        float offset = position.z / (HexMetrics.outerRadius * 3f);
        x -= offset;
        y -= offset;
        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        int iZ = Mathf.RoundToInt(-x-y);
        if(iX + iY + iZ != 0)
        {
            Debug.Log("rounding error!");

            //Recalculate the coordinate with the highest delta. Unless it's Y. We don't care about Y.

            float dX = Mathf.Abs(x - iX);
            float dY = Mathf.Abs(y - iY);
            float dZ = Mathf.Abs(-x-y - iZ);

            if(dX > dY && dX > dZ)
            {
                iX = -iY - iZ;
            } else if(dZ > dY)
            {
                iZ = -iX - iY;
            }
        }
        return new HexCoordinates(iX, iZ);
    }

}
