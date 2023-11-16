using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// An SO class to represent a scene within the game
/// </summary>
[CreateAssetMenu(menuName = "New Game Scene")]
public class GameScene : ScriptableObject
{
    /*
     * Instance variables
     */
    [SerializeField]
    private Scene _scene;


    /*
     * Properties
     */
    public Scene SceneToSwitchTo
    {
        get
        {
            return _scene;
        }
    }
}
