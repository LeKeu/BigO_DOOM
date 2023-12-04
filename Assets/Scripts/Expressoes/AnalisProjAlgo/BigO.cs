using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigO : MonoBehaviour
{
    public bool checarBigO(string f, string g)
    {
        int c = 1000;
        bool ehMaior = false;
        int vezesMaior = 0;
        string auxF = f, auxG = g;
        /*
        for(int i = 1; i < 1000; i++)
        {
            f = auxF;
            g = auxG;

            f = f.Replace("N", i.ToString());
            g = g.Contains("*" + c.ToString()) ? g.Replace("N", i.ToString()) : g.Replace("N", i.ToString()) + "*" + c.ToString();

            UnityEditor.ExpressionEvaluator.Evaluate(f, out float resultF);
            UnityEditor.ExpressionEvaluator.Evaluate(g, out float resultG);

            if(resultG > resultF) { ehMaior = true; vezesMaior++; } else { ehMaior = false;}
        }
        */
        if(ehMaior)
        {
            return true;
        }
        return false;
    }
}
