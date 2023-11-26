using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estaperto : Condicao
{
  private int proxDistance = 50;


  public Estaperto( ){
  
 }

 public override  bool Executa(Transform player, Transform npc, Grid gridref, bool suavez){
  if (Vector3.Distance(npc.position, player.position) < proxDistance)
  {
    return true;          
  }
  return false;
 }

}
