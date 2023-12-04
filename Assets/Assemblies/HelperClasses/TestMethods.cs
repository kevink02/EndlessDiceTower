using UnityEngine;

/// <summary>
/// A class to test if methods are called when the object is disabled
/// </summary>
public class TestMethods : MonoBehaviour
{
    /*
     * Instance variables
     */
    [SerializeField]
    private TestSOMethods _testSOMethods;


    /*
     * Unity methods
     */
    // Object must be enabled
    // Script component may or may not be enabled
    private void Awake()
    {
        Debug.Log("Awake was called");
    }

    // Object and script component must be enabled
    private void OnEnable()
    {
        Debug.Log("OnEnable was called");
    }

    // Object and script component must be enabled
    private void Start()
    {
        Debug.Log("Start was called");
    }
}
