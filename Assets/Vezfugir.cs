using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vezfugir : Condicao
{
    public override bool Executa(Transform player, Transform npc, Grid gridref, bool suavez){
        if(!suavez)
        return true;

        return false;
    }
}
