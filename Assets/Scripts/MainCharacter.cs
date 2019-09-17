using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour, ICharacterMain
{
    private IInput input;
    private IEngine engine;
    private IWeapon weapon;
    private IHealth health;

    public event Action OnUpdate;
    public event Action OnReset;
    public event Action<Collider2D> onTriggerEnter;
    public GameObject obj { get { return this.gameObject; } }

    public void Reset()
    {
        if(OnReset!=null)
        {
            OnReset.Invoke();
        }
    }

    private void Awake()
    {
        input = new UserInput(this);
        health = new CharacterHealth(this, 10);
        engine = new CharacterEngine(this, input);
        weapon = new Weapon(this, input);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (onTriggerEnter != null)
            onTriggerEnter.Invoke(other);
    }

    private void Update()
    {
        if (OnUpdate != null)
            OnUpdate.Invoke();
    }
}
