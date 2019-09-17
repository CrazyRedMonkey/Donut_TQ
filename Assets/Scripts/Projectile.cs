using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed;
    private Vector3 direction;
    private float lifeTime;
    public float Damage { get; private set; }
    public GameObject Owner { get; private set; }
    public void OnCreate(Vector3 direction, GameObject owner)
    {
        speed = 10;
        Damage = 1;
        lifeTime = 3;
        this.direction = direction;
        this.Owner = owner;
    }


    private void Update()
    {
        transform.position += (Time.deltaTime * direction * speed);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }
}
