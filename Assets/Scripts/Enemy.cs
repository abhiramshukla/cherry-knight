using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Collider2D collider;
    public Rigidbody2D rb;

    public void Die()
    {
        StartCoroutine(isDying());
    }

    public void Dead()
    {
        Score.scoreByEnemy += 50;
        Destroy(gameObject);
    }

    IEnumerator isDying()
    {
        yield return new WaitForSeconds(0.17f);
        animator.SetTrigger("Died");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        collider.enabled = false;
    }
}
