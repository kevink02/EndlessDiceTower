using UnityEngine;

[CreateAssetMenu(menuName = "New RollableDie")]
public class RollableDie : ScriptableObject
{
    // Replace this variable type later
    [SerializeField]
    protected string AttackAnimation;

    private int _rolledValue;
}
