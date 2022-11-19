using UnityEngine;

public class CharacterBlueprint : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _attackDamage;
    [SerializeField] private int _stamina;
    private int _currentHealth;

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


    public CharacterBlueprint() { }
    public CharacterBlueprint(string name, int health, int currentHealth,int damage, int stamina)
    {
        Name = name;
        Health = health;
        CurrentHealth = currentHealth;
        AttackDamage = damage;
        Stamina = stamina;
    }

    public void Info()
    {
        Debug.Log("Name:" + Name + ", Health is:" + Health + ", Damage is:" + AttackDamage + ", Stamina is:" + Stamina);
    }

    public void SetHealth()
    {
        CurrentHealth = Health;
        healthBar.SetMaxHealth(Health);
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthBar.SetHealth(_currentHealth);
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.TryGetComponent<Fox>(out Fox enemyComponent))
        {
            enemyComponent.EnemyTakeDamage(AttackDamage);
        }
    }
}