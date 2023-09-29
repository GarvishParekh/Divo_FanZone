using UnityEngine;

public class SetBodyColor : MonoBehaviour
{
    [Header(" Materials ")]
    [SerializeField] private CharacterInformation characterInformation;
    [SerializeField] private PlayerPerfTags playerPerfTags;

    [Header (" Materials ")]
    [SerializeField] private Material maleSkinMaterial;
    [SerializeField] private Material femaleSkinMaterial;


    [Header (" Textures ")]
    [SerializeField] private Texture[] maleSkinToneTextures;
    [SerializeField] private Texture[] femaleSkinToneTextures;

    public void SetSkinTone(int _index)
    {
        if (characterInformation.userGender == CharacterInformation.UserGender.Male)
            maleSkinMaterial.mainTexture = maleSkinToneTextures[_index];
        else
            femaleSkinMaterial.mainTexture = femaleSkinToneTextures[_index];

        PlayerPrefs.SetInt(playerPerfTags.userBodyColor, _index);
    }
}
