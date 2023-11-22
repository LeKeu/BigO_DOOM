using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaInimigo : MonoBehaviour
{
    [SerializeField] GameObject inimigo;
    [SerializeField] List<Transform> lugarSpawn;

    [SerializeField] int qntd_inimigo = 10;
    bool ondaStart = false;
    public bool acertou = false;

    public static string area;
    bool gerou = false;

    JogadorControle player;
    [SerializeField] porta porta;

    public static int qntdInmVivo = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorControle>();
    }

    void Update()
    {
        if(!gerou && player.respondeu) 
        {
            gerou = true;
            player.respondeu = false;
            GerarInimigo(); 
        }

        if(qntdInmVivo == 0 && ondaStart)
        {
            porta.abrirPorraPorta = true;
            ondaStart = false;
        }
    }

    public void GerarInimigo()
    {
        StartCoroutine("IEGerarInimigo");
    }

    IEnumerator IEGerarInimigo()
    {
        Debug.Log("entrei");
        Debug.Log("Nome onda: " + transform.parent.name);
        for (int i = 0; i < qntd_inimigo; i++)
        {
            Instantiate(inimigo, lugarSpawn[Random.Range(0, lugarSpawn.Count)].transform);
            qntdInmVivo++;
            ondaStart = true;
            yield return new WaitForSeconds(2f);
        }
    }
}
