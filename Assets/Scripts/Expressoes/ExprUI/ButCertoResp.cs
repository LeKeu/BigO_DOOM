using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using TMPro;

public class ButCertoResp : MonoBehaviour
{
    [SerializeField] List<GameObject> butOpcs = new List<GameObject>();
    List<string> OpcsTxt = new List<string>() { "BigO", "Omega" };
    [SerializeField] GameObject exprTxt;

    TESTE Expr;
    Calcular calcular;
    BigO bigO;
    Omega omega;
    Complementares complementar;
    Funcoes funcoes;

    [SerializeField] GameObject exprGO;

    bool b = false;
    bool o = false;
    public char resp;

    private void Awake()
    {
        Expr = exprGO.GetComponent<TESTE>();
        calcular = exprGO.GetComponent<Calcular>();
        bigO = exprGO.GetComponent<BigO>();
        omega = exprGO.GetComponent<Omega>();
        complementar = exprGO.GetComponent<Complementares>();
        funcoes = exprGO.GetComponent<Funcoes>();
    }

    private void Start()
    { // FALTA CHECAR EM RELAÇÃO A LOG
        string f = Expr.exprSUPREMA(1);
        string g = Expr.exprSUPREMA(1);

        f = complementar.FiltragemFinal(f);
        g = complementar.FiltragemFinal(g);

        char t = calcular.Ateste(f, g);
        //Debug.Log("char --> " + t);

        b = bigO.checarBigO(f, g);
        o = omega.checarOmega(f, g);

        Debug.Log(f + " <--> " + g);

        if (b) { Debug.Log("f(" + f + ") é BigO de g(" + g + ")."); resp = 'b'; }
        if (o) { Debug.Log("f(" + f + ") é Omega de g(" + g + ")."); resp = 'o'; }
        Debug.Log("===========================");

        LugarAleResp(f, g, resp);
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


}
