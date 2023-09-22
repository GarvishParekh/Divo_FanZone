using UnityEngine;

public class CharacterCreationManager : MonoBehaviour
{
    [Header (" Scriptable ")]
    [SerializeField] CharactarStats charactarStats;
    [SerializeField] CharacterCreatorScriptable ccInfo;

    [Header (" Model Holder ")]
    [SerializeField] Transform topsHolder;
    [SerializeField] Transform trouserHolder;
    [SerializeField] Transform hairHolder;
    [SerializeField] Transform facialHairHolder;
    [SerializeField] Transform hatHolder;
    [SerializeField] Transform footwearHolder;
    [SerializeField] Transform sunglassesHolder;

    #region Equipped Index
    int tShirtPerviousIndex = 0;
    int tShirtCurrentIndex = 0;


    int trousersPerviousIndex = 0;
    int trousersCurrentIndex = 0;


    int hairPerviousIndex = 0;
    int hairCurrentIndex = 0;


    int facialHairPerviousIndex = 0;
    int facialHairCurrentIndex = 0;


    int hatPerviousIndex = 0;
    int hatCurrentIndex = 0;


    int footwearPerviousIndex = 0;
    int footwearCurrentIndex = 0;


    int sunglasseserviousIndex = 0;
    int sunglassesurrentIndex = 0; 
    #endregion

    private void Awake()
    {
        ccInfo.selectedCatagory = CharacterCreatorScriptable.SelectedCatagory.TShirt;
    }

    private void Update()
    {
        CheckForTshirt();
        CheckForTrousers();
        CheckForHair();
        CheckForFacialHair();
        CheckForHat();
        CheckForFootwear();
        CheckForSunglasses();
    }

    void CheckForTshirt()
    {
        tShirtCurrentIndex = charactarStats.topEquipped;
        if (tShirtCurrentIndex != tShirtPerviousIndex)
        {
            DisableTops();
            topsHolder.GetChild(tShirtCurrentIndex).gameObject.SetActive(true);
            tShirtPerviousIndex = tShirtCurrentIndex;
        }
    }

    void CheckForTrousers()
    {
        trousersCurrentIndex = charactarStats.trouserEquipped;
        if (trousersCurrentIndex != trousersPerviousIndex)
        {
            DisableTrousers();
            trouserHolder.GetChild(trousersCurrentIndex).gameObject.SetActive(true);
            trousersPerviousIndex = trousersCurrentIndex;
        }
    }

    void CheckForHair()
    {
        hairCurrentIndex = charactarStats.hairEqiupped;
        if (hairCurrentIndex != hairPerviousIndex)
        {
            DisableHair();
            hairHolder.GetChild(hairCurrentIndex).gameObject.SetActive(true);
            hairPerviousIndex = hairCurrentIndex;
        }
    }

    void CheckForFacialHair()
    {
        facialHairCurrentIndex = charactarStats.facialHairEquipped;
        if (facialHairCurrentIndex != facialHairPerviousIndex)
        {
            DisableFacialHair();
            facialHairHolder.GetChild(facialHairCurrentIndex).gameObject.SetActive(true);
            facialHairPerviousIndex = facialHairCurrentIndex;
        }
    }

    void CheckForHat()
    {
        hatCurrentIndex = charactarStats.hatEqipped;
        if (hatCurrentIndex != hatPerviousIndex)
        {
            DisableHat();
            hatHolder.GetChild(hatCurrentIndex).gameObject.SetActive(true);
            hatPerviousIndex = hatCurrentIndex;
        }
    }

    void CheckForFootwear()
    {
        footwearPerviousIndex = charactarStats.footwearEquipped;
        if (footwearPerviousIndex != footwearCurrentIndex)
        {
            DisableFootwear();
            footwearHolder.GetChild(footwearPerviousIndex).gameObject.SetActive(true);
            footwearCurrentIndex = footwearPerviousIndex;
        }
    }

    void CheckForSunglasses()
    {
        sunglasseserviousIndex = charactarStats.sunGlassesEquipped;
        if (sunglasseserviousIndex != sunglassesurrentIndex)
        {
            DisableSunglasses();
            sunglassesHolder.GetChild(sunglasseserviousIndex).gameObject.SetActive(true);
            sunglassesurrentIndex = sunglasseserviousIndex;
        }
    }


    void DisableTops()
    {
        int loopCount = topsHolder.childCount;
        for (int i = 0; i < loopCount; i++)
        {
            topsHolder.GetChild(i).gameObject.SetActive(false);
        }
    }

    void DisableTrousers()
    {
        int loopCount = trouserHolder.childCount;
        for (int i = 0; i < loopCount; i++)
        {
            trouserHolder.GetChild(i).gameObject.SetActive(false);
        }
    }

    void DisableHair()
    {
        int loopCount = hairHolder.childCount;
        for (int i = 0; i < loopCount; i++)
        {
            hairHolder.GetChild(i).gameObject.SetActive(false);
        }
    }

    void DisableFacialHair()
    {
        int loopCount = facialHairHolder.childCount;
        for (int i = 0; i < loopCount; i++)
        {
            facialHairHolder.GetChild(i).gameObject.SetActive(false);
        }
    }

    void DisableHat()
    {
        int loopCount = hatHolder.childCount;
        for (int i = 0; i < loopCount; i++)
        {
            hatHolder.GetChild(i).gameObject.SetActive(false);
        }
    }

    void DisableFootwear()
    {
        int loopCount = footwearHolder.childCount;
        for (int i = 0; i < loopCount; i++)
        {
            footwearHolder.GetChild(i).gameObject.SetActive(false);
        }
    }

    void DisableSunglasses()
    {
        int loopCount = sunglassesHolder.childCount;
        for (int i = 0; i < loopCount; i++)
        {
            sunglassesHolder.GetChild(i).gameObject.SetActive(false);
        }
    }
}
