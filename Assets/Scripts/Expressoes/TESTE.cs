using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class TESTE : MonoBehaviour
{
    Operadores operadores;
    Funcoes funcoes;
    Parentesis parentesis;
    Complementares complementar;
    theta theta;
    Calcular calcular;
    BigO bigO;
    Omega omega;

    string f;
    string g;

    private void Awake()
    {
        operadores = GameObject.FindGameObjectWithTag("Expr").GetComponent<Operadores>();
        funcoes = GameObject.FindGameObjectWithTag("Expr").GetComponent<Funcoes>();
        parentesis = GameObject.FindGameObjectWithTag("Expr").GetComponent<Parentesis>();
        complementar = GameObject.FindGameObjectWithTag("Expr").GetComponent<Complementares>();
        theta = GameObject.FindGameObjectWithTag("Expr").GetComponent<theta>();
        calcular = GameObject.FindGameObjectWithTag("Expr").GetComponent<Calcular>();
        bigO = GameObject.FindGameObjectWithTag("Expr").GetComponent<BigO>();
        omega = GameObject.FindGameObjectWithTag("Expr").GetComponent<Omega>();
    }

    public List<string> CriarExpr()
    {
        bool b = false, o = false;
        while (!b || !o)
        {
            Debug.Log("hi");
            f = exprSUPREMA(1);
            g = exprSUPREMA(1);

            f = complementar.FiltragemFinal(f);
            g = complementar.FiltragemFinal(g);

            //char t = calcular.Ateste(f, g);
            //Debug.Log("char --> " + t);

            //bool t = theta.checarTheta(f, g);
            b = bigO.checarBigO(f, g);
            o = omega.checarOmega(f, g);

            //if (t) { Debug.Log("f(" + f + ") é Theta de g(" + g + ")."); }
            if (b) { Debug.Log("f(" + f + ") é BigO de g(" + g + ")."); }
            if (o) { Debug.Log("f(" + f + ") é Omega de g(" + g + ")."); }
            Debug.Log("===========================");
        }
        
        return new List<string> { f, g };

    }

    public string gerarExpr(int tamanho = 1)
    {
        string expr = "";
        int qndtParAberto = 0;
        int qndtParFechado = 0;
        bool temFunc = false, temN = false, temNum = false;

        for (int i = 0; i < tamanho; i++)
        {
            int esc = UnityEngine.Random.Range(0, 3);
            switch(esc)
            {
                case 0:
                    if (!temNum) { expr += operadores.sinalNum() + UnityEngine.Random.Range(1, 100) + operadores.adicionarOp(); temNum = false; }
                    break;
                case 1:
                    if(!temFunc) { expr += funcoes.addFunc() + parentesis.abrirPar() + gerarExpr() + parentesis.fecharPar(); temFunc = true; }
                    break;
                case 2:
                    if (!temN) { expr += 'N'; temN = true; }
                    break;
                default:
                    Debug.Log("erro no switch case miga");
                    break;
            }

            bool par = false;
            int parAux = UnityEngine.Random.Range(0, 2);

            if (parAux == 0 && !par)
            {
                expr += parentesis.abrirPar() + gerarExpr(tamanho);
                par = true;
                qndtParAberto++;
            }
            if (parAux != 0 && par)
            {
                expr += parentesis.fecharPar();
                par = false;
                qndtParFechado++;
            }
        }

        if (qndtParAberto != qndtParFechado) { expr += parentesis.fecharPar(); }
        return expr.Length <= 20 ? expr : gerarExpr();
    }

    public string exprSUPREMA(int tamanho)
    {
        string expr = "";

        expr = gerarExpr();
        expr = complementar.filtrarExpr(expr);
        return expr;
    }
}
