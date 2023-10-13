using UnityEngine;

[CreateAssetMenu(menuName = "New RollableDie")]
public class RollableDie : ScriptableObject, IRollable
{
    // Replace this variable type later
    [SerializeField]
    protected string AttackAnimation;


    /*
     * Interface methods
     */
    public int GetRolledValue()
    {
        return Random.Range(1, 7);
    }
}
