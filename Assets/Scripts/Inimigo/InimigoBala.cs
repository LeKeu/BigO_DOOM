using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBala : MonoBehaviour
{
    [SerializeField] int danoBala = 5;
    [SerializeField] float balaVel = 5f;
    Rigidbody2D rb;
    Vector3 direcao;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direcao = JogadorControle.instancia.transform.position - transform.position;
        direcao.Normalize();
        direcao = direcao * balaVel;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direcao * balaVel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("ataquei player");
            JogadorControle.instancia.ReceberDano(danoBala);
            Destroy(gameObject);
        }
        if(collision.tag == "Parede") { Destroy(gameObject); }
    }
}
