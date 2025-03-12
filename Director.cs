using UnityEngine;
using UnityEngine.UI;

public abstract class Director : MonoBehaviour
{
    [SerializeField] protected string abilityName;
    [SerializeField] protected Image icon;
    [SerializeField] protected float cooldown;

    public abstract void Trigger();
}
