using UnityEngine;

public class DiceRoller : IDiceRoller
{
    [SerializeField]
    protected RollableDie Die;


    private void Awake()
    {
        RollDie();
    }

    /*
     * Interface methods
     */
    public void RollDie()
    {
        if (Die)
        {
            Die.SetRolledValue();
            Die.PlayAnimation();
        }
    }
}
