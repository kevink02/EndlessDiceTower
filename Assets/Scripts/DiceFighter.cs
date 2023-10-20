using UnityEngine;

public class DiceFighter : MonoBehaviour, IDiceRoller
{
    /*
     * Instance variables
     */
    [SerializeField]
    private DiceFighterAssets _diceRollerAssets;
    [SerializeField]
    private RollableDie _rollableDie;


    /*
     * Properties
     */
    protected DiceFighterAssets FighterAssets
    {
        get
        {
            return _diceRollerAssets;
        }
    }
    protected RollableDie FighterDice
    {
        get
        {
            return _rollableDie;
        }
    }


    /*
     * Unity methods
     */
    protected void Awake()
    {
        if (_diceRollerAssets)
        {
            GetComponent<SpriteRenderer>().sprite = _diceRollerAssets.FighterTexture;
        }
    }


    /*
     * Interface methods
     */
    public void RollDie()
    {
        if (_rollableDie)
        {
            _rollableDie.SetRolledValue();
            _rollableDie.PlayAnimation();
        }
    }
}
