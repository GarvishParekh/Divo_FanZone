using UnityEngine;
using UnityEngine.UI;

public class UpdateItemOnModel : MonoBehaviour
{
    Toggle toggleButton;
    ItemModelData itemModelDataInstance;
    ItemDataFetcher itemFetcherInstance;
    [SerializeField]
    private enum ItemTtype
    {
        TShirt,
        Trousers,
        Hair,
        FacialHair,
        Hat,
        Footwear,
        Sunglasses,
    }

    [SerializeField]
    private enum CharacterGender
    {
        Male,
        Female
    }
    [Header(" Scriptable Object ")]
    [SerializeField] private PlayerPerfTags playerPerfTags;

    [Header(" Elements ")]
    [SerializeField] private CharacterGender characterGender;
    [SerializeField] private ItemTtype itemType;

    private void Start()
    {
        itemModelDataInstance = ItemModelData.instance;
        itemFetcherInstance = GetComponent<ItemDataFetcher>();
        toggleButton = GetComponent<Toggle>();

        toggleButton.onValueChanged.AddListener(OnItemSelect);

        EnableLastSelectedMale();
        EnableLastSelectedFemale();
    }

    public void OnItemSelect(bool isOn)
    {
        if (isOn)
        {
            int index = itemFetcherInstance.itemIndex;

            if (characterGender == CharacterGender.Male)
            {
                switch (itemType)
                {
                    case ItemTtype.TShirt:
                        itemModelDataInstance.ChangeMaleTShirt(index);
                        PlayerPrefs.SetInt(playerPerfTags.malePrefab.tShirtEquipped, index);
                        break;
                    case ItemTtype.Trousers:
                        itemModelDataInstance.ChangeMaleTrousers(index);
                        PlayerPrefs.SetInt(playerPerfTags.malePrefab.trouserEquipped, index);
                        break;
                    case ItemTtype.Hair:
                        itemModelDataInstance.ChangeMaleHair(index);
                        PlayerPrefs.SetInt(playerPerfTags.malePrefab.hairEquipped, index);
                        break;
                    case ItemTtype.FacialHair:
                        itemModelDataInstance.ChangeMaleFacialHair(index);
                        PlayerPrefs.SetInt(playerPerfTags.malePrefab.facialHairEquipped, index);
                        break;
                    case ItemTtype.Hat:
                        itemModelDataInstance.ChangeMaleHat(index);
                        PlayerPrefs.SetInt(playerPerfTags.malePrefab.hatEquipped, index);
                        break;
                    case ItemTtype.Footwear:
                        itemModelDataInstance.ChangeMaleFootwearModels(index);
                        PlayerPrefs.SetInt(playerPerfTags.malePrefab.footwearEquipped, index);
                        break;
                    case ItemTtype.Sunglasses:
                        itemModelDataInstance.ChangeMaleSunglasses(index);
                        PlayerPrefs.SetInt(playerPerfTags.malePrefab.sunglassesEquipped, index);
                        break;
                    default:
                        break;
                }
            }

            else if (characterGender == CharacterGender.Female)
            {
                switch (itemType)
                {
                    case ItemTtype.TShirt:
                        itemModelDataInstance.ChangeFemaleTShirt(index);
                        PlayerPrefs.SetInt(playerPerfTags.femalePrefab.tShirtEquipped, index);
                        break;
                    case ItemTtype.Trousers:
                        itemModelDataInstance.ChangeFemaleTrousers(index);
                        PlayerPrefs.SetInt(playerPerfTags.femalePrefab.trouserEquipped, index);
                        break;
                    case ItemTtype.Hair:
                        itemModelDataInstance.ChangeFemaleHair(index);
                        PlayerPrefs.SetInt(playerPerfTags.femalePrefab.hairEquipped, index);
                        break;
                    case ItemTtype.Hat:
                        itemModelDataInstance.ChangeFemaleHat(index);
                        PlayerPrefs.SetInt(playerPerfTags.femalePrefab.hatEquipped, index);
                        break;
                    case ItemTtype.Footwear:
                        itemModelDataInstance.ChangeFemaleFootwearModels(index);
                        PlayerPrefs.SetInt(playerPerfTags.femalePrefab.footwearEquipped, index);
                        break;
                    case ItemTtype.Sunglasses:
                        itemModelDataInstance.ChangeFemaleSunglasses(index);
                        PlayerPrefs.SetInt(playerPerfTags.femalePrefab.sunglassesEquipped, index);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void EnableLastSelectedMale()
    {
        itemModelDataInstance.ChangeMaleTShirt(PlayerPrefs.GetInt(playerPerfTags.malePrefab.tShirtEquipped, 0));
        itemModelDataInstance.ChangeMaleTrousers(PlayerPrefs.GetInt(playerPerfTags.malePrefab.trouserEquipped, 0));
        itemModelDataInstance.ChangeMaleHair(PlayerPrefs.GetInt(playerPerfTags.malePrefab.hairEquipped, 0));
        itemModelDataInstance.ChangeMaleFacialHair(PlayerPrefs.GetInt(playerPerfTags.malePrefab.facialHairEquipped, 0));
        itemModelDataInstance.ChangeMaleHat(PlayerPrefs.GetInt(playerPerfTags.malePrefab.hatEquipped, 0));
        itemModelDataInstance.ChangeMaleFootwearModels(PlayerPrefs.GetInt(playerPerfTags.malePrefab.footwearEquipped, 0));
        itemModelDataInstance.ChangeMaleSunglasses(PlayerPrefs.GetInt(playerPerfTags.malePrefab.sunglassesEquipped, 0));
    }

    void EnableLastSelectedFemale()
    {
        itemModelDataInstance.ChangeFemaleTShirt(PlayerPrefs.GetInt(playerPerfTags.femalePrefab.tShirtEquipped, 0));
        itemModelDataInstance.ChangeFemaleTrousers(PlayerPrefs.GetInt(playerPerfTags.femalePrefab.trouserEquipped, 0));
        itemModelDataInstance.ChangeFemaleHair(PlayerPrefs.GetInt(playerPerfTags.femalePrefab.hairEquipped, 0));
        itemModelDataInstance.ChangeFemaleHat(PlayerPrefs.GetInt(playerPerfTags.femalePrefab.hatEquipped, 0));
        itemModelDataInstance.ChangeFemaleFootwearModels(PlayerPrefs.GetInt(playerPerfTags.femalePrefab.footwearEquipped, 0));
        itemModelDataInstance.ChangeFemaleSunglasses(PlayerPrefs.GetInt(playerPerfTags.femalePrefab.sunglassesEquipped, 0));
    }
}
