using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class TESTE : MonoBehaviour
{
    Operadores operadores;
    Funcoes funcoes;
    Parentesis parentesis;
    Complementares complementar;

    [SerializeField] int num = 30;

    float tempo = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
        operadores = GetComponent<Operadores>();
        funcoes = GetComponent<Funcoes>();
        parentesis = GetComponent<Parentesis>();
        complementar = GetComponent<Complementares>();

        
        for (int i = 0; i < num; i++)
        {
            var a = exprSUPREMA(1);

            Debug.Log("expr --> " + a);
        }
    }

    string gerarExpr(int tamanho = 1)
    {
        string expr = "";
        int qndtParAberto = 0;
        int qndtParFechado = 0;

        for (int i = 0; i < tamanho; i++)
        {
            int esc = UnityEngine.Random.Range(0, 3);
            switch(esc)
            {
                case 0:
                    expr += operadores.sinalNum() + UnityEngine.Random.Range(0, 100) + operadores.adicionarOp();
                    break;
                case 1:
                    expr += funcoes.addFunc() + parentesis.abrirPar() + gerarExpr() + parentesis.fecharPar();
                    break;
                case 2:
                    expr += 'N';
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

    public string filtrarExpr(string expr)
    {
        string aux = expr;
        foreach (string op in Operadores.operadores)
        {

            if (aux[aux.Length - 1].ToString() == op) 
            { 
                aux += complementar.Complementar1();
            }
            
            for(int k = 0; k < aux.Length-1; k++)
            {
                if (aux[k].ToString() == op && aux[k+1].ToString() == ")") 
                {
                    aux = aux.Insert(k + 1, UnityEngine.Random.Range(0, 2) == 0 ? "N" : UnityEngine.Random.Range(0, 101).ToString());
                }
            }
        }
        
        int number;
        for (int k = 0; k < aux.Length-1; k++)
        {
            if (aux[k].ToString() + aux[k +1].ToString() == ")(" || (aux[k].ToString() == "N" && aux[k + 1].ToString() == "(")) 
            { 
                aux = aux.Insert(k + 1, operadores.adicionarOp());
            }
        }

        return aux;
    }


    public string exprSUPREMA(int tamanho)
    {
        string expr = "";

        expr = gerarExpr();
        expr = filtrarExpr(expr);
        return expr;
    }


}
