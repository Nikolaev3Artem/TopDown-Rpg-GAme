using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Fox : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    public GameObject target;

    private Rigidbody2D body;
    private Animator anim;

    private string RUN_ANIMATION = "Run";

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        body.transform.position = new Vector3(body.transform.position.x, body.transform.position.y, 0) * speed * Time.deltaTime;
        anim.SetBool(RUN_ANIMATION, true);
    }
}
