using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    public float velocidade = 1.0f; // Velocidade de movimento do personagem

    // Update is called once per frame
    void Update()
    {
        // Obtém os inputs de movimento horizontal e vertical
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento com base nos inputs
        Vector3 movimento = new Vector3(movimentoHorizontal, movimentoVertical, 0.0f);

        // Normaliza o vetor de movimento para manter a mesma velocidade em todas as direções
        movimento = movimento.normalized * velocidade * Time.deltaTime;

        // Move o personagem
        transform.Translate(movimento);

        // Você também pode adicionar limites ao movimento do personagem
        // Por exemplo, para limitar o movimento dentro de uma área específica:
        // transform.position = new Vector3(
        //     Mathf.Clamp(transform.position.x, minX, maxX),
        //     Mathf.Clamp(transform.position.y, minY, maxY),
        //     transform.position.z
        // );
    }
}
