using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorHumano : JogadorBase
{
    // Start is called before the first frame update
    private Mao mao;
    public bool turno;
    private GameObject pecaSelecionada;

    void Start()
    {
        mao = GameObject.Find("Mao").GetComponent<Mao>();
        turno = false;
        pecaSelecionada = null;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoPecas();
    }

    public override void FazMovimento()
    {
        turno = true;
    }

    public override void ComprarPeca()
    {
        Deck deck = GameObject.Find("Deck").GetComponent<Deck>();
        GameObject go = deck.ComprarCard();
        mao.AdicionarPeca(go);
    }

    public void MovimentoPecas()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ray.direction = new Vector3(1.0f, 0, 0);

            if (Physics2D.Raycast(ray.origin, ray.direction, 0.1f))
            {
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 0.1f);
                GameObject go = hit.collider.gameObject;
                if (go.tag == "piece")
                {
                    pecaSelecionada = go;
                    Peca peca = pecaSelecionada.GetComponent<Peca>();
                    peca.posicaoAnterior = go.transform.position;
                }
            }
        }

        if (pecaSelecionada != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Peca peca = pecaSelecionada.GetComponent<Peca>();
                Vector2 posicaoAtual = pecaSelecionada.transform.position;
                Board board = GameObject.Find("Tabuleiro").GetComponent<Board>();
                Mao mao = GameObject.Find("Mao").GetComponent<Mao>();
                Deck tn = GameObject.Find("Deck").GetComponent<Deck>();

                if (turno == true && posicaoAtual.x > Board.BOARD_START_X && posicaoAtual.x < Board.BOARD_START_X + (Board.X_SIZE * Board.TILE_SIZE_X) && posicaoAtual.y > Board.BOARD_START_Y && posicaoAtual.y < Board.BOARD_START_Y + (Board.Y_SIZE * Board.TILE_SIZE_Y))
                {
                    Vector2 posicao = board.PosicaoCelula(posicaoAtual);
                    Vector2Int posicaoMatriz = board.PosicaoMatriz(posicao);

                    if (board.tab[posicaoMatriz.y, posicaoMatriz.x] == null)
                    {
                        board.tab[posicaoMatriz.y, posicaoMatriz.x] = gameObject;
                        if (peca.estado == 0)
                        {
                            posicaoMatriz = mao.PosicaoMatriz(peca.posicaoAnterior);
                            mao.tab[posicaoMatriz.y, posicaoMatriz.x] = null;
                        }
                        else
                        {
                            posicaoMatriz = board.PosicaoMatriz(peca.posicaoAnterior);
                            board.tab[posicaoMatriz.y, posicaoMatriz.x] = null;
                        }
                        pecaSelecionada.transform.position = new Vector2(posicao.x, posicao.y);
                        peca.estado = 1;

                    }
                    else
                    {
                        pecaSelecionada.transform.position = peca.posicaoAnterior;
                    }
                }
                else if (peca.estado != 2 && posicaoAtual.x > Mao.BOARD_START_X && posicaoAtual.x < Mao.BOARD_START_X + (Mao.X_SIZE * Mao.TILE_SIZE_X) && posicaoAtual.y > Mao.BOARD_START_Y && posicaoAtual.y < Mao.BOARD_START_Y + (Mao.Y_SIZE * Mao.TILE_SIZE_Y))
                {
                    Vector2 posicao = mao.PosicaoCelula(posicaoAtual);
                    Vector2Int posicaoMatriz = mao.PosicaoMatriz(posicao);

                    if (mao.tab[posicaoMatriz.y, posicaoMatriz.x] == null)
                    {
                        mao.tab[posicaoMatriz.y, posicaoMatriz.x] = gameObject;
                        if (peca.estado == 0)
                        {
                            posicaoMatriz = mao.PosicaoMatriz(peca.posicaoAnterior);
                            mao.tab[posicaoMatriz.y, posicaoMatriz.x] = null;
                        }
                        else
                        {
                            posicaoMatriz = board.PosicaoMatriz(peca.posicaoAnterior);
                            board.tab[posicaoMatriz.y, posicaoMatriz.x] = null;
                        }
                        pecaSelecionada.transform.position = new Vector2(posicao.x, posicao.y);
                        peca.estado = 0;

                    }
                    else
                    {
                        pecaSelecionada.transform.position = peca.posicaoAnterior;
                    }
                }
                else
                {
                    pecaSelecionada.transform.position = peca.posicaoAnterior;
                }
                pecaSelecionada = null;
            }
            else
            {
                Vector2 posicao = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pecaSelecionada.transform.position = new Vector2(posicao.x, posicao.y);
            }
        }
    }
}
