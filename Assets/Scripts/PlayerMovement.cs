using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.6f;
    public LayerMask destructibleLayer;
    public LayerMask enemyLayers;
    public Transform playerPosition;
    public Rigidbody2D rb;
    public HealthBar healthBar;

    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar.SetInitialValue();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        if (playerPosition.position.y < -4.5)
        {
            StartCoroutine(Death());
        }

        if (rb.IsTouchingLayers(enemyLayers))
        {
            healthBar.DecreaseSliderValue(20);

            Vector2 difference = transform.position - attackPoint.position;

            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y);

            StartCoroutine(DamageBuffer());

            if (healthBar.GetSliderValue() < 1)
            {
                StartCoroutine(Death());
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void Attack()
    {
        if (animator.GetBool("isCrouching") == true || animator.GetBool("isJumping") == true)
        {
            return;
        }
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, destructibleLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag == "Enemy")
            {
                enemy.GetComponent<Enemy>().Die();
            }
            else if (enemy.gameObject.tag == "Crates")
            {
                enemy.GetComponent<Crate>().Die();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    IEnumerator DamageBuffer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(0.3f);

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    IEnumerator Death ()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        animator.SetBool("Death", true);

        yield return new WaitForSeconds(0.58f);

        //Destroy(gameObject);

        Score.scoreByGems = 0;
        Score.scoreByEnemy = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
