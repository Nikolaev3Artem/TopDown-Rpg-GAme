using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyBlueprint : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _attackDamage;
    [SerializeField] private int _stamina;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Enemy;
    [SerializeField] private TextMeshProUGUI NameOutPut;


    private float enemy_position_x;
    private int _currentHealth;

    private NavMeshAgent agent;
    private Animator anim;
    private SpriteRenderer sr;
    public HealthBar healthBar;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    public int AttackDamage
    {
        get
        {
            return _attackDamage;
        }
        set
        {
            _attackDamage = value;
        }
    }
    public int Stamina
    {
        get
        {
            return _stamina;
        }
        set
        {
            _stamina = value;
        }
    }
    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    public EnemyBlueprint() { }
    public EnemyBlueprint(string name, int health, int currentHealth, int damage, int stamina)
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
        FindPlayer();
        EnemySetHealth();
        NameOutPut.text = Name;

    }
    private void Update()
    {
        ChazingBehaviour();
    }
    public void Info()
    {
        Debug.Log("Name:" + Name + ", Health is:" + Health + ", Damage is:" + AttackDamage + ", Stamina is:" + Stamina);
    }
    public void EnemySetHealth()
    {
        CurrentHealth = Health;
        healthBar.SetMaxHealth(Health);
    }
    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Fighter");
        Player = GameObject.FindGameObjectWithTag("Fighter").transform;

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    public void ChazingBehaviour()
    {
        if (Vector3.Distance(player.transform.position, enemy.transform.position) <= 5f)
        {
            agent.SetDestination(Player.position);
            anim.SetBool("isChazing", true);
            Flip();
        }
        else
        {
            anim.SetBool("isChazing", false);
        }
    }
    private void Flip()
    {
        if (Enemy.position.x < enemy_position_x)
        {
            sr.flipX = true;
            enemy_position_x = Enemy.position.x;
        }
        else if (Enemy.position.x > enemy_position_x)
        {
            sr.flipX = false;
            enemy_position_x = Enemy.position.x;
        }
    }

}
