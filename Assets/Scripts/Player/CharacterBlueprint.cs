using UnityEngine;

public class CharacterBlueprint : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _damage;
    [SerializeField] private int _stamina;

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
    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
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
        Damage = damage;
        Stamina = stamina;
    }

    public void Info()
    {
        Debug.Log("Name:" + Name + ", Health is:" + Health + ", Damage is:" + Damage + ", Stamina is:" + Stamina);
    }

    public void SetHealth()
    {
        healthBar.SetMaxHealth(Health);
    }
    public void TakeDamage()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CurrentHealth = CurrentHealth - Damage;
            healthBar.SetHealth(_currentHealth);
        }
    }

    public void CheckHealth()
    {
        if(CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}