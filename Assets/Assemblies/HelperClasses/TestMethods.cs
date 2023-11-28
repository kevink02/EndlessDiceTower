using UnityEngine;

/// <summary>
/// A class to test if methods are called when the object is disabled
/// </summary>
public class TestMethods : MonoBehaviour
{
    /*
     * Unity methods
     */
    private void Awake()
    {
        Debug.Log("OnAwake was called");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable was called");
    }

    private void Start()
    {
        Debug.Log("Start was called");
    }
}
