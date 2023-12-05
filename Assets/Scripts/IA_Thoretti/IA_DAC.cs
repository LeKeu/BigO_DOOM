using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class IA_DAC : MonoBehaviour
{
    [Header("Var Modificaveis")]
    [SerializeField] int checarQntdBalas = 15;
    [SerializeField] int checarQntdVida = 30;

    [Header("Paineis")]
    [SerializeField] TextMeshProUGUI textoE;
    [SerializeField] GameObject PanelE;
    public static bool ativoE;
    [SerializeField] GameObject AperteE;
    [SerializeField] TextMeshProUGUI textoIA;
    [SerializeField] GameObject Panel;

    [SerializeField] static float tempoTotal = 20f;
    public static float tempo = 0f;

    public static int strike = 0;
    public static bool strikeAux;

    [SerializeField] List<string> opcComOnda = new List<string>() { "Cuidado! Onda de inimigo se aproximando!", "Mano, ta vindo uns inimigos ae!", "Tédoidé, tem uns cara vindo!", "Migo pega o beco!" };
    [SerializeField] List<string> opcqntdBala = new List<string>() { "Cuidado! Está ficando com poucas balas!", "Ta acabando os pipocos ein!" ,"Vamo recarregar a arma, migo??", "Pelo amor de Deus pega a caixa de balas!" };
    [SerializeField] List<string> opcqntdVida = new List<string>() { "Cuidado! Sua vida está acabando!", "Miga vamo morrer! Cura CURA!", "Ta na hora de pegar uma vidinha...", "Ó... tá mei lascadein..." };
    [SerializeField] List<string> opcDicas = new List<string>() { "Migo, bora responder a pergunta, não?", "Já respondeste a pergunta?", "Você tem que reponder a pergunta.", "Assintótica de N+14000 é N", "\"^N\" > \"N^\" > \"N*log\" > \"N\" > \"log\" > \"1\"", "Assintótica de 45^2 é 1." };
    [SerializeField] List<string> opcQuestoesCertasStrike = new List<string> { "Uma máquina! Você está com X perguntas certas direto!", "X Certas direto!!!" };

    public static bool comecouOnda;
    public static bool duranteOnda;
    public static int qntdInimigos;

    public static int qntdBalas;
    public static bool qntdBalasAUX;

    public static int qntdVida;
    public static bool qntdVidaAUX;

    public static bool jaRespondeu;
    public static bool jaRespondeuAUX;

    public static string Dica;

    void Start()
    {
        tempoTotal = 20f; tempo = 0f;
        comecouOnda = false; 

        Panel.SetActive(false); PanelE.SetActive(false);
        qntdBalasAUX = true; qntdVidaAUX = true; jaRespondeuAUX = true; strikeAux = true; duranteOnda = false;
        Dica = opcDicas[Random.Range(0, opcDicas.Count)];
    }

    void Update()
    {
        tempo += Time.deltaTime;

        if(tempo >= tempoTotal && !duranteOnda)
        {
            StartCoroutine("EscreverDicaE"); 
            tempo = 0; strikeAux = true;
        }

        qntdBalas = JogadorControle.instancia.qntdBalas;
        qntdVida = JogadorControle.instancia.vidaAtual;

        if (Input.GetKeyDown(KeyCode.E) && !Panel.activeSelf && !ativoE)
            StartCoroutine("EscreverDicaE");

        if (!Panel.activeSelf && !PanelE.activeSelf)
        {
            if (comecouOnda) { EscreverMensagem(0);  }
            if (qntdBalas < checarQntdBalas && qntdBalasAUX) { EscreverMensagem(1); }
            if (qntdVida < checarQntdVida && qntdVidaAUX) { EscreverMensagem(2); }
        }

        if ((qntdBalas >= checarQntdBalas) && (qntdVida >= checarQntdVida)) 
        { Dica = opcDicas[Random.Range(0, opcDicas.Count)]; } // aqui entra na vida mesmo com bala abaixo sla

        if (strike == 2 && strikeAux)
            EscreverMensagem(3);
    }
    IEnumerator EscreverDicaE()
    {
        AperteE.SetActive(false); PanelE.SetActive(true);
        textoE.text = Dica;
        ativoE = true;
        yield return new WaitForSeconds(5);
        PanelE.SetActive(false); AperteE.SetActive(true);
        ativoE = false;
    }

    void EscreverMensagem(int idT)
    { StartCoroutine("IEEscreverMensagem", idT); }
    IEnumerator IEEscreverMensagem(int idT)
    {
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
            case 3: // strikes questões certas
                strikeAux = false;
                textoIA.text = opcQuestoesCertasStrike[Random.Range(0, opcQuestoesCertasStrike.Count)].Replace("X", strike.ToString());
                break;
            case 4:
                break;
        }
        yield return new WaitForSeconds(5);
        Panel.SetActive(false);

    }
}
