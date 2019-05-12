using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorIA : JogadorBase
{
    public List<GameObject> lista;
    public List<Deck.Carta> cartas;
    public bool primeiraJogada;
    // Start is called before the first frame update
    void Start()
    {
        primeiraJogada = false;
        lista = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void FazMovimento()
    {

    }

    public override void ComprarPeca()
    {
        Deck deck = GameObject.Find("Deck").GetComponent<Deck>();
        GameObject go = deck.ComprarCard();
        go.transform.position = new Vector2(-10, 10);
        lista.Add(go);
    }
}
