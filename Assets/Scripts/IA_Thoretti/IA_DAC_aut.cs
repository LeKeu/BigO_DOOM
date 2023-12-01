using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IA_DAC_aut : MonoBehaviour
{
    enum VariaveisBooleanas // your custom enumeration
    {
        comecouOnda,
        errou,
        acertou
    };

    enum VariaveisInteiras // your custom enumeration
    {
        qntdInimigos,
        qntdBalas
    };


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
    public static bool errou;

    [SerializeField] TextMeshProUGUI textoE;
    [SerializeField] GameObject PanelE;
    public static bool ativoE;
    [SerializeField] GameObject AperteE;

    List<string> opcComOnda = new List<string>() { "Cuidado! Onda de inimigo se aproximando!", "Mano, ta vindo uns inimigos ae!", "Tédoidé, tem uns cara vindo!", "Migo pega o beco!" };
    List<string> opcqntdBala = new List<string>() { "Cuidado! Está ficando com poucas balas!", "Ta acabando os pipocos ein!", "Vamo recarregar a arma, migo??", "Pelo amor de Deus pega a caixa de balas!" };
    List<string> opcqntdVida = new List<string>() { "Cuidado! Sua vida está acabando!", "Miga vamo morrer! Cura CURA!", "Ta na hora de pegar uma vidinha...", "Ó... tá mei lascadein..." };
    List<string> opcJaResp = new List<string>() { "Você tem que reponder a pergunta.", "Já respondeste a pergunta?", "Migo, bora responder a pergunta, não?" };
    List<string> opcDicas = new List<string>() { "Você deve responder a pergunta.", "Lembre-se, BigO é 'maior que'...", "Exemplo: f(N) é Omega de g(logN)" };

    public static string Dica;
    //=====================================
    [Header("BOOLEANOS")]
    [SerializeField] List<VariaveisBooleanas> varBoolEsc = new List<VariaveisBooleanas>();
    [SerializeField] List<string> operadBoolComparadEsc = new List<string>();   // "", "!"
    
    [Header("QUANTIDADE")]
    [SerializeField] List<VariaveisInteiras> varIntEsc = new List<VariaveisInteiras>();
    [SerializeField] List<string> operadIntComparadEsc = new List<string>();
    [SerializeField] List<int> numParaComparar = new List<int>();

    Dictionary<string, bool> DictvariaveisBool;
    Dictionary<string, int> DictvariaveisInt;

    void Start()
    {
        DictvariaveisBool = new Dictionary<string, bool>()
        {
            { "comecouOnda",  comecouOnda},
            { "errou", errou },
            { "acertou", acertou }
        };

        DictvariaveisInt = new Dictionary<string, int>()
        {
            { "qntdInimigos", qntdInimigos },
            { "qntdBalas", qntdBalas }
        };
    }

    void Update()
    {
        DictvariaveisBool["comecouOnda"] = comecouOnda;
        DictvariaveisBool["errou"] = errou;
        DictvariaveisBool["acertou"] = acertou;

        DictvariaveisInt["qntdInimigos"] = qntdInimigos;
        DictvariaveisInt["qntdBalas"] = qntdBalas;
    }

    public void Checar()
    {
        for(int i = 0; i < varBoolEsc.Count; i++)
        {
            switch (operadBoolComparadEsc[i])
            {
                case "":
                    if (DictvariaveisBool[varBoolEsc[i].ToString()])
                    {
                        Debug.Log("comecou onda");
                    }
                    break;
            }
        }
    }
}
