using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogo : MonoBehaviour
{
    // Start is called before the first frame update
    public List<JogadorIA> jogadoresIA;
    public JogadorHumano jogador;
    public bool dist = true;

    void Start()
    {
        jogadoresIA = new List<JogadorIA>();
        for(int i = 0; i < 3; i++)
        {
            JogadorIA ia = gameObject.AddComponent<JogadorIA>();
            jogadoresIA.Add(ia);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dist)
        {
            DistribuiCartas();
            dist = false;
        }
    }

    public void DistribuiCartas()
    {
        JogadorHumano jogador = GameObject.Find("JogadorHumano").GetComponent<JogadorHumano>();
        Deck deck = GameObject.Find("Deck").GetComponent<Deck>();

        for (int i = 0; i < 14; i++)
        {
            jogador.ComprarPeca();
            for (int j = 0; j < 3; j++)
            {
                jogadoresIA[0].ComprarPeca();
            }
        }
    }
}
