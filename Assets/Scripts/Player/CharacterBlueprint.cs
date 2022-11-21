using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;


public class CharacterBlueprint : MonoBehaviour
{

    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _stamina;
    [SerializeField] private int _normalSpeed;
    [SerializeField] private TextMeshProUGUI NameOutPut;

    private bool canRun;
    public float _currentStamina;
    private int _currentHealth;

    public HealthBar healthBar;
    public StaminaBar staminaBar;

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
    public float Stamina
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
    public float CurrentStamina
    {
        get
        {
            return _currentStamina;
        }
        set
        {
            _currentStamina = value;
        }
    }
    


    public CharacterBlueprint() { }
    public CharacterBlueprint(string name, int health, int currentHealth,int damage, float stamina, float currentStamina)
    {
        Name = name;
        Health = health;
        CurrentHealth = currentHealth;
        AttackDamage = damage;
        Stamina = stamina;
        CurrentStamina = currentStamina;
    }
    public void Start()
    {
        SetHealth();
        SetStamina();
        NameOutPut.text = Name;
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
    public void SetStamina()
    {
        CurrentStamina = Stamina;
        staminaBar.SetMaxStamina(Stamina);
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