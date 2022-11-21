using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


public class Fox : EnemyBlueprint
{
    public Fox(string name, int health, int currentHealth, int damage, int stamina)
    {
        Name = name;
        Health = health;
        CurrentHealth = currentHealth;
        AttackDamage = damage;
        Stamina = stamina;
    }
 
    private void Update()
    {
        ChazingBehaviour();
    }

}
