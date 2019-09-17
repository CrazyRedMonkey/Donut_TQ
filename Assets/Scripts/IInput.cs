using System;
using UnityEngine;

public interface IInput
{
    Vector2 Axis { get; }
    float RotateDirection { get; }
    event Action OnShoot;
}