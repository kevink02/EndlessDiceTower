using UnityEngine;

[CreateAssetMenu(menuName = "New DiceFighterAssets")]
public class DiceFighterAssets : ScriptableObject
{
    /*
     * Instance variables
     */
    [SerializeField]
    private Sprite _fighterTexture;


    /*
     * Instance methods
     */
    public Sprite FighterTexture
    {
        get
        {
            return _fighterTexture;
        }
    }
}
