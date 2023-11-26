using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarefa 
{
   public virtual bool Executa(Transform player, Transform npc, Grid gridref, bool suavez){
    return true;
 }
}
