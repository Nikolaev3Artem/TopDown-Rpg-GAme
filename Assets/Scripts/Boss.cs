using System.Collections;
using UnityEngine;

public class Boss : Player
{
    public Boss(int health, int damage, string name)
    {
        Health = health;
        Damage = damage;
        Name = name;
    }

    public override void Attack()
    {
        Debug.Log(Name + " is fighting.");
    }
} // class
