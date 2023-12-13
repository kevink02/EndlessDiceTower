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
    }

    public void DefeatPlayer()
    {
        Debug.Log($"{DebugMessageHeader}: Defeating current player...");
    }
}
