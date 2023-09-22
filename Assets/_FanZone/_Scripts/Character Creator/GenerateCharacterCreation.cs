using UnityEngine;
using UnityEngine.UI;

public class GenerateCharacterCreation : MonoBehaviour
{
    [SerializeField] private CharacterCreatorScriptable CCinfo;
    [SerializeField] private ItemPlayerPrefTags playerPrefTags;

    [SerializeReference] private ScrollRect scrollRect;
    [Header(" Elements ")]
    [SerializeField] Transform clothHolder;
    [SerializeField] private Image[] buttonImages;
    [SerializeField] private GameObject itemHolder;
    [SerializeField] private Transform viewPort;
    [SerializeField] private Item item;

    private void OnEnable()
    {
        CharactorCreaterUI.ButtonSelected += ChangeMenu;
    }

    private void OnDisable()
    {
        CharactorCreaterUI.ButtonSelected -= ChangeMenu;
    }

    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            buttonImages[i].sprite = CCinfo.buttonIconImage[i];
        }
        GenerateMenu(0);
    }


    private void GenerateMenu(int index)
    {
        int loopCount = CCinfo.itemData[index].itemImage.Length;

        GameObject itemHolderInstance = Instantiate(itemHolder, viewPort);
        scrollRect.content = itemHolderInstance.GetComponent<RectTransform>();
        ToggleGroup toggleGroup = itemHolderInstance.GetComponent<ToggleGroup>();
        for (int i = 0; i < loopCount; i++)
        {
            Item itemInstance = Instantiate(item, itemHolderInstance.transform);
            itemInstance.itemImage.sprite = CCinfo.itemData[index].itemImage[i];

            itemInstance._toggle.group = toggleGroup;
            itemInstance.toggleIndex = i;
        }
        int equippedIndex = PlayerPrefs.GetInt(playerPrefTags.itemTags[index], 0);
        Item firstItem = itemHolderInstance.transform.GetChild(equippedIndex).GetComponent<Item>();
        firstItem._toggle.isOn = true;
    }

    private void ChangeMenu()
    {
        ClearAllButtons();
        GenerateMenu((int)CCinfo.selectedCatagory);
    }

    void ClearAllButtons() => Destroy(viewPort.GetChild(0).gameObject);

    void OnItemSelected(int index)
    {
        Debug.Log(index);
        int loopCount = clothHolder.childCount;
        for (int i = 0; i < loopCount; i++)
        {
            clothHolder.GetChild(i).gameObject.SetActive(false);
        }
        clothHolder.GetChild(index).gameObject.SetActive(true);
    }
}
