using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Player : CharacterBlueprint
{
    public Player(string name, int health, int currentHealth, int damage, float stamina, float currentStamina)
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
        this.Info();
        SetHealth();
        SetStamina();
    }

    public void Update()
    {
        //UseStaminaWhenRun();
        //UseStaminaWhenJump();
    }
}
