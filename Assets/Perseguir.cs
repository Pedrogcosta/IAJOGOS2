using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : MonoBehaviour
{
    
  public Grid gridref;
  private List<Node> caminho;

  public float tempoLimite = 10f;
  private float tempoAtual = 0f;

  void Awake(){
    List<Node> caminho = new List<Node>();
  }
    // Update is called once per 

  public void começar(Transform npc){
    Debug.Log("Tempo limite atingido!");
    StartCoroutine(IniciarTemporizador(npc));
  }
    
      IEnumerator IniciarTemporizador(Transform npc)
  {
      tempoAtual = 0f;

    while (tempoAtual < tempoLimite)
    {
        tempoAtual += Time.deltaTime; 
        yield return null;
            caminho = gridref.path;
    
        Vector3 Distance = caminho[0].worldposition - npc.transform.position;
        Distance.Normalize();
          
        npc.transform.Translate(Distance * 5 * Time.deltaTime);
    }

    Debug.Log("Tempo limite atingido!");
  }

}
