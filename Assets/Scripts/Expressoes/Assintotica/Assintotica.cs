using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Assintotica : MonoBehaviour
{
    
    public static string checarAssintotica(string f)
    {
        //List<string> assints = new List<string>() { "^N", "N^", "N*log", "log" };
        List<string> assints = new List<string>() { "^N", "^(N", "N^", "N)^", "N*log", "N)*log", "N*(log", "N)*(log", "N", "log", "1" };
        string aux = "";
        foreach (var assint in assints)
        {
            if (f.Contains(assint))
            {
                aux = assint; break;
            } 
        }
        Debug.Log(aux);
        if (aux.Contains("("))
            aux = aux.Replace("(", "");
        if (aux.Contains(")"))
            aux = aux.Replace(")", "");
        Debug.Log(aux);

        return aux;
    }
}
