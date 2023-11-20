using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
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
        /*
        System.Data.DataTable table = new System.Data.DataTable();
        
        int parAberto = 1;
        int parFechado = 0;
        int index = exprCLog.IndexOf("g");
        string log = "";
        for (int i = index+2; i < exprCLog.Length; i++)
        {
            if (exprCLog[i] == '(' && i != index+2) { parAberto++; }
            if (exprCLog[i] == ')') { parFechado++; }
            if (parAberto == parFechado) { break; }
            log += exprCLog[i];
        }

        Debug.Log("EXPR MAN " + exprCLog);
        Debug.Log("LOG MAN "+log);
        double d = (double)table.Compute(log, null);
        Debug.Log("CARA "+d);
        */
    }


}
