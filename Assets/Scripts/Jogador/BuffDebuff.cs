using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDebuff : MonoBehaviour
{
    [SerializeField] JogadorControle jogadorControle;

    [SerializeField] float velAcertou;
    [SerializeField] float velErrou;
    int vidaAtual;

    float velAux;

    private void Start()
    {
        velAux = jogadorControle.vel;
    }

    public void Buff()
    {
        //jogadorControle.vidaAtual += jogadorControle.vidaAtual/2;
        jogadorControle.vel = velAcertou;
    }

    public void Debuff()
    {
        //jogadorControle.vidaAtual /= 2;
        jogadorControle.vel = velErrou;
    }

    public void Normal()
    {
        jogadorControle.vel = velAux;
    }
}
