using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] ItemPlayerPrefTags playerPrefTags;
    [SerializeField] CharactarStats CharactarStats;
    [SerializeField] CharacterCreatorScriptable ccInfo;
    public Toggle _toggle;
    public Image itemImage;
    public int toggleIndex = 0;

  

    public void _OnSelected ()
    {
        if (_toggle.isOn)
        {
            switch(ccInfo.selectedCatagory)
            {
                case CharacterCreatorScriptable.SelectedCatagory.TShirt:
                    CharactarStats.topEquipped = toggleIndex;
                    PlayerPrefs.SetInt(playerPrefTags.itemTags[0], toggleIndex);

                    break;

                case CharacterCreatorScriptable.SelectedCatagory.Trousers:
                    CharactarStats.trouserEquipped = toggleIndex;
                    PlayerPrefs.SetInt(playerPrefTags.itemTags[1], toggleIndex);
                    break;

                case CharacterCreatorScriptable.SelectedCatagory.Hair:
                    CharactarStats.hairEqiupped= toggleIndex;
                    PlayerPrefs.SetInt(playerPrefTags.itemTags[2], toggleIndex);
                    break;

                case CharacterCreatorScriptable.SelectedCatagory.FacialHair:
                    CharactarStats.facialHairEquipped = toggleIndex;
                    PlayerPrefs.SetInt(playerPrefTags.itemTags[3], toggleIndex);
                    break;

                case CharacterCreatorScriptable.SelectedCatagory.Hat:
                    CharactarStats.hatEqipped = toggleIndex;
                    PlayerPrefs.SetInt(playerPrefTags.itemTags[4], toggleIndex);
                    break;

                case CharacterCreatorScriptable.SelectedCatagory.Footwear:
                    CharactarStats.footwearEquipped = toggleIndex;
                    PlayerPrefs.SetInt(playerPrefTags.itemTags[5], toggleIndex);
                    break;

                case CharacterCreatorScriptable.SelectedCatagory.Sunglassess:
                    CharactarStats.sunGlassesEquipped = toggleIndex;
                    PlayerPrefs.SetInt(playerPrefTags.itemTags[6], toggleIndex);
                    break;
            }
        }
    }
}
