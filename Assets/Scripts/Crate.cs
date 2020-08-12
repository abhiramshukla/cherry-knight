using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public Animator animator;
    public Collider2D collider;
    public GameObject cherry;

    public void Die()
    {
        StartCoroutine(isDying());
    }

    public void Dead()
    {
        Instantiate(cherry, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator isDying()
    {
        yield return new WaitForSeconds(0.17f);
        animator.SetTrigger("Struck");
    }
}
