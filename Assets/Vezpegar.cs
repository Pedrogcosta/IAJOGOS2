using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vezpegar : Condicao
{
    public override bool Executa(Transform player, Transform npc, Grid gridref, bool suavez){
       return suavez;

    }
}
