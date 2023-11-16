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
     * Instance methods
     */
    public void SwitchScene(GameObject sceneToSwitchTo)
    {
        Debug.Log($"{name}: Opening {sceneToSwitchTo}'s scene");
    }

    public void QuitGame()
    {
        Debug.LogWarning($"{name}: Quitting the game...");
        Application.Quit();
    }
}
