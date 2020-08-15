using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector2 checkpoint;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
                checkpoint = transform.position;
                spriteRenderer.sprite = newSprite;
        }
    }
}
