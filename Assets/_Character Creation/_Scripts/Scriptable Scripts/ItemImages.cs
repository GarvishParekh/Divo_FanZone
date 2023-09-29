using UnityEngine;

[CreateAssetMenu (fileName = "ItemInformation", menuName = ("Items"))]
public class ItemImages : ScriptableObject
{
    public MaleSpriteInformation maleSprites;
    public FemaleSpriteInformation femaleSprites;
}

[System.Serializable]
public class MaleSpriteInformation
{
    public Sprite[] tShirtSprites;
    public Sprite[] trouserSprites;
    public Sprite[] hairSprites;
    public Sprite[] facialHairSprites;
    public Sprite[] hatSprite;
    public Sprite[] footwearSprite;
    public Sprite[] sunglassesSprite;
}

[System.Serializable]
public class FemaleSpriteInformation
{
    public Sprite[] tShirtSprites;
    public Sprite[] trouserSprites;
    public Sprite[] hairSprites;
    public Sprite[] hatSprite;
    public Sprite[] footwearSprite;
    public Sprite[] sunglassesSprite;
}

