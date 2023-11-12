using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
    [SerializeField] Transform portaModelo;
    [SerializeField] GameObject colObject;

    [SerializeField] float abrirVel;

    bool podeAbrir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(podeAbrir && portaModelo.position.z != 1f)
        {
            portaModelo.position = Vector3.MoveTowards(portaModelo.position, new Vector3(portaModelo.position.x, portaModelo.position.y, 1f), abrirVel * Time.deltaTime);
        
            if(portaModelo.position.z == 1f)
            {
                colObject.SetActive(false);
            }
        }

        if (!podeAbrir && portaModelo.position.z != 0f)
        {
            portaModelo.position = Vector3.MoveTowards(portaModelo.position, new Vector3(portaModelo.position.x, portaModelo.position.y, 0f), abrirVel * Time.deltaTime);

            if (portaModelo.position.z == 0f)
            {
                colObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            podeAbrir = true;
            //colObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            podeAbrir = false;
            //colObject.SetActive(true);
        }
    }
}
