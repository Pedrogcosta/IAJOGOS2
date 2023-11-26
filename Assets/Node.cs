using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 worldposition;
    public int gridx;
    public int gridy;

    public int custog;
    public int custoh;
    public Node parent;

    public Node(bool _walkable, Vector3 _worldpos, int _gridx, int _gridy)
    {
        walkable = _walkable;
        worldposition = _worldpos;
        gridx = _gridx;
        gridy = _gridy;
    }

    public int custof
    {
        get
        {
            return custog + custoh;
        }
    }
}