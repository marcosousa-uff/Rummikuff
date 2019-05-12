using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public const float TILE_SIZE_X = 1.0f;
    public const float TILE_SIZE_Y = 2.0f;
    public const float BOARD_START_X = 0;
    public const float BOARD_START_Y = 0;
    public const int Y_SIZE = 8;
    public const int X_SIZE = 23;
    public GameObject[,] tab;

    // Start is called before the first frame update
    void Start()
    {
        tab = new GameObject[8, 23];
        for (int i = 0; i < X_SIZE; i++)
        {
            for (int y = 0; y < Y_SIZE; y++)
            {
                tab[y, i] = null;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private bool ValidarGrupo(List<Deck.Carta> grupo)
    {
        return false;
    }

    private bool ValidarLinha(int linha)
    {
        List<Deck.Carta> grupo = new List<Deck.Carta>();
        for (int i = 0; i < X_SIZE; i++)
        {
            Peca pm = tab[linha, i].GetComponent<Peca>();
            if (tab[linha, i] == null && grupo.Count != 0)
            {
                if (!ValidarGrupo(grupo)) return false;
                grupo = new List<Deck.Carta>();
            }
            if (tab[linha, i] != null)
            {
                Deck.Carta carta = new Deck.Carta(pm.Numero, pm.Cor);
                grupo.Add(carta);
            }

        }
        if (!ValidarGrupo(grupo)) return false;
        return true;
    }

    public bool ValidarTabuleiro()
    {
        return false;
    }

    public void OrganizarTabuleio()
    {

    }

    public Vector2Int PosicaoMatriz(Vector2 posicao)
    {
        int posicaoMatrixX = (int)((posicao.x - BOARD_START_X - (TILE_SIZE_X / 2)) / TILE_SIZE_X);
        int posicaoMatrixY = (int)(Y_SIZE - ((posicao.y - BOARD_START_Y - (TILE_SIZE_Y / 2)) / TILE_SIZE_Y) - 1);

        return new Vector2Int(posicaoMatrixX, posicaoMatrixY);
    }

    public Vector2 PosicaoCelula(Vector2 posicaoAtual)
    {
        posicaoAtual.x -= BOARD_START_X;
        posicaoAtual.y -= BOARD_START_Y;

        float posicaoX = ((int)((posicaoAtual.x / TILE_SIZE_X)) * TILE_SIZE_X) + TILE_SIZE_X / 2;
        float posicaoY = ((int)((posicaoAtual.y / TILE_SIZE_Y)) * TILE_SIZE_Y) + TILE_SIZE_Y / 2;

        posicaoX += BOARD_START_X;
        posicaoY += BOARD_START_Y;

        return new Vector2(posicaoX, posicaoY);
    }

}
