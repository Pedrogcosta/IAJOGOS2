using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Acao
{
   public Idle() {

    }

    public override bool Executa(Transform player, Transform npc, Grid gridref, bool suavez){
        return true;

    }
}
