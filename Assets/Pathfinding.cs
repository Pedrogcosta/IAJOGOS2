using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.GraphView;

public class Pathfinding : MonoBehaviour
{
    public Transform cacador;
    public Transform alvo;
    Grid grid;

    void Update()
    {
        FindPath(cacador.position, alvo.position);
    }

    void Awake()
    {
        grid = GetComponent<Grid>();
    }
    void FindPath(Vector3 startpos, Vector3 endpos)
    {
        Node startnode = grid.Nodeposition(startpos);
        Node targetnode = grid.Nodeposition(endpos);

        List<Node> open = new List<Node>();
        HashSet<Node> visited = new HashSet<Node>();

        open.Add(startnode);

        while(open.Count > 0)
        {
            Node currentnode = open[0];


            for (int i = 1; i < open.Count; i++)
            {
                if (open[i].custof < currentnode.custof || open[i].custof == currentnode.custof && open[i].custoh < currentnode.custoh)
                {
                    currentnode = open[i];
                }
            }

            open.Remove(currentnode);
            visited.Add(currentnode);

            if (currentnode == targetnode)
            {
                retracepath(startnode, targetnode);
                return;
            }


            foreach(Node neighbour in grid.getneighbours(currentnode))
            {
                if(!neighbour.walkable || visited.Contains(neighbour))
                {
                    continue;
                }

                int newmovecosts = currentnode.custog + getdistance(currentnode, neighbour);


                if (newmovecosts < neighbour.custog || !open.Contains(neighbour))
                {
                    neighbour.custog = newmovecosts ;
                    neighbour.custoh = getdistance(neighbour, targetnode);
                    neighbour.parent = currentnode;
                }

                if (!open.Contains(neighbour))
                {
                    open.Add(neighbour);
                }
            }

        }
    }

    void retracepath(Node startNode, Node endNode)
    {
        List<Node> caminho = new List<Node>();
        Node currentnode = endNode;

        while (currentnode != startNode)
        {
            caminho.Add(currentnode);
            currentnode = currentnode.parent;
        }

        caminho.Reverse();

        grid.path = caminho;
    }

    int getdistance(Node nodea, Node nodeb)
    {
        int dstx = Mathf.Abs(nodea.gridx - nodeb.gridx);
        int dsty = Mathf.Abs(nodea.gridy - nodeb.gridy);

        if (dstx > dsty)
            return 14 * dsty + (10 * (dstx - dsty));
        return 14 * dstx + (10 * (dsty - dstx));

    }
}