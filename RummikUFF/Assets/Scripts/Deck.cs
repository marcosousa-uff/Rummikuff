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
    public bool turno;

    // Start is called before the first frame update
    void Start()
    {
        turno = false;
        CriarDeck();
        //Cria todas as cartas
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            JogadorHumano jogador = GameObject.Find("JogadorHumano").GetComponent<JogadorHumano>();
            jogador.ComprarPeca();
            jogador.turno = !jogador.turno;
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
        pm.Numero = baralho[rn].numero;
        pm.Cor = baralho[rn].cor;
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

    void CriarDeck()
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
