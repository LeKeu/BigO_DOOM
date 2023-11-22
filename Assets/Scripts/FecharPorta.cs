using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FecharPorta : MonoBehaviour
{
    [SerializeField] BuffDebuff buffdebuff;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            porta.abrirPorraPorta = false;
            buffdebuff.Normal();
        }
    }
}
