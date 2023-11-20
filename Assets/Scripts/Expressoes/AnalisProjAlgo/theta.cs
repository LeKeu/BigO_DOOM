using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class theta : MonoBehaviour
{
    public bool checarTheta(string f, string g)
    {
        if ((f.Contains("^") && !g.Contains("^")) || (!f.Contains("^") && g.Contains("^"))
            || (f.Contains("log") && !g.Contains("log")) || (!f.Contains("log") && g.Contains("log"))) { return false; }

        if(f.Contains("^") && g.Contains("^")) { naoSei("9 * (16 ^ 34) - N", g); }

        return true;
    }

    public bool assintoticaTheta(string expr, string op)
    {
        if (expr.Contains(op)) { return true; }
        return false;
    }

    public void naoSei(string f, string g)
    {
        int parAberto = 1, parFechado = 0, indexf = f.IndexOf("^");
        string e = "";
        switch (f[indexf + 1])
        {
            case '(':
                for (int i = indexf+2; i < f.Length; i++)
                {
                    if (f[i] == '(' && i != indexf+1) { parAberto++; }
                    if (f[i] == ')') { parFechado++; }
                    if (parAberto == parFechado) { break; }
                    e += f[i];
                }
                Debug.Log(f+" case par "+e);
                break;
            case 'N': e = "N";
                Debug.Log(f + " case N " +e);
                break;
            default:
                Debug.Log(f + " pqp " + e);
                for (int k = indexf+2; k < f.Length; k++)
                { if (int.TryParse(f[k].ToString(), out _)) { e += f[k]; Debug.Log(f+"mero: " + f[k]); } else { break; } }
                Debug.Log(f + " case Num " + e);
                
                break;
        }
        
        
    }
}
