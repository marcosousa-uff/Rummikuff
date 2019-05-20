using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JogadorBase : MonoBehaviour
{
    public bool turno;
    public bool primeiraJogada;
    public bool fazendoMovimento;
    public float roundTime;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public abstract void FazMovimento();

    public abstract void ComprarPeca();

}
