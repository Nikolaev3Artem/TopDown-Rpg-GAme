using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Player : CharacterBlueprint
{
    public Player(string name, int health, int currentHealth, int damage, int stamina, double currentStamina)
    {
        Name = name;
        Health = health;
        CurrentHealth = currentHealth;
        AttackDamage = damage;
        Stamina = stamina;
        CurrentStamina = currentStamina;
    }
}
