using UnityEngine;

[CreateAssetMenu(menuName = "New RollableDie")]
public class RollableDie : ScriptableObject, IRollable
{
    // Replace this variable type later
    [SerializeField]
    protected string AttackAnimation;

    public int RolledValue { get; private set; }


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
                Debug.Log("Play animation #1");
                return;
            case 4:
            case 5:
            case 6:
                Debug.Log("Play animation #2");
                return;
            default:
                Debug.LogError($"Rolled value {RolledValue} is invalid");
                return;
        }
    }
}
