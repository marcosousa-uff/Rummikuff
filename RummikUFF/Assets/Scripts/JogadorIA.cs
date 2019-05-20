using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorIA : JogadorBase
{
    public List<Deck.Carta> cartas;
    // Start is called before the first frame update
    void Start()
    {
        primeiraJogada = false;
        turno = false;
        fazendoMovimento = false;
        cartas = new List<Deck.Carta>();
        roundTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void FazMovimento()
    {
        fazendoMovimento = true;

    }

    public override void ComprarPeca()
    {
        Deck deck = GameObject.Find("Deck").GetComponent<Deck>();
        Deck.Carta carta = deck.ComprarCardIA();
        cartas.Add(carta);
    }
}
