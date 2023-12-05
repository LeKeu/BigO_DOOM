using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegarMunicao : MonoBehaviour
{
    [SerializeField] int qntdBalas = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IA_DAC.qntdBalasAUX = true;
            JogadorControle.instancia.qntdBalas += qntdBalas;
            JogadorControle.instancia.AtualizarBala();
            Destroy(gameObject);
            // barulho p quando pegar bala
        }
    }
}
