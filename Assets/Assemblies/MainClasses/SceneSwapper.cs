using UnityEngine;

public class SceneSwapper : BasicSingleton<SceneSwapper>
{
    /*
     * Instance variables
     */
    [SerializeField]
    private GameScene _startScene;
    [SerializeField]
    private GameScene _levelScene;


    /*
     * Unity methods
     */
    private void Awake()
    {
        if (_startScene == null || _levelScene == null)
        {
            throw new System.NullReferenceException("One of the scenes is not set");
        }
    }


    /*
     * Instance methods
     */
    // Used by some UI buttons for switching scenes
    public void SwitchScene(GameScene sceneToSwitchTo)
    {
        sceneToSwitchTo.SwitchScene();
    }

    // Used by UI quit button to quit the game
    public void QuitGame()
    {
        Debug.LogWarning($"{name}: Quitting the game...");
        Application.Quit();
    }
}
