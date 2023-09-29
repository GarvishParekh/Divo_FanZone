using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemButtonNavigation : MonoBehaviour
{
    [Header(" Scriptable Elements ")]
    [SerializeField] private CharacterInformation characterInfo;
    [SerializeField] private PlayerPerfTags playerPrefTag;

    [Header(" Elements ")]
    [SerializeField] private GameObject maleModel;
    [SerializeField] private GameObject femaleModel;

    [Header(" Main Canvas ")]
    [SerializeField] private GameObject genderSelectionCanvas;
    [SerializeField] private GameObject selectBodyCanvas;
    [SerializeField] private GameObject maleItemCanvas;
    [SerializeField] private GameObject femaleItemCanvas;
    [SerializeField] private GameObject editCanvas;

    [Header(" User Interface ")]
    [SerializeField] private MaleCanvas maleCanvas;
    [SerializeField] private FemaleCanvas femaleCanvas;

    public void _CreateNew()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        int _alreadyMade = PlayerPrefs.GetInt(playerPrefTag.alreadyMade, 0);
        Debug.Log($"Already Made: {_alreadyMade}");
        if (_alreadyMade == 0)
        {
            genderSelectionCanvas.SetActive(true);
            selectBodyCanvas.SetActive(false);
            maleItemCanvas.SetActive(false);
            femaleItemCanvas.SetActive(false);
            editCanvas.SetActive(false);
        }
        else if (_alreadyMade == 1)
        {
            genderSelectionCanvas.SetActive(false);
            selectBodyCanvas.SetActive(false);
            maleItemCanvas.SetActive(false);
            femaleItemCanvas.SetActive(false);
            editCanvas.SetActive(true);

            if (characterInfo.userGender == CharacterInformation.UserGender.Male)
                maleModel.SetActive(true);
            else if (characterInfo.userGender == CharacterInformation.UserGender.Female)
                femaleModel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void BodyTypeAndColorConfirmButton()
    {
        if (characterInfo.userGender == CharacterInformation.UserGender.Male)
            maleItemCanvas.SetActive(true);
        else if (characterInfo.userGender == CharacterInformation.UserGender.Female)
            femaleItemCanvas.SetActive(true);
    }

    public void FinalConfirmButton()
    {
        PlayerPrefs.SetInt(playerPrefTag.alreadyMade, 1);
        SceneManager.LoadScene("Divo_Fanzone");
    }
    
    public void OpenPanel(GameObject desireCanvas)
    {
        CloseMaleCanvas();
        CloseFemaleCanvas();

        desireCanvas.SetActive(true);
    }

    public void CloseMaleCanvas()
    {
        maleCanvas.tShirtCanvas.SetActive(false);
        maleCanvas.trouserCanvas.SetActive(false);
        maleCanvas.hairCanvas.SetActive(false);
        maleCanvas.facialHairCanvas.SetActive(false);
        maleCanvas.hatCanvas.SetActive(false);
        maleCanvas.footwearCanvas.SetActive(false);
        maleCanvas.sunglassesCanvas.SetActive(false);
    }

    public void CloseFemaleCanvas()
    {
        femaleCanvas.tShirtCanvas.SetActive(false);
        femaleCanvas.trouserCanvas.SetActive(false);
        femaleCanvas.hairCanvas.SetActive(false);
        femaleCanvas.hatCanvas.SetActive(false);
        femaleCanvas.footwearCanvas.SetActive(false);
        femaleCanvas.sunglassesCanvas.SetActive(false);
    }
}

[System.Serializable]
public class MaleCanvas
{
    public GameObject tShirtCanvas;
    public GameObject trouserCanvas;
    public GameObject hairCanvas;
    public GameObject facialHairCanvas;
    public GameObject hatCanvas;
    public GameObject footwearCanvas;
    public GameObject sunglassesCanvas;
}


[System.Serializable]
public class FemaleCanvas
{
    public GameObject tShirtCanvas;
    public GameObject trouserCanvas;
    public GameObject hairCanvas;
    public GameObject hatCanvas;
    public GameObject footwearCanvas;
    public GameObject sunglassesCanvas;
}