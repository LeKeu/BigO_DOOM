using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstBlocoExpr : MonoBehaviour
{
    [SerializeField] List<GameObject> lugares = new List<GameObject>();
    [SerializeField] GameObject bloco;

    void Start()
    {
        for(int i = 0; i < lugares.Count; i++)
        {
            Instantiate(bloco, lugares[i].transform);
        }
    }
}
