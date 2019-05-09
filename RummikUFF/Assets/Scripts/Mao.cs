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
        for (int i = 0; i < X_SIZE; i++)
        {
            for (int y = 0; y < Y_SIZE; y++)
            {
                if(tab[y, i] == null)
                {
                    tab[y, i] = go;
                    Vector2 teste = new Vector2(((i * TILE_SIZE_X) + TILE_SIZE_X / 2) + BOARD_START_X, (TILE_SIZE_Y * Y_SIZE) - (((y * TILE_SIZE_Y) + TILE_SIZE_Y / 2)) + BOARD_START_Y);
                    go.transform.position = teste; ;
                    Debug.Log(teste);
                    i = X_SIZE + 1;
                    y = Y_SIZE + 1;
                }

            }
        }
    }
}
