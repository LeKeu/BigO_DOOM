using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calcular : MonoBehaviour
{
    TESTE teste;
    theta theta;
    Complementares complementares;
    BigO bigO;
    private void Start()
    {
        teste = GameObject.FindGameObjectWithTag("Expr").GetComponent<TESTE>();
        theta = GameObject.FindGameObjectWithTag("Expr").GetComponent<theta>();
        complementares = GameObject.FindGameObjectWithTag("Expr").GetComponent<Complementares>();
        bigO = GameObject.FindGameObjectWithTag("Expr").GetComponent<BigO>();
    }
    public char Ateste(string f, string g) // ver se existe um log na expr
    {
        char resp = 'n';
        if (f.Contains("log") && !g.Contains("log")) { resp = exprUmLog(f, g); } else if (g.Contains("log") && !f.Contains("log")) { resp = exprUmLog(g, f); }
        return resp;
    }

    public char exprUmLog(string exprCLog, string exprSLog)
    {
        // o --> exprCLog é omega de exprSLog
        if (exprSLog.Contains("^")) { return 'o'; }
        if (exprCLog.Contains("N*l")) 
        { if (exprSLog.Contains("N^")) { return 'o'; } else { return 'b'; } }
        return 'o';

    }


}
