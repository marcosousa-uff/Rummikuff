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
            PieceMovement pm = tab[linha, i].GetComponent<PieceMovement>();
            if (tab[linha, i] == null && grupo.Count != 0)
            {
                if (!ValidarGrupo(grupo)) return false;
                grupo = new List<Deck.Carta>();
            }
            if (tab[linha, i] != null)
            {
                Deck.Carta carta = new Deck.Carta(pm.numero, pm.cor);
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

}
