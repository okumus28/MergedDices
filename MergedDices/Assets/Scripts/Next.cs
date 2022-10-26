using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public Sprite[] sprites;
    public bool trigBoard = false ;
    public GameObject trigObject;
    public int number;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        number = Random.Range(1,7);
        spriteRenderer.sprite = sprites[number-1];
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "board")
        {
            trigBoard = true;
            trigObject = other.gameObject;
        }   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "board")
        {
            trigBoard = false;
            trigObject = null;
        }
    }

    public void NewNumber()
    {
        number = Random.Range(1,7);
        spriteRenderer.sprite = sprites[number-1];
    }
}
