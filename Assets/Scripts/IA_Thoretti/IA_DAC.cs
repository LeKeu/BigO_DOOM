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
    public static float tempo = 0f;
    public static bool jaRespondeuAUX;

    public static bool acertou;

    [SerializeField] TextMeshProUGUI textoE;
    [SerializeField] GameObject PanelE;
    public static bool ativoE;
    [SerializeField] GameObject AperteE;

    List<string> opcComOnda = new List<string>() { "Cuidado! Onda de inimigo se aproximando!", "Mano, ta vindo uns inimigos ae!", "Tédoidé, tem uns cara vindo!", "Migo pega o beco!" };
    List<string> opcqntdBala = new List<string>() { "Cuidado! Está ficando com poucas balas!", "Ta acabando os pipocos ein!" ,"Vamo recarregar a arma, migo??", "Pelo amor de Deus pega a caixa de balas!" };
    List<string> opcqntdVida = new List<string>() { "Cuidado! Sua vida está acabando!", "Miga vamo morrer! Cura CURA!", "Ta na hora de pegar uma vidinha...", "Ó... tá mei lascadein..." };
    List<string> opcJaResp = new List<string>() { "Você tem que reponder a pergunta.", "Já respondeste a pergunta?", "Migo, bora responder a pergunta, não?" };

    public static string Dica;

    void Start()
    {
        Panel.SetActive(false);
        PanelE.SetActive(false);
        qntdBalasAUX = true; qntdVidaAUX = true; jaRespondeuAUX = true;
        Dica = "Responda a pergunta!";
    }

    void Update()
    {
        tempo += Time.deltaTime;

        qntdBalas = JogadorControle.instancia.qntdBalas;
        qntdVida = JogadorControle.instancia.vidaAtual;

        if (Input.GetKeyDown(KeyCode.E) && !Panel.activeSelf && !ativoE)
        {
            StartCoroutine("EscreverDicaE");
        }

        if (!Panel.activeSelf && !PanelE.activeSelf)
        {
            if (comecouOnda) { EscreverMensagem(0); }
            if (qntdBalas < 15 && qntdBalasAUX) { EscreverMensagem(1); }
            if (qntdVida < 30 && qntdVidaAUX) { EscreverMensagem(2); }
        }

        if (qntdBalas >= 15 || qntdVida >= 30) { Dica = "Responda a pergunta!"; } // aqui entra na vida mesmo com bala abaixo sla
        
    }
    IEnumerator EscreverDicaE()
    {
        AperteE.SetActive(false);
        PanelE.SetActive(true);
        textoE.text = Dica;
        ativoE = true;
        yield return new WaitForSeconds(5);
        PanelE.SetActive(false);
        ativoE = false;
        AperteE.SetActive(true);
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
                Dica = opcComOnda[Random.Range(0, opcComOnda.Count)];
                break;
            case 1: //qntd balas
                qntdBalasAUX = false;
                textoIA.text = opcqntdBala[Random.Range(0, opcqntdBala.Count)];
                Dica = opcqntdBala[Random.Range(0, opcqntdBala.Count)];
                break;
            case 2: //qntd vida
                qntdVidaAUX = false;
                textoIA.text = opcqntdVida[Random.Range(0, opcqntdVida.Count)];
                Dica = opcqntdVida[Random.Range(0, opcqntdVida.Count)];
                break;
            case 3:
                //jaRespondeuAUX = false;
                //textoIA.text = opcJaResp[Random.Range(0, opcJaResp.Count)];
                break;
            case 4:
                break;
        }
        yield return new WaitForSeconds(5);
        Panel.SetActive(false);

    }
}
