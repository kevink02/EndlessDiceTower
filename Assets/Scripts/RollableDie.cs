using UnityEngine;

[CreateAssetMenu(menuName = "New RollableDie")]
public class RollableDie : ScriptableObject, IRollable
{
    /*
     * Instance variables
     */
    // Replace the variable type later
    [SerializeField]
    protected string[] AttackAnimations;


    /*
     * Properties
     */
    public int RolledValue { get; private set; }


    /*
     * Unity methods
     */
    private void OnEnable()
    {
        if (AttackAnimations.Length != 2)
        {
            Debug.LogError("There are the incorrect amount of attack animations");
        }
    }


    /*
     * Interface methods
     */
    public void SetRolledValue()
    {
        RolledValue = Random.Range(1, 7);
    }

    public int GetRolledValue()
    {
        return RolledValue;
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
