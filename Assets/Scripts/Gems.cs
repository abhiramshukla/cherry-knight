using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{

    public GameObject itemFeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Score.scoreByGems += 25;
            Instantiate(itemFeed, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
