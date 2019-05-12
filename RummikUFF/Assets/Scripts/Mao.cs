using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mao : MonoBehaviour
{
    public const float TILE_SIZE_X = 1.0f;
    public const float TILE_SIZE_Y = 2.0f;
    public const float BOARD_START_X = 0;
    public const float BOARD_START_Y = -4;
    public const int Y_SIZE = 2;
    public const int X_SIZE = 23;
    public GameObject[,] tab;

    // Start is called before the first frame update
    void Start()
    {
        tab = new GameObject[Y_SIZE, X_SIZE];
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

    public void AdicionarPeca(GameObject go)
    {
        for (int y = 0; y < Y_SIZE; y++)
        {
            for (int i = 0; i < X_SIZE; i++)
            {
                if(tab[y, i] == null)
                {
                    Peca peca = go.GetComponent<Peca>();
                    peca.estado = 0;
                    tab[y, i] = go;
                    Vector2 pos = new Vector2(((i * TILE_SIZE_X) + TILE_SIZE_X / 2) + BOARD_START_X, (TILE_SIZE_Y * Y_SIZE) - (((y * TILE_SIZE_Y) + TILE_SIZE_Y / 2)) + BOARD_START_Y);
                    go.transform.position = pos;
                    i = X_SIZE + 1;
                    y = Y_SIZE + 1;
                }
            }
        }
    }

    public Vector2Int PosicaoMatriz(Vector2 posicao)// Só funciona se passar como parâmetro o resultado do PosicaoCelula
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
