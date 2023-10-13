using UnityEngine;

[CreateAssetMenu(menuName = "New DiceFighterAssets")]
public class DiceFighterAssets : ScriptableObject
{
    [SerializeField]
    private Sprite _fighterTexture;

    public Sprite FighterTexture
    {
        get
        {
            return _fighterTexture;
        }
    }
}
