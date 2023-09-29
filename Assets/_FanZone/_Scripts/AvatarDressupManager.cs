using Photon.Pun;
using UnityEngine;
using System.Collections.Generic;

public class AvatarDressupManager : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;

    [SerializeField] private PlayerPerfTags playerPerfTags;
    [SerializeField] private ItemModelData itemModelData;

    [SerializeField] private GameObject maleModel;
    [SerializeField] private GameObject femaleModel;

    public List<ItemIndexs> avatarItems;

    private void Start()
    {
        photonView.RPC(nameof(Init), RpcTarget.AllBuffered);
    }

    [PunRPC]
    void Init ()
    {

        itemModelData = GetComponent<ItemModelData>();
        int _gender = PlayerPrefs.GetInt(playerPerfTags.userGender, 0);
        
        if (_gender == 0 )
            maleModel.SetActive(true); 
        else
            femaleModel.SetActive(true);
        
        GeIndexsMale();
        GeIndexsFemale();

        SetupAvatar();
    }

    void SetupAvatar()
    {
        SetupMaleAvatar();
        SetupFemaleAvatar();

    }

    void SetupMaleAvatar()
    {
        itemModelData.maleModels.tShirtModels[avatarItems[0].tShirtIndex].SetActive(true);
        itemModelData.maleModels.trousersModels[avatarItems[0].trouserIndex].SetActive(true);
        itemModelData.maleModels.hairModels[avatarItems[0].HairIndex].SetActive(true);
        itemModelData.maleModels.hatModels[avatarItems[0].HatIndex].SetActive(true);
        itemModelData.maleModels.footwearModels[avatarItems[0].FootwearIndex].SetActive(true);
        itemModelData.maleModels.sunglassesModels[avatarItems[0].SunglasseIndex].SetActive(true);

        itemModelData.maleModels.facialHairModels[avatarItems[0].FacialHairIndex].SetActive(true);
    }

    void SetupFemaleAvatar()
    {
        itemModelData.femaleModels.tShirtModels[avatarItems[1].tShirtIndex].SetActive(true);
        itemModelData.femaleModels.trousersModels[avatarItems[1].trouserIndex].SetActive(true);
        itemModelData.femaleModels.hairModels[avatarItems[1].HairIndex].SetActive(true);
        itemModelData.femaleModels.hatModels[avatarItems[1].HatIndex].SetActive(true);
        itemModelData.femaleModels.footwearModels[avatarItems[1].FootwearIndex].SetActive(true);
        itemModelData.femaleModels.sunglassesModels[avatarItems[1].SunglasseIndex].SetActive(true);
    }


    void GeIndexsMale()
    {
        ItemIndexs itemIndexs = new ItemIndexs();

        itemIndexs.tShirtIndex = PlayerPrefs.GetInt(playerPerfTags.malePrefab.tShirtEquipped, 0);
        itemIndexs.trouserIndex = PlayerPrefs.GetInt(playerPerfTags.malePrefab.trouserEquipped, 0);
        itemIndexs.HairIndex = PlayerPrefs.GetInt(playerPerfTags.malePrefab.hairEquipped, 0);
        itemIndexs.FacialHairIndex = PlayerPrefs.GetInt(playerPerfTags.malePrefab.facialHairEquipped, 0);
        itemIndexs.HatIndex = PlayerPrefs.GetInt(playerPerfTags.malePrefab.hatEquipped, 0);
        itemIndexs.FootwearIndex = PlayerPrefs.GetInt(playerPerfTags.malePrefab.footwearEquipped, 0);
        itemIndexs.SunglasseIndex = PlayerPrefs.GetInt(playerPerfTags.malePrefab.sunglassesEquipped, 0);

        avatarItems.Add(itemIndexs);
    }

    void GeIndexsFemale()
    {
        ItemIndexs itemIndexs = new ItemIndexs();

        itemIndexs.tShirtIndex = PlayerPrefs.GetInt(playerPerfTags.femalePrefab.tShirtEquipped, 0);
        itemIndexs.trouserIndex = PlayerPrefs.GetInt(playerPerfTags.femalePrefab.trouserEquipped, 0);
        itemIndexs.HairIndex = PlayerPrefs.GetInt(playerPerfTags.femalePrefab.hairEquipped, 0);
        itemIndexs.HatIndex = PlayerPrefs.GetInt(playerPerfTags.femalePrefab.hatEquipped, 0);
        itemIndexs.FootwearIndex = PlayerPrefs.GetInt(playerPerfTags.femalePrefab.footwearEquipped, 0);
        itemIndexs.SunglasseIndex = PlayerPrefs.GetInt(playerPerfTags.femalePrefab.sunglassesEquipped, 0);

        avatarItems.Add(itemIndexs);
    }
}

[System.Serializable]
public class ItemIndexs
{
    public int tShirtIndex;
    public int trouserIndex;
    public int HairIndex;
    public int FacialHairIndex;
    public int HatIndex;
    public int FootwearIndex;
    public int SunglasseIndex;

}
