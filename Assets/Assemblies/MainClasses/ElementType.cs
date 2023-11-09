using UnityEngine;

/// <summary>
/// A Scriptable Object enum for categorizing element types
/// </summary>
[CreateAssetMenu(menuName = "New Element Type")]
public class ElementType : ScriptableObject
{
    /*
     * Instance variables
     */
    [SerializeField]
    // The element that would lose against this object's element type
    private ElementType _elementStrength;


    /*
     * Unity methods
     */
    private void OnEnable()
    {
    }
}
