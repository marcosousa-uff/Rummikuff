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

    public List<Carta> baralho;
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
            comprarCard();
            if (turno)
            {
                turno = false;
            }
            else
            {
                turno = true;
            }
            Debug.Log(turno);
        }
    }

    void comprarCard()
    {
        //Compra carta aleatória do baralho      
        int rn = Random.Range(0, baralho.Count);
        GameObject go = new GameObject("numero: "+baralho[rn].numero + ", cor: "+baralho[rn].cor);
        go.tag = "piece";
        PieceMovement pm =  go.AddComponent<PieceMovement>();
        pm.numero = baralho[rn].numero;
        pm.cor = baralho[rn].cor;
        BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
        bc.size = new Vector2(1, 2);
        bc.isTrigger = true;
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        renderer.sortingLayerName = "02";
        renderer.sprite = Resources.Load<Sprite>("teste");

        Mao bd = GameObject.Find("Mao").GetComponent<Mao>();
        baralho.RemoveAt(rn);
        bd.AdicionarPeca(go);
        //cm.Adicionar(go);
        //cm.Posicionar(go);

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
