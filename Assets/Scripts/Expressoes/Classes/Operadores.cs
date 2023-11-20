using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operadores : MonoBehaviour
{
    public static List<string> operadores = new List<string>() { "+", "-", "/", "*", "^" };
    public static List<string> sinal = new List<string>() { "", "-" };

    public string adicionarOp() { return operadores[Random.Range(0, operadores.Count)]; }

    public string sinalNum() { return sinal[Random.Range(0, sinal.Count)]; }
}
