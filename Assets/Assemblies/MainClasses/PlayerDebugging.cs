using UnityEngine;

/// <summary>
/// To quickly simulate specific actions and features of the game for debugging purposes
/// </summary>
public class PlayerDebugging
{
    /*
     * Constants
     */
    private const string DebugMessageHeader = "[DEBUG]";


    /*
     * Instance methods
     */
    public void DefeatEnemy()
    {
        Debug.Log($"{DebugMessageHeader}: Defeating current enemy...");
        FighterGenerator.Instance.CurrentEnemyFighter.TakeDamage(999999, ElementManager.Instance.NeutralElement);
    }

    public void DefeatPlayer()
    {
        Debug.Log($"{DebugMessageHeader}: Defeating current player...");
        FighterGenerator.Instance.CurrentPlayerFighter.TakeDamage(999999, ElementManager.Instance.NeutralElement);
    }
}
