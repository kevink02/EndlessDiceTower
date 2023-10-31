using UnityEngine.UI;

public static class ExtensionMethods
{
    public static void UpdateText(this Text textObject, string newValue)
    {
        textObject.text = newValue;
    }
}
