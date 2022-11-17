using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;
    private float movementX;
    private float movementY;
    private bool crawl = false;

    private Rigidbody2D body;
    private Animator anim;
    private SpriteRenderer sr;

    //Animations states
    private string WALK_UP_ANIMATION = "Walk_Up";
    private string WALK_DOWN_ANIMATION = "Walk_Down";
    private string WALK_SIDE_ANIMATION = "Walk_Side";
    private string CRAWL_UP_ANIMATION = "Crawl_Up";
    private string CRAWL_DOWN_ANIMATION = "Crawl_Down";
    private string CRAWL_SIDE_ANIMATION = "Crawl_Side";

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * moveForce;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            crawl = true;
        }
        else
        {
            crawl = false;
        }

    }

    void AnimatePlayer()
    {
        if (movementY > 0)
        {
            if (crawl != false)
            {
                anim.SetBool(CRAWL_UP_ANIMATION, true);
            }
            else
            {
                anim.SetBool(WALK_UP_ANIMATION, true);
            }

        }
        else if (movementY < 0)
        {
            if (crawl != false)
            {
                anim.SetBool(CRAWL_DOWN_ANIMATION, true); 
            }
            else
            {
                anim.SetBool(WALK_DOWN_ANIMATION, true);
            }

    }
        else
        {
            anim.SetBool(WALK_UP_ANIMATION, false);
            anim.SetBool(WALK_DOWN_ANIMATION, false);
            anim.SetBool(CRAWL_UP_ANIMATION, false);
            anim.SetBool(CRAWL_DOWN_ANIMATION, false);

        }

        if (movementX > 0)
        {
            if(crawl != false)
            {
                anim.SetBool(CRAWL_SIDE_ANIMATION, true);
            }
            else
            {
                anim.SetBool(CRAWL_SIDE_ANIMATION, false);
                anim.SetBool(WALK_SIDE_ANIMATION, true);
            }
            sr.flipX = true;
        }
        else if(movementX < 0)
        {
            if (crawl != false)
            {
                anim.SetBool(CRAWL_SIDE_ANIMATION, true);
            }
            else
            {
               anim.SetBool(WALK_SIDE_ANIMATION, true);
            }
            sr.flipX = false;
        }
        else
        {
            anim.SetBool(CRAWL_SIDE_ANIMATION, false);
            anim.SetBool(WALK_SIDE_ANIMATION, false);
        }
    }
}
