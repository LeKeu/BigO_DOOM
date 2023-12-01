using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegarVida : MonoBehaviour
{
    [SerializeField] int qntdVida = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IA_DAC.qntdVidaAUX = true;
            JogadorControle.instancia.CurarVida(qntdVida);
            Destroy(gameObject);
        }
    }
}
