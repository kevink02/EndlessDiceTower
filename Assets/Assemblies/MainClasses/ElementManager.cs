using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : BasicSingleton<ElementManager>
{
    /*
     * Instance variables
     */
    // Replace these variable types with a Scriptable Object later
    [SerializeField]
    private Object _fireElement;
    [SerializeField]
    private Object _grassElement;
    [SerializeField]
    private Object _neutralElement;
    [SerializeField]
    private Object _waterElement;


    /*
     * Unity methods
     */
    private void Awake()
    {
        if (_fireElement == null || _grassElement == null || _neutralElement == null || _waterElement == null)
        {
            throw new System.NullReferenceException("One or more of the element objects is not set");
        }
    }
}
