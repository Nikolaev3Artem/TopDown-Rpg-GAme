using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Fox : EnemyBlueprint
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Enemy;

    private NavMeshAgent agent;
    private Animator anim;
    private SpriteRenderer sr;

    private string CHAZING_ANIMATION = "isChazing";
    private float enemy_position_x;



    public Fox(string name, int health, int currentHealth, int damage, int stamina)
    {
        Name = name;
        Health = health;
        CurrentHealth = currentHealth;
        AttackDamage = damage;
        Stamina = stamina;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        EnemySetHealth();
    }
 
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= 5f)
        {
            agent.SetDestination(Player.position);
            anim.SetBool(CHAZING_ANIMATION, true);
            Flip();
        }
        
    }

    private void Flip()
    {
        if (Enemy.position.x < enemy_position_x)
        {
            sr.flipX = true;
            enemy_position_x = Enemy.position.x;
        }
        else if(Enemy.position.x > enemy_position_x)
        {
            sr.flipX = false;
            enemy_position_x = Enemy.position.x;
        }
    }

}
