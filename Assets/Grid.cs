using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    Node[,] grid;
    public Vector3 gridsize;
    public float noderadius;
    public LayerMask unwalkablemask;

    float nodediameter;
    int gridsizex;
    int gridsizey;

    private void Awake()
    {
        nodediameter = noderadius * 2;
        gridsizex = Mathf.RoundToInt(gridsize.x / nodediameter);
        gridsizey = Mathf.RoundToInt(gridsize.y / nodediameter);


        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridsizex, gridsizey];
        Vector3 worldbottomleft = transform.position - Vector3.right * gridsize.x / 2 - Vector3.up * gridsize.y / 2;

        for (int x = 0; x < gridsizex; x++)
        {
            for (int y = 0; y < gridsizey; y++)
            {
                Vector3 worldpoint = worldbottomleft + Vector3.right * (x * nodediameter + noderadius) + Vector3.up * (y * nodediameter + noderadius);
                bool walkable = (!Physics2D.OverlapCircle(worldpoint, noderadius, unwalkablemask));

                grid[x, y] = new Node(walkable, worldpoint, x, y);
            }
        }
    }

    public List<Node> getneighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }

                int checkx = node.gridx + x;
                int checky = node.gridy + y;

                if (checkx > 0 && checkx < gridsizex && checky > 0 && checky < gridsizey)
                {
                    neighbours.Add(grid[checkx, checky]);
                }
            }
        }

        return neighbours;
    }


    public Node Nodeposition(Vector3 position)
    {
        float percentx = (position.x + gridsize.x / 2) / gridsize.x;
        float percenty = (position.y + gridsize.y / 2) / gridsize.y;

        percentx = Mathf.Clamp01(percentx);
        percenty = Mathf.Clamp01(percenty);

        int x = Mathf.RoundToInt((gridsizex - 1) * percentx);
        int y = Mathf.RoundToInt((gridsizey - 1) * percenty);

        return grid[x, y];
    }

    public  List<Node> path;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridsize.x,gridsize.y,1));

        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.black;
                if (path != null)
                    if (path.Contains(n))
                        Gizmos.color = Color.blue;
                Gizmos.DrawCube(n.worldposition, Vector3.one * (nodediameter - .01f));
            }
        }
    }


}