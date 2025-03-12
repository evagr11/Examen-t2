using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public class RotationMacroEvent : UnityEvent<int[], float[]> { };
    public static UnityEvent PlayerDied = new UnityEvent();
    public static UnityEvent EnemyDied = new UnityEvent();
    public static UnityEvent GameStarted = new UnityEvent();
}
