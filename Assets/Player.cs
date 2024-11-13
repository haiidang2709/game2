using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] GameObject Vungchem;
    private float movementX, movementY;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    public float maxHeart = 3f;
    public HeartController heartController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Flip();
        Attack();
        Shot();
    }

    void FixedUpdate()
    {

    }

    public void Move()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        // Di chuyển nếu không bị chặn bởi một vật cản
        Vector2 movement = new Vector2(movementX, movementY).normalized;
        rb.velocity = movement * moveSpeed;



        // Kích hoạt animation di chuyển
        anim.SetBool("chay", movementX != 0 || movementY != 0);
    }

    public void Flip()
    {
        if ((movementX > 0 && !isFacingRight) || (movementX < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Kích hoạt animation tấn công
            anim.SetTrigger("Attack");
            anim.SetBool("isattacking", true);
            Hienthivungchem();
        }
    }

    public void OnAttack()
    {
        anim.ResetTrigger("Attack");
        anim.SetBool("isattacking", false);
        Anvungchem();
    }

    public void Hienthivungchem()
    {
        Vungchem.gameObject.SetActive(true);
    }

    public void Anvungchem()
    {
        Vungchem.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("an"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Quaichem"))
        {
            heartController.TakeDamage(1);    // Giảm 1 trái tim khi bị quái đánh
        }
    }
    


    [SerializeField] GameObject Arrow;
    float arrowSpeed = 5;


    public void Shot()
    {
        if (Input.GetKeyDown(KeyCode.C) && movementX != 0)
        {
            GameObject shot = Instantiate(Arrow, rb.transform.position, Quaternion.identity);
            Rigidbody2D arrow = shot.GetComponent<Rigidbody2D>();

            if (isFacingRight)
            {
                arrow.velocity = new Vector2(arrowSpeed, 0);
            }
            else
            {
                arrow.velocity = new Vector2(-arrowSpeed, 0);
                Vector3 Scale = arrow.transform.localScale;
                Scale.x *= -1;
                arrow.transform.localScale = Scale;
            }
            Destroy(shot, 2f);
        }
        if (Input.GetKeyDown(KeyCode.C) && (movementY > 0))
        {
            GameObject shot = Instantiate(Arrow, rb.transform.position, Quaternion.Euler(0, 0, 90));
            Rigidbody2D arrow = shot.GetComponent<Rigidbody2D>();
            arrow.velocity = new Vector2(0, arrowSpeed);
            Destroy(shot, 2f);
        }
        else if (Input.GetKeyDown(KeyCode.C) && (movementY < 0))
        {
            GameObject shot = Instantiate(Arrow, rb.transform.position, Quaternion.Euler(0, 0, -90));
            Rigidbody2D arrow = shot.GetComponent<Rigidbody2D>();
            arrow.velocity = new Vector2(0, -arrowSpeed);
            Destroy(shot, 2f);
        }
    }
}
