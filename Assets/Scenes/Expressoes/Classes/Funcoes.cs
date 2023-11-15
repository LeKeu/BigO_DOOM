using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Funcoes : MonoBehaviour
{
    public List<string> funcs = new List<string> { "sen", "cos", "tan", "log" };

    public string addFunc() { return funcs[Random.Range(0, funcs.Count())]; }
}
