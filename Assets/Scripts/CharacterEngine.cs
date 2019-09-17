using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEngine : IEngine
{
    private IInput input;
    private float speed;
    private float speedRotation;
    private GameObject obj;

    public CharacterEngine(ICharacterMain main, IInput input)
    {
        speed = 5;
        speedRotation = 120;
        this.input = input;
        this.obj = main.obj;
        main.OnUpdate += Update;
        main.OnReset += Reset;
    }

    private void Reset()
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        Vector3 pos = obj.transform.position+ (Time.deltaTime * input.Axis.x * Vector3.right * speed) + (Time.deltaTime * input.Axis.y * Vector3.up * speed);
        pos.z = 0;
        obj.transform.position = pos;

        Quaternion q = Quaternion.AngleAxis(input.RotateDirection, Vector3.forward);
        obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, q, Time.deltaTime * speedRotation);
    }
}
