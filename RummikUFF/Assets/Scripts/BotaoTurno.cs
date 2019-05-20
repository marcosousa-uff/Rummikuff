using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoTurno : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        JogadorHumano jogador = GameObject.Find("JogadorHumano").GetComponent<JogadorHumano>();
        if (jogador.turno && Input.GetMouseButtonDown(0))
        {
            /*
            Board board = GameObject.Find("Tabuleiro").GetComponent<Board>();
            if (board.ValidarTabuleiro())
            {
                jogador.fazendoMovimento = true;
            }
            else
            {
                // Mostra ao jogador que tem algo de errado. 
            }
            */
           jogador.fazendoMovimento = false;
        }
    }


}
