using UnityEngine;

[CreateAssetMenu(menuName = "New RollableDie")]
public class RollableDie : ScriptableObject
{
    /*
     * Instance variables
     */
    // Replace the variable type later
    [SerializeField]
    private ElementType _elementType;
    [SerializeField]
    private string[] _attackAnimations;


    /*
     * Constant variables
     */
    private const int AttackAnimationAmountPerDie = 2;


    /*
     * Properties
     */
    public ElementType DieElement
    {
        get
        {
            return _elementType;
        }
    }
    public string[] AttackAnimations
    {
        get
        {
            return _attackAnimations;
        }
    }


    /*
     * Unity methods
     */
    private void OnEnable()
    {
        if (AttackAnimations.Length != AttackAnimationAmountPerDie)
        {
            Debug.LogError("There are the incorrect amount of attack animations");
        }
    }
}
