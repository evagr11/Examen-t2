using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

//Uno para cada tipo de salto, un una lista

public class MovementStats : ScriptableObject
{
    [Header("Ground")]
    public float acceleration;
    public float maxSpeed;
    public float friction;
}
