using UnityEngine;

[CreateAssetMenu(menuName = "New SO Methods Test")]
public class TestSOMethods : ScriptableObject
{
    /*
     * Unity methods
     */
    // Gets called once upon the SO asset's creation
    // Doesn't seem to be called anymore during runtime
    private void Awake()
    {
        Debug.Log("SO's Awake was called");
    }

    // Works upon asset creation and at runtime
    // Doesn't seem to be called if the object it is embedded in gets disabled and re-enabled
    private void OnEnable()
    {
        Debug.Log("SO's OnEnable was called");
    }

    // Works upon asset creation and at runtime
    // Runs before OnEnable()
    private void OnValidate()
    {
        Debug.Log("SO's OnValidate was called");
    }

    // As of now, I do not plan on destroying SO assets
    // So, do not need to worry about OnDestroy() for now
    // Maybe need to look at OnDisable()
}
