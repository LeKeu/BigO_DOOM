using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_GPT : MonoBehaviour
{
    [SerializeField] GameObject PainelPerguntas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PainelPerguntas.activeSelf);
        if (Input.GetKeyDown(KeyCode.X))
        {
            PainelPerguntas.SetActive(true);
        }

    }
}
