using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float crawlSpeed = 2f;
    private float x;
    private float y;

    private Rigidbody2D body;
    private Animator anim;
    private SpriteRenderer sr;
    private Vector2 input;

    private bool moving;
    private bool jump;
    private bool crawl;
    private bool run;
    private string X_POS = "X";
    private string Y_POS = "Y";

    //Animations states
    private string MOVING_ANIMATION = "Moving";
    private string CRAWL_ANIMATION = "Crawl";
    private string JUMP_ANIMATION = "Jump";
    private string RUN_ANIMATION = "Run";

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }



    private void Update()
    {
        GetInput();
        Animate();
    }

    private void FixedUpdate()
    {
        if (run)
        {
            body.velocity = input * runSpeed;
        }
        else if (crawl)
        {
            body.velocity = input * crawlSpeed;
        }
        else
        {
            body.velocity = input * normalSpeed;
        }
    }
    private void Animate()
    {
        // moving our character
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        // jump animation
        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        // crawl animation
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crawl = true;
        }
        else
        {
            crawl = false;
        }

        // run animation
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if (moving)
        {
            anim.SetFloat(X_POS, x);
            anim.SetFloat(Y_POS, y);
        }

        if (x < 0)
        {
            sr.flipX = false;
        }
        else if (x > 0)
        {
            sr.flipX = true;
        }
        anim.SetBool(MOVING_ANIMATION, moving);
        anim.SetBool(CRAWL_ANIMATION, crawl);
        anim.SetBool(JUMP_ANIMATION, jump);
        anim.SetBool(RUN_ANIMATION, run);

    }
}
