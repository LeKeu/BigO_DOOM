using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class IA_DAC : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoIA;
    [SerializeField] GameObject Panel;

    public static bool comecouOnda;
    public static int qntdInimigos;

    public static int qntdBalas;
    public static bool qntdBalasAUX;

    public static int qntdVida;
    public static bool qntdVidaAUX;

    public static bool jaRespondeu;

    public static bool acertou;

    List<string> opcComOnda = new List<string>() { "Cuidado! Onda de inimigo se aproximando!", "Mano, ta vindo uns inimigos ae!", "Tédoidé, tem uns cara vindo!", "Migo pega o beco!" };
    List<string> opcqntdBala = new List<string>() { "Cuidado! Está ficando com poucas balas!", "Ta acabando os pipocos ein!" ,"Vamo recarregar a arma, migo??", "Pelo amor de Deus pega a caixa de balas!" };
    List<string> opcqntdVida = new List<string>() { "Cuidado! Sua vida está acabando!", "Miga vamo morrer! Cura CURA!", "Ta na hora de pegar uma vidinha...", "Ó... tá mei lascadein..." };

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        Panel.SetActive(false);
        qntdBalasAUX = true; qntdVidaAUX = true;
    }

    // Update is called once per frame
    void Update()
    {
        qntdBalas = JogadorControle.instancia.qntdBalas;
        qntdVida = JogadorControle.instancia.vidaAtual;

        if (!Panel.activeSelf)
        {
            if (comecouOnda) { EscreverMensagem(0); }
            if (qntdBalas < 15 && qntdBalasAUX) { EscreverMensagem(1); }
            if (qntdVida < 30 && qntdVidaAUX) { EscreverMensagem(2); }
        }
        
    }

    void EscreverMensagem(int idT)
    {
        Debug.Log("escrever");
        StartCoroutine("IEEscreverMensagem", idT);
    }
    IEnumerator IEEscreverMensagem(int idT)
    {
        Debug.Log("IA " + idT);
        Panel.SetActive(true);
        switch (idT)
        {
            case 0: //comecou onda
                comecouOnda = false;
                textoIA.text = opcComOnda[Random.Range(0, opcComOnda.Count)];
                break;
            case 1: //qntd balas
                qntdBalasAUX = false;
                textoIA.text = opcqntdBala[Random.Range(0, opcqntdBala.Count)];
                break;
            case 2: //qntd vida
                qntdVidaAUX = false;
                textoIA.text = opcqntdVida[Random.Range(0, opcqntdVida.Count)];
                break;
            case 3:
                break;
        }
        yield return new WaitForSeconds(5);
        Panel.SetActive(false);

    }
}
