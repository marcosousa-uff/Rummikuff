using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deck : MonoBehaviour
{
    public class Carta
    {
        public int numero;
        public int cor;//0 preto --- 1 vermelho --- 2 azul --- 3 laranja

        public Carta(int numero, int cor)
        {
            this.numero = numero;
            this.cor = cor;
        }
    }
    private List<Carta> baralho;

    void Start()
    {
        CriarDeck();
        //Cria todas as cartas
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        JogadorHumano jogador = GameObject.Find("JogadorHumano").GetComponent<JogadorHumano>();
        if (jogador.turno && Input.GetMouseButtonDown(0) && baralho.Count > 0)
        {            
            jogador.ComprarPeca();
            jogador.fazendoMovimento = false;
        }
    }

    public GameObject ComprarCard()
    {
        //Compra carta aleatória do baralho
        int rn = Random.Range(0, baralho.Count);
        GameObject go = new GameObject("numero: "+baralho[rn].numero + ", cor: "+baralho[rn].cor);
        go.tag = "piece";
        // Adicionar o componente de peça ao GO.
        Peca pm =  go.AddComponent<Peca>();
        pm.numero = baralho[rn].numero;
        pm.cor = baralho[rn].cor;
        // Adcionar colisão
        BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
        bc.size = new Vector2(1, 2);
        bc.isTrigger = true;
        // Adiciona o sprite ao GameObject
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sortingLayerName = "02";
        renderer.sprite = Resources.Load<Sprite>("teste");
        baralho.RemoveAt(rn); // remove do deck
        return go;
    }

    public Carta ComprarCardIA()
    {
        int rn = Random.Range(0, baralho.Count);
        Carta carta = baralho[rn];
        baralho.RemoveAt(rn);
        return carta;
    }

    public void CriarDeck()
    {
        baralho = new List<Carta>();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j < 14; j++)
            {
                Carta carta = new Carta(j, i);
                baralho.Add(carta);
                baralho.Add(carta);
            }
        }
        Carta coringa = new Carta(-1, -1);
        baralho.Add(coringa);
        baralho.Add(coringa);
    }
}
