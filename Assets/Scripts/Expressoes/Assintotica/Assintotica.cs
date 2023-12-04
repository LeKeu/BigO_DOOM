using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Assintotica : MonoBehaviour
{
    
    public static string checarAssintotica(string f)
    {
        List<string> assints = new List<string>() { "^N", "N^", "N*log", "log" };
        foreach (var assint in assints)
        {
            if (f.Contains(assint))
            {
                Debug.Log("---"+assint);
                return assint;
            } 
        }
        return f.Contains("N") ? "N" : "1";
    }
}
