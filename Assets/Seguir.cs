using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : Tarefa
{
    private Grid grid;

    private List<Node> caminho = new List<Node>();

    public float tempoLimite = 10f;
    private float tempoAtual = 0f;
 
    public Seguir(){

    }

    public override bool Executa(Transform jogador, Transform npc, Grid gridref, bool suavez){
        grid = gridref;
        Debug.Log("seguir : 1");
        caminho = grid.path;
        if(caminho.Count > 0){
        Vector3 Distance = caminho[0].worldposition - npc.transform.position;
        Distance.Normalize();
          
        npc.transform.Translate(Distance * 5 * Time.deltaTime);
        }
        return true;
    }


}
