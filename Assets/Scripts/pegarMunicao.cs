using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegarMunicao : MonoBehaviour
{
    [SerializeField] int qntdBalas = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            JogadorControle.instancia.qntdBalas += qntdBalas;
            JogadorControle.instancia.AtualizarBala();
            Destroy(gameObject);
            // barulho p quando pegar bala
        }
    }
}
