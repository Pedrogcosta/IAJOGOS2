using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform player;
    Node[,] grid;
    public Vector2 gridworldsize;
    public float noderadius;
    public LayerMask unwalkablemask;

    float nodediameter;
    int gridsizex, gridsizey;

    private void Start()
    {
        nodediameter = noderadius * 2;
        gridsizex = Mathf.RoundToInt(gridworldsize.x / nodediameter);
        gridsizey = Mathf.RoundToInt(gridworldsize.y / nodediameter);

        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridsizex, gridsizey];
        Vector2 worldbottomleft = new Vector2(transform.position.x, transform.position.y) - Vector2.right * gridworldsize.x / 2 - Vector2.up * gridworldsize.y / 2;

        for ( int x = 0; x < gridsizex; x++ )
        {
            for ( int y =0; y < gridsizey; y++ )
            {
                Vector2 worldpoint = worldbottomleft + Vector2.right * (x * nodediameter + noderadius) + Vector2.up * (y * nodediameter + noderadius);
                bool walkable = (!Physics2D.OverlapCircle(worldpoint, noderadius));
                grid[x, y] = new Node(walkable, worldpoint);
            }
        }
    }

    public Node nodefromworldposition(Vector2 worldposition)
    {
        float percentx = (worldposition.x + gridworldsize / 2) / gridworldsize.x;
        float percenty = (worldposition.y + gridworldsize / 2) / gridworldsize.y;

        percentx = Mathf.Clamp01(percentx);
        percenty = Mathf.Clamp01(percenty);

        int x = Mathf.RoundToInt((gridsizex - 1) * percentx);
        int y = Mathf.RoundToInt((gridsizey - 1) * percenty);

        return grid[x, y];
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(gridworldsize.x, gridworldsize.y));

        if (grid != null)
        {
            Node playernode = nodefromworldposition(player.position);
            foreach(Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.black;
                if (playernode == n)
                {
                    Gizmos.color = Color.blue;
                }
                Gizmos.DrawCube(n.worldposition, Vector2.one * (nodediameter - .1f));
            }
        }
    }
}
