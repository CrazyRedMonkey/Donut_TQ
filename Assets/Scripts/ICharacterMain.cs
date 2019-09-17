using System;
using UnityEngine;

public interface ICharacterMain
{
    GameObject obj { get; }
    event Action OnUpdate;
    event Action OnReset;
    event Action<Collider2D> onTriggerEnter;
    void Reset();
}