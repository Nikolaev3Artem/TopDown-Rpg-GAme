using System.Collections;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Animator anim;

    Player p = new Player();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();


    }

} // class
