using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Fox : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform Player;

    private NavMeshAgent agent;
    private Animator anim;
    private SpriteRenderer sr;

    private string RUN_ANIMATION = "Run";

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, enemy.transform.position) <= 5f)
        {
            agent.SetDestination(Player.position);
            anim.SetBool(RUN_ANIMATION, true);
            Flip();
        }
        else
        {
            anim.SetBool(RUN_ANIMATION, false);
        }
    }

    private void Flip()
    {
        if (Player.position.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

}
