using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    [SerializeField] public int vida = 3;

    [SerializeField] float jogadorRange = 10f;
    [SerializeField] float movVel = 5f;
    Rigidbody2D rb;

    bool podeAtirar = true;
    [SerializeField] float atirarRate = .5f;
    float atirarCounter;
    [SerializeField] GameObject balaInimigo;
    [SerializeField] Transform balaPonto;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, JogadorControle.instancia.transform.position) < jogadorRange)
        {
            Vector3 jogadorDir = JogadorControle.instancia.transform.position - transform.position;
            rb.velocity = jogadorDir.normalized * movVel;

            if (podeAtirar)
            {
                atirarCounter -= Time.deltaTime;
                if(atirarCounter <= 0)
                {
                    Instantiate(balaInimigo, balaPonto.position, balaPonto.rotation);
                    atirarCounter = atirarRate;
                }
            }
        }
    }

    public void TirarVida()
    {
        vida--;
        if(vida <= 0) 
        { 
            Destroy(gameObject);
            
            if (transform.tag == "Inimigo")
                OndaInimigo.qntdInmVivo--;
        }
    }
}
