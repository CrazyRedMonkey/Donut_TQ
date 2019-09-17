using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : IInput
{
    public Vector2 Axis
    {
        get;
        private set;
    }
    public float RotateDirection
    {
        get;
        private set;
    }

    private float vertical;
    private float horizontal;

    public event Action OnShoot;

    private GameObject target;
    private GameObject obj;
    private float stopDistance;
    public AiInput(ICharacterMain main)
    {
        obj = main.obj;
        stopDistance = UnityEngine.Random.Range(2f,6f);
        target = GameObject.FindGameObjectWithTag("Player");
        main.OnUpdate += Update;
    }

    private void Update()
    {
        if (Vector2.Distance(target.transform.position, obj.transform.position) < 7f)
            if (OnShoot != null)
                OnShoot.Invoke();

        Vector3 vectorToTarget = target.transform.position - obj.transform.position;
        RotateDirection = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

        if (Vector2.Distance(target.transform.position, obj.transform.position) < stopDistance)
            Axis = Vector2.zero;
        else
            Axis = (target.transform.position - obj.transform.position).normalized;
    }
}