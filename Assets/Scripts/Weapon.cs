using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IWeapon
{
    private IInput input;
    private GameObject obj;
    private Projectile projectile;
    private float attackSpeed = 0.5f;


    public Weapon(ICharacterMain main, IInput input)
    {
        this.input = input;
        this.obj = main.obj;
        input.OnShoot += Shoot;
        projectile = Resources.Load<Projectile>("Projectile");
    }
    private float nextAviableAttackTime;
    public void Shoot()
    {
        if (Time.time > nextAviableAttackTime)
        {
            Projectile clone = Object.Instantiate(projectile, obj.transform.position, Quaternion.identity);
            clone.OnCreate(obj.transform.up, obj);
            nextAviableAttackTime = Time.time + attackSpeed;
        }
    }
}
