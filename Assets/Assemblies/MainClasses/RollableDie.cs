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
    protected string[] AttackAnimations;


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
    public int RolledValue { get; private set; }


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


    /*
     * Instance methods
     */
    public void SetRolledValue()
    {
        RolledValue = RandomGenerator.GetDieRoll();
    }

    public void PlayAnimation()
    {
        switch (RolledValue)
        {
            case 1:
            case 2:
            case 3:
                Debug.Log($"Animation #1: {AttackAnimations[0]}");
                return;
            case 4:
            case 5:
            case 6:
                Debug.Log($"Animation #2: {AttackAnimations[1]}");
                return;
            default:
                Debug.LogError($"Rolled value {RolledValue} is invalid");
                return;
        }
    }
}
