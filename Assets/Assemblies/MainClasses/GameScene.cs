using UnityEditor;
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
    // Scene type fields do not completely show in inspector and do not work
    // Object type fields show in inspector and work for scene assets
    // EditorBuildSettingsScene type fields do not show in inspector
    [SerializeField]
    private SceneAsset _scene;


    /*
     * Properties
     */
    public SceneAsset SceneToSwitchTo
    {
        get
        {
            return _scene;
        }
    }


    /*
     * Unity methods
     */
    private void OnEnable()
    {
        if (_scene == null)
        {
            throw new System.NullReferenceException("Scene asset is not set");
        }
    }


    /*
     * Instance methods
     */
    public void SwitchScene()
    {
        SceneManager.LoadScene(SceneToSwitchTo.name);
    }
}
