using System;
using UnityEngine;

public class UserInput : IInput
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

    public UserInput(ICharacterMain main)
    {
        main.OnUpdate += Update;
        main.OnReset += Reset;
    }

    private void Reset()
    {
        Axis = Vector2.zero;
        RotateDirection = 0;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Axis = new Vector2(horizontal, vertical);
        if (Input.GetKey(KeyCode.Q))
            RotateDirection += 1;
        else if (Input.GetKey(KeyCode.E))
            RotateDirection += -1;
        else
            RotateDirection += 0;



        if (Input.GetKey(KeyCode.Space))
            if (OnShoot != null)
                OnShoot.Invoke();
    }
}
