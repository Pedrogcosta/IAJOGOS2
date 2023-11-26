using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencia : Tarefa
{
    private Tarefa[] subtarefas;
    private int NumeroTarefas;

    public Sequencia(Tarefa[] s , int n){
        this.subtarefas = s;
        this.NumeroTarefas = n;
    }



   public override bool Executa(Transform p, Transform npc, Grid grid, bool suavez){
        int aux = 0;
        for(int i=0; i < NumeroTarefas; i++){
            Debug.Log("!" + i + ": " + subtarefas[i].Executa(p, npc, grid, suavez));
            if(subtarefas[i].Executa(p, npc, grid, suavez)){
               
                aux++;

            }else{
                return false;
            }
        }
        if(aux == NumeroTarefas){
            Debug.Log(aux);
            return true;
        }

        return false;
    }
}
