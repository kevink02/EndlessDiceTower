using UnityEngine;

public class SceneManager : BasicSingleton<SceneManager>
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
}
