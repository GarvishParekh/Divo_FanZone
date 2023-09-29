using UnityEngine;


[CreateAssetMenu(fileName = "PlayerPref Information", menuName = "PlayerPref/Tags")]
public class PlayerPerfTags : ScriptableObject
{
    public string alreadyMade;

    [Space]
    public string userGender;           // 0 male, 1 female
    public string userBodyType;         // 0 thin, 1 regular, 2 fat
    public string userBodyColor;        // 0 fair, 1 regular, 2 dark

    [Space]
    public MalePrefab malePrefab;
    public FemalePrefab femalePrefab;
}

[System.Serializable]
public class MalePrefab
{
    public string tShirtEquipped;
    public string trouserEquipped;
    public string hairEquipped;
    public string facialHairEquipped;
    public string hatEquipped;
    public string footwearEquipped;
    public string sunglassesEquipped;
}

[System.Serializable]
public class FemalePrefab
{
    public string tShirtEquipped;
    public string trouserEquipped;
    public string hairEquipped;
    public string hatEquipped;
    public string footwearEquipped;
    public string sunglassesEquipped;
}
