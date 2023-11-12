using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(JogadorControle.instancia.transform.position, - Vector3.forward);
    }
}
