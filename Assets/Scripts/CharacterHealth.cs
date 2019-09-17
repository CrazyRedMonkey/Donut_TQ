using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : IHealth
{
    private float health;
    private float maxHealth;
    private float armor = 1;
    private GameObject obj;

    public CharacterHealth(ICharacterMain main, int maxHealth)
    {
        obj = main.obj;
        health = this.maxHealth = maxHealth;
        main.onTriggerEnter += OnTriggerEnter2D;
        main.OnReset += Reset;
    }

    private void Reset()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Projectile projectile = other.gameObject.GetComponent<Projectile>();
        if (projectile != null && obj?.tag != projectile?.Owner?.tag)
        {
            TakeDamage(projectile.Damage);
            Object.Destroy(other.gameObject);
        }
    }

    private void TakeDamage(float damage)
    {
        health -= damage * armor;
        if (health < 0)
            Death();
    }

    private void Death()
    {
        Entity entity= Object.FindObjectOfType<Entity>();
        switch(obj.tag)
        {
            case "Enemy":
                entity.RemoveUnit(obj.GetComponent<ICharacterMain>());
                Object.Destroy(obj);
                break;
            case "Player":
                entity.ShowEndRound();
                obj.SetActive(false);
                break;
            default:
                break;
        }
    }
}
