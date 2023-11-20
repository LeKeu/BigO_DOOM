using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Complementares : MonoBehaviour
{
    Funcoes funcoes;
    Parentesis parentesis;
    Operadores operadores;
    TESTE teste;

    public List<string> funcs = new List<string> { "sin", "cos", "tan", "log" };
    public static List<string> op = new List<string>() { "+", "-", "/", "*", "^" };

    private void Start()
    {
        operadores = GameObject.FindGameObjectWithTag("Expr").GetComponent<Operadores>();
        funcoes = GameObject.FindGameObjectWithTag("Expr").GetComponent<Funcoes>();
        parentesis = GameObject.FindGameObjectWithTag("Expr").GetComponent<Parentesis>();
        teste = GameObject.FindGameObjectWithTag("Expr").GetComponent<TESTE>();
    }

    public string Complementar1()
    {
        string expr = "";
        expr += funcs[Random.Range(0, funcs.Count())] + "(";
        expr += Random.Range(0, 2) == 0 ? "N" : Random.Range(0, 101).ToString();
        expr += ")";
        //Debug.Log("complementar --> " + expr);
        return expr;
    }

    public string filtrarExpr(string expr)
    {
        string aux = expr;
        foreach (string op in Operadores.operadores)
        {

            if (aux[aux.Length - 1].ToString() == op)
            {
                aux += Complementar1();
            }

            for (int k = 0; k < aux.Length - 1; k++)
            {
                if (aux[k].ToString() == op && aux[k + 1].ToString() == ")")
                {
                    aux = aux.Insert(k + 1, UnityEngine.Random.Range(0, 2) == 0 ? "N" : UnityEngine.Random.Range(0, 101).ToString());
                }
            }
        }

        for (int k = 0; k < aux.Length - 1; k++)
        {
            if (aux[k].ToString() + aux[k + 1].ToString() == ")(" || (aux[k].ToString() == "N" && aux[k + 1].ToString() == "("))
            {
                aux = aux.Insert(k + 1, op[Random.Range(0, op.Count)]);
            }
        }
        //aux = FuncoesUnicas(expr);
        return aux;
    }

    public string FiltragemFinal(string expr)   // ultimas checagens da expr
    {
        if (!expr.Contains("N")) { expr += Operadores.operadores[Random.Range(0, 5)] + "N"; }   // checar se falta N
        // checar se tem N
        return expr;
    }


}
