using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 20f;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
