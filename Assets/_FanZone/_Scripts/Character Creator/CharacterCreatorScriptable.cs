using UnityEngine;

[CreateAssetMenu(fileName = "Character Creator", menuName = "Charactor Creator/info")]
public class CharacterCreatorScriptable : ScriptableObject
{
    public enum SelectedCatagory
    {
        TShirt,
        Trousers,
        Hair,
        FacialHair,
        Hat,
        Footwear,
        Sunglassess
    }
    public SelectedCatagory selectedCatagory;
    public Sprite[] buttonIconImage;

    public ItemData[] itemData;
}

[System.Serializable]
public class ItemData
{
    public string name;
    public Sprite[] itemImage;
}
