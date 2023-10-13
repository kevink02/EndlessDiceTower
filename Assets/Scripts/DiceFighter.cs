using UnityEngine;

public class DiceFighter : MonoBehaviour
{
    [SerializeField]
    private DiceRoller _diceRollerAssets;

    private void Awake()
    {
        Debug.Log("OnAwake");
    }
}
