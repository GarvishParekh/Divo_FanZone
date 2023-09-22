using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CharactorCreaterUI : MonoBehaviour
{
    public static Action ButtonSelected;

    [SerializeField] CharacterCreatorScriptable characterCreatorScriptable;
    [SerializeField] private Toggle[] catagoryToggle;

    [SerializeField] TMP_Text headerText;
    [SerializeField] string[] headerTittle;

    public void _CatagoryButtonClicked(int selectedIndex)
    {
        if (catagoryToggle[selectedIndex].isOn)
        {
            characterCreatorScriptable.selectedCatagory = (CharacterCreatorScriptable.SelectedCatagory)selectedIndex;
            OnSelected();
            ButtonSelected?.Invoke();
        }
        else
        {
            return;
        }
    }

    private void OnSelected()
    {
        switch (characterCreatorScriptable.selectedCatagory)
        {
            case CharacterCreatorScriptable.SelectedCatagory.TShirt:
                headerText.text = headerTittle[0];
                break;
            case CharacterCreatorScriptable.SelectedCatagory.Trousers:
                headerText.text = headerTittle[1];
                break;
            case CharacterCreatorScriptable.SelectedCatagory.Hair:
                headerText.text = headerTittle[2];
                break;
            case CharacterCreatorScriptable.SelectedCatagory.FacialHair:
                headerText.text = headerTittle[3];
                break;
            case CharacterCreatorScriptable.SelectedCatagory.Hat:
                headerText.text = headerTittle[4];
                break;
            case CharacterCreatorScriptable.SelectedCatagory.Footwear:
                headerText.text = headerTittle[5];
                break;
            case CharacterCreatorScriptable.SelectedCatagory.Sunglassess:
                headerText.text = headerTittle[6];
                break;
            default:
                break;
        }
    }
}

