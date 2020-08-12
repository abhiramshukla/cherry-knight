using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public GameObject itemFeed;
    public HealthBar healthBar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            healthBar.IncreaseSliderValue(20);
            Instantiate(itemFeed, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
