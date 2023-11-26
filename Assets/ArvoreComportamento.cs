using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArvoreComportamento : MonoBehaviour
{
    public Transform player;
    private Tarefa[] afazeres = new Tarefa[3];
    private Idle idle = new Idle();
    private Estaperto estaperto = new Estaperto();
    private Seguir seguir = new Seguir();
    private  Tarefa[] subtarefas = new Tarefa[5];
    private  Tarefa[] subtarefas1 = new Tarefa[5];
    private Vezpegar vezpegar = new Vezpegar();
    private Vezfugir vezfugir = new Vezfugir();
    private Fugir fugir = new Fugir();
    private bool suavez;

    private Sequencia pegar;
    private Sequencia correr;

    public Grid gridref;
    private List<Node> caminho;

    public float tempoLimite = 10f;
    private float tempoAtual = 0f;

    void Awake()
    {
        List<Node> caminho = new List<Node>();
        suavez = true;

        subtarefas[0] = vezpegar;
        subtarefas[1] = estaperto;
        subtarefas[2] = seguir;
       
        pegar = new Sequencia(subtarefas, 3);

        subtarefas1[0] = vezfugir;
        subtarefas1[1] = estaperto;
        subtarefas1[2] = fugir;

        correr = new Sequencia(subtarefas1, 3);

        afazeres[0] = pegar;
        afazeres[1] = correr;
        afazeres[2] = idle;

    }

    public void Update(){
        bool aux;
        aux = suavez;
        for(int i = 0; i < 3; i++){
         afazeres[i].Executa(player, transform, gridref, aux);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("colidiu");
        float velocidade = 3.0f;
        Vector3 v3 = player.position;
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("colidiu1");
            suavez = !suavez;
            Vector3 direcaoDeFuga = v3 - transform.position;
            direcaoDeFuga.Normalize();

            transform.Translate(direcaoDeFuga * velocidade * Time.deltaTime);

        }

    }

}
