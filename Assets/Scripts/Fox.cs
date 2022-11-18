using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Fox : MonoBehaviour
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;
    private Animator anim;
    private SpriteRenderer sr;

    private string RUN_ANIMATION = "Run";

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        anim.SetBool(RUN_ANIMATION, true);
        Flip();
    }

    private void Flip()
    {
        if (target.position.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
