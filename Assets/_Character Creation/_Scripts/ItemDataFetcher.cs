using UnityEngine;
using UnityEngine.UI;

public class ItemDataFetcher : MonoBehaviour
{
    Toggle toggleButton;
    [Header (" Scriptable Elements ")]
    [SerializeField] private CharacterInformation characterInformation;
    [SerializeField] private ItemImages itemImageScriptable;
    [SerializeField] private PlayerPerfTags playerPrefTag;

    [SerializeField] private enum ItemTtype
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
    [Header(" Elements ")]
    [SerializeField] private CharacterGender characterGender;
    [SerializeField] private ItemTtype itemType;
    [SerializeField] private Image itemImage;

    [Header(" Settings ")]
    public int itemIndex;

    private void Start()
    {
        if (characterGender == CharacterGender.Male)
        {
            switch (itemType)
            {
                case ItemTtype.TShirt:
                    FetchMaleTShirts();
                    break;
                case ItemTtype.Trousers:
                    FetchMaleTrousers();
                    break;
                case ItemTtype.Hair:
                    FetchMaleHair();
                    break;
                case ItemTtype.FacialHair:
                    FetchMaleFacialHair();
                    break;
                case ItemTtype.Hat:
                    FetchMaleHat();
                    break;
                case ItemTtype.Footwear:
                    FetchMaleFootwear();
                    break;
                case ItemTtype.Sunglasses:
                    FetchMaleSunglasses();
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
                    FetchFemaleTShirts();
                    break;
                case ItemTtype.Trousers:
                    FetchFemaleTrousers();
                    break;
                case ItemTtype.Hair:
                    FetchFemaleHair();
                    break;
                case ItemTtype.Hat:
                    FetchFemaleHat();
                    break;
                case ItemTtype.Footwear:
                    FetchFemaleFootwear();
                    break;
                case ItemTtype.Sunglasses:
                    FetchFemaleSunglasses();
                    break;
                default:
                    break;
            }
        }


    }

    #region Male Fetcher
    private void FetchMaleTShirts()
    {
        itemImage.sprite = itemImageScriptable.maleSprites.tShirtSprites[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.malePrefab.tShirtEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    private void FetchMaleTrousers()
    {
        itemImage.sprite = itemImageScriptable.maleSprites.trouserSprites[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.malePrefab.trouserEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }

    private void FetchMaleHair()
    {
        itemImage.sprite = itemImageScriptable.maleSprites.hairSprites[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.malePrefab.hairEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }

    private void FetchMaleFacialHair()
    {
        itemImage.sprite = itemImageScriptable.maleSprites.facialHairSprites[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.malePrefab.facialHairEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    private void FetchMaleHat()
    {
        itemImage.sprite = itemImageScriptable.maleSprites.hatSprite[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.malePrefab.hatEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    private void FetchMaleFootwear()
    {
        itemImage.sprite = itemImageScriptable.maleSprites.footwearSprite[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.malePrefab.footwearEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    private void FetchMaleSunglasses()
    {
        itemImage.sprite = itemImageScriptable.maleSprites.sunglassesSprite[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.malePrefab.sunglassesEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    #endregion

    #region Female Fetcher
    private void FetchFemaleTShirts()
    {
        itemImage.sprite = itemImageScriptable.femaleSprites.tShirtSprites[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.femalePrefab.tShirtEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    private void FetchFemaleTrousers()
    {
        itemImage.sprite = itemImageScriptable.femaleSprites.trouserSprites[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.femalePrefab.trouserEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }

    private void FetchFemaleHair()
    {
        itemImage.sprite = itemImageScriptable.femaleSprites.hairSprites[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.femalePrefab.hairEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }

    private void FetchFemaleHat()
    {
        itemImage.sprite = itemImageScriptable.femaleSprites.hatSprite[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.femalePrefab.hatEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    private void FetchFemaleFootwear()
    {
        itemImage.sprite = itemImageScriptable.femaleSprites.footwearSprite[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.femalePrefab.footwearEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    private void FetchFemaleSunglasses()
    {
        itemImage.sprite = itemImageScriptable.femaleSprites.sunglassesSprite[itemIndex];
        int lastEquippedIndex = PlayerPrefs.GetInt(playerPrefTag.femalePrefab.sunglassesEquipped, 0);
        if (lastEquippedIndex == itemIndex)
        {
            toggleButton = GetComponent<Toggle>();
            toggleButton.isOn = true;
        }
    }
    #endregion
}
