using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour {

    [SerializeField]
    private GameObject tree;

    [SerializeField]
    private Sprite background1;

    [SerializeField]
    private Sprite background2;

    [SerializeField]
    private Sprite background3;

    Sprite[] backSprites = new Sprite[3];

    int index;
    private SpriteRenderer treeSprite;

     void Start()
    {
        backSprites[0] = background1;
        backSprites[1] = background2;
        backSprites[2] = background3;
        treeSprite = tree.GetComponent<SpriteRenderer>();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            index = Random.Range(0, backSprites.Length);
            treeSprite.sprite = backSprites[index];
        }
    }
}
