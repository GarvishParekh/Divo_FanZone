using UnityEngine;

[CreateAssetMenu(fileName = "Avatar Information", menuName = "Character/Information")]
public class CharacterInformation : ScriptableObject
{
    public enum UserGender
    {
        Male,
        Female
    }
    public enum BodyType
    {
        Thin,
        Regular,
        Fat
    }
    public UserGender userGender;
    public BodyType bodyType;

    [Header(" Body Type Sprites ")]
    public Sprite maleThinSprite;
    public Sprite maleRegularSprite;
    public Sprite maleFatSprite;

    [Space]
    public Sprite femaleThinSprite;
    public Sprite femaleRegularSprite;
    public Sprite femaleFatSprite;
}
