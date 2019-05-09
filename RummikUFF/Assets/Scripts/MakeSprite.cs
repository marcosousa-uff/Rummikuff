using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSprite : MonoBehaviour
{

    void Start()
    {   
        for(int i = 0; i < 100; i++)
        {
            GameObject go = new GameObject("New Sprite");
            go.AddComponent<PieceMovement>();
            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
            BoxCollider2D bc = go.AddComponent<BoxCollider2D>();
            bc.size = new Vector2(1, 2);
            bc.isTrigger = true;
            go.transform.position = new Vector2(5, 5);
            renderer.sprite = Resources.Load<Sprite>("teste");       
        }

    }
}
