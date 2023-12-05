using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaInimigo : MonoBehaviour
{
    [SerializeField] float segundos = 1f;
    [SerializeField] GameObject inimigo;
    [SerializeField] List<Transform> lugarSpawn;

    [SerializeField] int qntd_inimigo = 10;
    bool ondaStart = false;
    public bool acertou = false;

    bool gerou = false;

    JogadorControle player;
    [SerializeField] porta porta;

    public static int qntdInmVivo = 0;

    private void Start()
    {
        qntdInmVivo = qntd_inimigo;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorControle>();
    }

    void Update()
    {
        //qntdInmVivo = qntd_inimigo;
        if (!gerou && player.respondeu) 
        {
            gerou = true;
            player.respondeu = false;
            GerarInimigo(); 
        }

        if(qntdInmVivo == 0 && ondaStart)
        {
            Debug.Log("abrir porta, inimigosVivos = "+qntdInmVivo);
            porta.abrirPorraPorta = true;
            IA_DAC.duranteOnda = false;
            ondaStart = false;
        }
    }

    public void GerarInimigo()
    {
        qntdInmVivo = qntd_inimigo;
        IA_DAC.comecouOnda = true;
        StartCoroutine("IEGerarInimigo");
    }

    IEnumerator IEGerarInimigo()
    {
        IA_DAC.duranteOnda = true;
        for (int i = 0; i < qntd_inimigo; i++)
        {
            porta.abrirPorraPorta = false;
            Instantiate(inimigo, lugarSpawn[Random.Range(0, lugarSpawn.Count)].transform);
            //qntdInmVivo++;
            ondaStart = true;
            yield return new WaitForSeconds(segundos);
        }
    }
}
