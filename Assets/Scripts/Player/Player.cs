using UnityEngine;

public class Player
{
    [SerializeField] private string _name;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _stamina;

    private string Name
    {
        get
        {
            return _name;
        }
        set
        {
            Name = value;
        }
    }
    private int Health
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
    private int Damage
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
    private int Stamina
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

    public Player() { }
    public Player(string name, int health, int damage, int stamina)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Stamina = stamina;
    }

    public void Info()
    {
        Debug.Log("Name:" + Name + ", Health is:" + Health + ", Damage is:" + Damage + ", Stamina is:" + Stamina);
    }
}
