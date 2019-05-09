using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public int estado;// 0 Mao do jogador, 1 Está no tabuleiro momentaneamente, 2 Pertence ao Tabuleiro
    public int numero;
    public int cor;
    private bool selecionado;
    public Vector2 posicaoAnterior;
    public Vector2 posicaoRound;
    // Start is called before the first frame update
    void Start()
    {
        estado = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selecionado == true)
        {
            Vector2 posicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(posicao.x, posicao.y);
        }

        if (Input.GetMouseButtonUp(0) & selecionado == true)
        {
            Vector2 posicaoAtual = transform.position;
            Board bd = GameObject.Find("Tabuleiro").GetComponent<Board>();
            Mao bdMao = GameObject.Find("Mao").GetComponent<Mao>();
            Deck tn = GameObject.Find("teste (3)").GetComponent<Deck>();

            if (tn.turno == true && transform.position.x > Board.BOARD_START_X && transform.position.x < Board.BOARD_START_X + (Board.X_SIZE * Board.TILE_SIZE_X) && transform.position.y > Board.BOARD_START_Y && transform.position.y < Board.BOARD_START_Y + (Board.Y_SIZE * Board.TILE_SIZE_Y))
            {
                posicaoAtual.x -= Board.BOARD_START_X;
                posicaoAtual.y -= Board.BOARD_START_Y;

                float posicaoX = ((int)(posicaoAtual.x / Board.TILE_SIZE_X)) * Board.TILE_SIZE_X;
                float posicaoY = ((int)(posicaoAtual.y / Board.TILE_SIZE_Y)) * Board.TILE_SIZE_Y;

                int posicaoMatrixX = (int)(posicaoX / Board.TILE_SIZE_X);
                int posicaoMatrixY = (int)(Board.Y_SIZE - (posicaoY / Board.TILE_SIZE_Y) - 1);

                if (bd.tab[posicaoMatrixY, posicaoMatrixX] == null)
                {
                    bd.tab[posicaoMatrixY, posicaoMatrixX] = gameObject;
                    if (estado == 0)
                    {

                        posicaoMatrixX = (int)(((posicaoAnterior.x - Mao.BOARD_START_X) - Mao.TILE_SIZE_X / 2) / Mao.TILE_SIZE_X);
                        posicaoMatrixY = (int)(Mao.Y_SIZE - (((posicaoAnterior.y - Mao.BOARD_START_Y) - Mao.TILE_SIZE_Y / 2) / Mao.TILE_SIZE_Y) - 1);
                        bdMao.tab[posicaoMatrixY, posicaoMatrixX] = null;
                    }
                    else
                    {
                        posicaoMatrixX = (int)(((posicaoAnterior.x - Board.BOARD_START_X) - Board.TILE_SIZE_X / 2) / Board.TILE_SIZE_X);
                        posicaoMatrixY = (int)(Board.Y_SIZE - (((posicaoAnterior.y - Board.BOARD_START_Y) - Board.TILE_SIZE_Y / 2) / Board.TILE_SIZE_Y) - 1);
                        bd.tab[posicaoMatrixY, posicaoMatrixX] = null;
                    }
                    posicaoX += Mao.TILE_SIZE_X / 2;
                    posicaoY += Mao.TILE_SIZE_Y / 2;
                    transform.position = new Vector2(posicaoX + Board.BOARD_START_X, posicaoY + Board.BOARD_START_Y);
                    estado = 1;

                }
                else
                {
                    transform.position = posicaoAnterior;
                }
            }
            else if (transform.position.x > Mao.BOARD_START_X && transform.position.x < Mao.BOARD_START_X + (Mao.X_SIZE * Mao.TILE_SIZE_X) && transform.position.y > Mao.BOARD_START_Y && transform.position.y < Mao.BOARD_START_Y + (Mao.Y_SIZE * Mao.TILE_SIZE_Y))
            {
                posicaoAtual.x -= Mao.BOARD_START_X;
                posicaoAtual.y -= Mao.BOARD_START_Y;

                float posicaoX = ((int)(posicaoAtual.x / Mao.TILE_SIZE_X)) * Mao.TILE_SIZE_X;
                float posicaoY = ((int)(posicaoAtual.y / Mao.TILE_SIZE_Y)) * Mao.TILE_SIZE_Y;

                int posicaoMatrixX = (int)(posicaoX / Mao.TILE_SIZE_X);
                int posicaoMatrixY = (int)(Mao.Y_SIZE - (posicaoY / Mao.TILE_SIZE_Y) - 1);

                if (bdMao.tab[posicaoMatrixY, posicaoMatrixX] == null)
                {
                    bdMao.tab[posicaoMatrixY, posicaoMatrixX] = gameObject;
                    if (estado == 0)
                    {
                        posicaoMatrixX = (int)(((posicaoAnterior.x - Mao.BOARD_START_X) - Mao.TILE_SIZE_X / 2) / Mao.TILE_SIZE_X);
                        posicaoMatrixY = (int)(Mao.Y_SIZE - (((posicaoAnterior.y - Mao.BOARD_START_Y) - Mao.TILE_SIZE_Y / 2) / Mao.TILE_SIZE_Y) - 1);
                        bdMao.tab[posicaoMatrixY, posicaoMatrixX] = null;
                    }
                    else
                    {
                        posicaoMatrixX = (int)(((posicaoAnterior.x - Board.BOARD_START_X) - Board.TILE_SIZE_X / 2) / Board.TILE_SIZE_X);
                        posicaoMatrixY = (int)(Board.Y_SIZE - (((posicaoAnterior.y - Board.BOARD_START_Y) - Board.TILE_SIZE_Y / 2) / Board.TILE_SIZE_Y) - 1);
                        bd.tab[posicaoMatrixY, posicaoMatrixX] = null;
                    }
                    posicaoX += Mao.TILE_SIZE_X / 2;
                    posicaoY += Mao.TILE_SIZE_Y / 2;
                    transform.position = new Vector2(posicaoX + Mao.BOARD_START_X, posicaoY +  Mao.BOARD_START_Y);
                    estado = 0;

                }
                else
                {
                    transform.position = posicaoAnterior;
                }

            }
            else
            {
                transform.position = posicaoAnterior;
            }

            if (Input.GetMouseButtonUp(0))
            {
                selecionado = false;
            }

        }
    }
    void OnMouseOver()
    {
       if (Input.GetMouseButtonDown(0))
       {
            Deck tn = GameObject.Find("teste (3)").GetComponent<Deck>();
            if (tn.turno == false & transform.position.x > Board.BOARD_START_X & transform.position.x < Board.BOARD_START_X + (Board.X_SIZE * Board.TILE_SIZE_X) & transform.position.y > Board.BOARD_START_Y & transform.position.y < Board.BOARD_START_Y + (Board.Y_SIZE * Board.TILE_SIZE_Y))
            {
                selecionado = false;

            }
            else
            {
                selecionado = true;
                posicaoAnterior = transform.position;
            } 
                
       }
    }
}

