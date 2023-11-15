using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complementares : MonoBehaviour
{
    Funcoes funcoes;
    Parentesis parentesis;
    Operadores operadores;

    private void Start()
    {
        operadores = GetComponent<Operadores>();
        funcoes = GetComponent<Funcoes>();
        parentesis = GetComponent<Parentesis>();
    }

    public string Complementar1()
    {
        string expr = "";
        expr += funcoes.addFunc() + parentesis.abrirPar();
        expr += Random.Range(0, 2) == 0 ? "n" : Random.Range(0, 101).ToString();
        expr += parentesis.fecharPar();

        return expr;
    }

    public string ComplementarEntrePar(string expr, int index)
    {

        string antes = "";
        string depois = "";

        for (int i = 0; i < index; i++) { antes += expr[i]; }

        for (int i = index; i < expr.Length; i++) { depois += expr[i]; }

        antes += operadores.adicionarOp();

        Debug.Log("EXPR: " + expr);
        Debug.Log("ANTES: " + antes);
        Debug.Log("DEPOIS: " + depois);

        return antes + depois;
    }

    /*
    public string ComplementarOpPar(string expr, int index)
    {

        string antes = "";
        string depois = "";

        for (int i = 0; i < index; i++) { antes += expr[i]; }

        for (int i = index; i < expr.Length; i++) { depois += expr[i]; }

        antes += Random.Range(0, 2) == 0 ? "n" : Random.Range(0, 101).ToString();

        Debug.Log("EXPR: " + expr);
        Debug.Log("ANTES: " + antes);
        Debug.Log("DEPOIS: " + depois);

        return antes + depois;
    }
    */

    /*
     public string Complementar0(string expr, int index, char operacao)
    {
        
        char operacao p --> adicionar op entre par
        char operacao c --> complementar caso tenha op seguido de )
         
        //string[] texto = "1;2;3;4;5".Split(";");

        string antes = "";
        string depois = "";
        for (int i = 0; i < index; i++) { antes += expr[i]; }
        for (int i = index; i < expr.Length; i++) { depois += expr[i]; }

        if (operacao == 'p')
        {
            antes += Random.Range(0, 2) == 0 ? "n" : Random.Range(0, 101).ToString();
        }
        else if (operacao == 'c')
        {
            antes += operadores.adicionarOp();
        }

        Debug.Log("EXPR: " + expr);
        Debug.Log("ANTES: " + antes);
        Debug.Log("DEPOIS: " + depois);

        return antes + depois;
    }
     */

}
