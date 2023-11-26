using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fugir : Tarefa
{

 
    public Fugir(){

    }

    public override bool Executa(Transform jogador, Transform npc, Grid gridref, bool suavez){
        float velocidade = 3.0f;
        float alcanceDeFuga = 5.0f;
        Debug.Log("Correr!!");
        
        Vector3 v3 = jogador.position;



        
        Vector3 direcaoDeFuga =  npc.position - v3;
        direcaoDeFuga.Normalize();

        npc.Translate(direcaoDeFuga * velocidade * Time.deltaTime);

        return true;

    }
}
