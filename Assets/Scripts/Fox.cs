using UnityEngine;
using UnityEngine.AI;
public class Fox : MonoBehaviour
{
    [SerializeField] Transform target;
    private NavMeshAgent agent;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}
