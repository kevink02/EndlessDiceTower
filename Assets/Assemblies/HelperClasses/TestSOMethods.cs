using UnityEngine;

[CreateAssetMenu(menuName = "New SO Methods Test")]
public class TestSOMethods : ScriptableObject
{
    /*
     * Unity methods
     */
    private void Awake()
    {
        Debug.Log("SO's Awake was called");
    }

    private void OnEnable()
    {
        Debug.Log("SO's OnEnable was called");
    }

    private void OnValidate()
    {
        Debug.Log("SO's OnValidate was called");
    }
}
