using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;


    public bool inFloor = true;



    ////

    public Transform attackPoint;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public float attackRate = 2f;

    float nextAttackTime = 0f;


    public AudioSource audioS;
    public AudioClip[] Sounds;



    private Rigidbody2D rbPlayer;
    private SpriteRenderer sr;

    private Animator playerAnim; //guarda a classe GameController


    private GameController gcPlayer; //guarda a classe GameController

    void Start()
    {
        gcPlayer = GameController.gc;
        gcPlayer.coins = 0;
        playerAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        MovePlayer();
    }
    void Update()
    {
        //MovePlayer();
        Jump();
        Attack();
    }

    void MovePlayer()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        // Debug.Log(horizontalMoviment);
        //transform.position += new Vector3(horizontalMoviment * Time.deltaTime * speed, 0, 0);
        rbPlayer.velocity = new Vector2(horizontalMoviment * speed, rbPlayer.velocity.y);

        if (horizontalMoviment > 0)
        {
            playerAnim.SetBool("Walk", true);
            attackPoint.localPosition = new Vector2(-attackPoint.localPosition.x, attackPoint.localPosition.y);
            sr.flipX = false;

        }

        else if (horizontalMoviment < 0)
        {
            playerAnim.SetBool("Walk", true);
            attackPoint.localPosition = new Vector2(-attackPoint.localPosition.x, attackPoint.localPosition.y);
            sr.flipX = true;

        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }
    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            audioS.clip = Sounds[0];
            audioS.Play();
            playerAnim.SetBool("Jump", true);
            rbPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            inFloor = false;
        }


    }

    void Attack()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                audioS.clip = Sounds[1];
                audioS.Play();

                playerAnim.SetTrigger("Attack");



                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<GoblinEnemy>().TakeDamageGlobin(20);
                }

                nextAttackTime = Time.time + 1f / attackRate;
            }
        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Ground")
        {
            playerAnim.SetBool("Jump", false);
            inFloor = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // serve para detectar quando o player entrou em contato com algum objeto de recompensa do jogo(pelo gatilho)
    {

        if (collision.gameObject.tag == "Coins") //se a colisão for com o objeto de jogo com marcação igual a Coins
        {
            audioS.clip = Sounds[2];
            audioS.Play();
            Destroy(collision.gameObject); // destrói o objeto da colisão
            gcPlayer.coins++;
            gcPlayer.coinsText.text = gcPlayer.coins.ToString();
        }

    }
    void OnDrawGizmosSelected()

    {

        if (attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}





