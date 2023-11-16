using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : BasicSingleton<SceneManager>
{
    /*
     * Instance variables
     */
#warning Todo: update these variable types to a Scriptable Object class
    [SerializeField]
    private GameObject _startScreen;
    [SerializeField]
    private GameObject _gameScreen;


    /*
     * Instance methods
     */
    public void SwitchScene(GameObject sceneToSwitchTo)
    {
        Debug.Log($"{name}: Opening {sceneToSwitchTo}'s scene");
    }
}
