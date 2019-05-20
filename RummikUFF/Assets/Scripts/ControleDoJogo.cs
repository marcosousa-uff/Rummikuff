using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogo : MonoBehaviour
{
    // Start is called before the first frame update
    public List<JogadorIA> jogadoresIA;
    public JogadorHumano jogador;
    public bool dist = true;
    public List<JogadorBase> todosJogadores;
    public JogadorBase jogadorAtual;
    public float tempoInicio;

    void Start()
    {
        jogador = GameObject.Find("JogadorHumano").GetComponent<JogadorHumano>();
        todosJogadores.Add(jogador);
        jogadoresIA = new List<JogadorIA>();
        for(int i = 0; i < 3; i++)
        {
            JogadorIA ia = gameObject.AddComponent<JogadorIA>();
            jogadoresIA.Add(ia);
            todosJogadores.Add(ia);
        }
        jogadorAtual = todosJogadores[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (dist)
        {
            DistribuiCartas();
            dist = false;
        }

        if (GameNotEnded())
        {
            if(jogadorAtual.turno == false && jogadorAtual.fazendoMovimento == false)//turno iniciou nesse frame
            {
                tempoInicio = Time.time;
                jogadorAtual.turno = true;
                jogadorAtual.FazMovimento();
            }
            else if (jogadorAtual.turno == true && jogadorAtual.fazendoMovimento == false)// turno finalizou nesse frame
            {
                // Valida tabuleiro, caso negativo devolve peças pro jogador e verifica se ele já comprou do Deck. Caso positivo, atualiza a posInicioRound das peças e seta o estado=2;
                // Testa condição de vitória, caso negativo passa pro próximo jogador. 
                jogadorAtual.turno = false;
                ProximoJogador();
            }
            else if(jogadorAtual.turno == true && jogadorAtual.fazendoMovimento == true)// turno está em andamento nesse frame 
            {
                if((Time.time - tempoInicio) > jogadorAtual.roundTime)
                {
                    jogadorAtual.fazendoMovimento = false;
                }
                //Atualiza alguma indicação de tempo mostrada ao usuário.               
            }
            else if(jogadorAtual.turno == false && jogadorAtual.fazendoMovimento == true)// não faz sentido
            {

            }                 
        }

    }

    private bool GameNotEnded()
    {
        return true;
    }

    public void DistribuiCartas()
    {
        JogadorHumano jogador = GameObject.Find("JogadorHumano").GetComponent<JogadorHumano>();

        for (int i = 0; i < 14; i++)
        {
            for (int j = 0; j < todosJogadores.Count; j++)
            {
                todosJogadores[j].ComprarPeca();
            }
        }
    }

    private void ProximoJogador()
    {
        int posAtual = todosJogadores.IndexOf(jogadorAtual);
        jogadorAtual = todosJogadores[(posAtual + 1) % todosJogadores.Count];
    }
}
