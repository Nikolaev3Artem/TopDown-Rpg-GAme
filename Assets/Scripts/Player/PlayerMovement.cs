using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{

    private string WALK_ANIMATION = "Moving";
    private string CRAWL_ANIMATION = "Crawl";
    private string JUMP_ANIMATION = "Jump";
    private string RUN_ANIMATION = "Run";
    private string X_POS = "X";
    private string Y_POS = "Y";

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 input;
    private SpriteRenderer sr;
    public StaminaBar staminaBar;

    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float crawlSpeed = 1f;
    private float x;
    private float y;
    private bool walk;
    private bool jump;
    private bool crawl;
    private bool run;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        GetInput();
        Walk();
    }
    private void FixedUpdate()
    {

        if (run)
        {
            rb.velocity = input * runSpeed;
        }
        else if (crawl)
        {
            rb.velocity = input * crawlSpeed;
        }
        else
        {
            rb.velocity = input * walkSpeed;
        }
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }
    private void Walk()
    {
        Flip();
        Run();
        Crawl();
        Jump();
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            walk = true;
        }
        else
        {
            walk = false;
        }
        if(walk)
        {
            anim.SetFloat(X_POS, x);
            anim.SetFloat(Y_POS, y);
        }
        anim.SetBool(WALK_ANIMATION, walk);
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaBar.slider.value != 0)
        {
            run = true;
        }

        else
        {
            run = false;
        }
        if (run)
        {
            anim.SetBool(RUN_ANIMATION, run);
        }
        anim.SetBool(RUN_ANIMATION, run);
    }

    private void Crawl()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crawl = true;
        }
        else
        {
            crawl = false;
        }
        if (crawl)
        {
            anim.SetBool(CRAWL_ANIMATION, crawl);
        }
        anim.SetBool(CRAWL_ANIMATION, crawl);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        if (jump)
        {
            anim.SetBool(JUMP_ANIMATION, jump);
        }
        anim.SetBool(JUMP_ANIMATION, jump);
    }
    private void Flip()
    {
        if (x < 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
}
