using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using TMPro;

public class ButCertoResp : MonoBehaviour
{
    [SerializeField] List<GameObject> butOpcs = new List<GameObject>();
    List<string> OpcsTxt = new List<string>() { "BigO", "Omega" };
    List<string> OpcsAssint = new List<string>() { "^N", "N^", "N*log", "N", "log", "1" };
    [SerializeField] GameObject exprTxt;

    TESTE Expr;
    Calcular calcular;
    BigO bigO;
    Omega omega;
    Complementares complementar;
    Funcoes funcoes;

    GameObject exprGO;

    bool b = false;
    bool o = false;
    public char resp;
    public string respAssint;
    public string erradaAssint;

    private void Awake()
    {
        exprGO = GameObject.FindGameObjectWithTag("Expr");

        Expr = exprGO.GetComponent<TESTE>();
        calcular = exprGO.GetComponent<Calcular>();
        bigO = exprGO.GetComponent<BigO>();
        omega = exprGO.GetComponent<Omega>();
        complementar = exprGO.GetComponent<Complementares>();
        funcoes = exprGO.GetComponent<Funcoes>();
    }

    private void Start()
    { // FALTA CHECAR EM RELAÇÃO A LOG
        var exprs = Gerar();
        string f = exprs[0].ToString();
        string g = exprs[1].ToString();
        respAssint = Assintotica.checarAssintotica(f);
        LugarAleRespAssint(f, respAssint);
        //LugarAleResp(f, g, resp);
    }

    public List<string> Gerar()
    {
        string f = Expr.exprSUPREMA(1);
        string g = Expr.exprSUPREMA(1);

        f = complementar.FiltragemFinal(f);
        g = complementar.FiltragemFinal(g);

        char t = calcular.Ateste(f, g);
        //Debug.Log("char --> " + t);

        b = bigO.checarBigO(f, g);
        o = omega.checarOmega(f, g);

        /*
        if((!b && o!) || (f.Contains("log") && g.Contains("log"))) { Gerar(); }
        if (f.Contains("log") && !g.Contains("log")) { Debug.Log("f(" + f + ") é BigO de g(" + g + ")."); resp = 'b'; } 
        else if (!f.Contains("log") && g.Contains("log")) { Debug.Log("f(" + f + ") é Omega de g(" + g + ")."); resp = 'o'; }
        else
        {
            if (b) { Debug.Log("f(" + f + ") é BigO de g(" + g + ")."); resp = 'b'; }
            if (o) { Debug.Log("f(" + f + ") é Omega de g(" + g + ")."); resp = 'o'; }
        }

        Debug.Log(f + " <--> " + g);
        Debug.Log("===========================");
        */
        return new List<string> { f, g };
    }

    public void LugarAleResp(string f, string g, char resp)
    {
        int indexOpc = Random.Range(0, 2);
        int indexTxt = Random.Range(0, 2);

        this.exprTxt.GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>().text = "f(" + f + ") é _ de g(" + g + ")";

        this.butOpcs[indexOpc].GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>().text = this.OpcsTxt[indexTxt];
        this.butOpcs[indexOpc].transform.tag = this.OpcsTxt[indexTxt];

        if (indexOpc == 1) { indexOpc = 0; } else { indexOpc = 1; }
        if (indexTxt == 1) { indexTxt = 0; } else { indexTxt = 1; }

        this.butOpcs[indexOpc].GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>().text = this.OpcsTxt[indexTxt];
        this.butOpcs[indexOpc].transform.tag = this.OpcsTxt[indexTxt];
    }

    public void LugarAleRespAssint(string f, string resp)
    {
        int posAux = 0;
        for(int i = 0; i < OpcsAssint.Count; i++)
        {
            if (OpcsAssint[i] == resp)
            {
                posAux = i; erradaAssint = OpcsAssint[i]; break;
            }
        }

        int indexOpc = Random.Range(0, 2);
        this.exprTxt.GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>().text = "Assintótica de: f(" + f + ")";

        this.butOpcs[indexOpc].GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>().text = this.OpcsAssint[posAux];
        this.butOpcs[indexOpc].transform.tag = this.OpcsAssint[posAux];

        if (indexOpc == 1) { indexOpc = 0; } else { indexOpc = 1; }

        List<int> listOpcErrada = new List<int>() { 0, 1, 2, 3, 4, 5 };
        listOpcErrada.RemoveAt(posAux);
        int indexOpcErrada = Random.Range(0, 5);

        this.butOpcs[indexOpc].GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>().text = this.OpcsAssint[indexOpcErrada];
        this.butOpcs[indexOpc].transform.tag = this.OpcsAssint[indexOpcErrada];
    }


}
