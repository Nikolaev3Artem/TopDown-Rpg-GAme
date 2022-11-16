using System.Collections;
using UnityEngine;

public class Player
{
    private int _health;
    
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

    private int _damage;

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

    private string _name;

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

    public Player() { }

    public Player(int health, int damage, string name)
    {
        Health = health;
        Damage = damage;
        Name = name;
    }

    public virtual void Attack()
    {
        Debug.Log(Name + " is shooting.");
    }

    public void Info()
    {
        Debug.Log("Health is: " + Health + ", Damage is: " + Damage + ", Name is: " + Name);
    }


} // class
