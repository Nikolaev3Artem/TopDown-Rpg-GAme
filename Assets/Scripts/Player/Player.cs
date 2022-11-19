using UnityEngine;
using UnityEngine.Tilemaps;


public class Player : CharacterBlueprint
{

    public Player(string name, int health, int currentHealth, int damage, int stamina)
    {
        Name = name;
        Health = health;
        CurrentHealth = currentHealth;
        Damage = damage;
        Stamina = stamina;
    }

    public void Awake()
    {
        this.Info();
        SetHealth();
    }

    public void Update()
    {
        TakeDamage();
        CheckHealth();
    }

}
