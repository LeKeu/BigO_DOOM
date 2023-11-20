using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parentesis : MonoBehaviour
{
    public static List<string> parentesis = new List<string>() { "(", ")" };

    public string abrirPar() { return parentesis[0]; }
    public string fecharPar() { return parentesis[1]; }
}
