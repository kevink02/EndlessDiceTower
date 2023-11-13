using UnityEngine;

public class ElementManager : BasicSingleton<ElementManager>
{
    /*
     * Instance variables
     */
    [SerializeField]
    private ElementType _fireElement;
    [SerializeField]
    private ElementType _grassElement;
    [SerializeField]
    private ElementType _neutralElement;
    [SerializeField]
    private ElementType _waterElement;


    /*
     * Properties
     */
    public ElementType FireElement
    {
        get
        {
            return _fireElement;
        }
    }
    public ElementType GrassElement
    {
        get
        {
            return _grassElement;
        }
    }
    public ElementType NeutralElement
    {
        get
        {
            return _neutralElement;
        }
    }
    public ElementType WaterElement
    {
        get
        {
            return _waterElement;
        }
    }


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
