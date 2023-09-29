using Meta.WitAi;
using UnityEngine;
using UnityEngine.UI;

public class SetBodyType : MonoBehaviour
{
    [Header (" Scriptable Object ")]
    [SerializeField] private PlayerPerfTags playerPrefTag;
    [SerializeField] private CharacterInformation characterInfo;

    [Header (" Male Skin Renderer")]
    [SerializeField] private SkinnedMeshRenderer maleBodyMeshRenderer;

    [Space]
    [SerializeField] private SkinnedMeshRenderer[] maleTShirtMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer[] maleTrouserMeshRenderer;
    
    [Header (" Female Skin Renderer")]
    [SerializeField] private SkinnedMeshRenderer femaleBodyMeshRenderer;

    [Space]
    [SerializeField] private SkinnedMeshRenderer[] femaleTShirtMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer[] femaleTrouserMeshRenderer;

    [Header(" User Interface ")]
    [SerializeField] private Image thinImage;
    [SerializeField] private Image regularImage;
    [SerializeField] private Image fatImage;

    [Space]
    [SerializeField] private Toggle thinToggle; 
    [SerializeField] private Toggle regularToggle;
    [SerializeField] private Toggle fatToggle;

    private void Start()
    {
        int bodyType = PlayerPrefs.GetInt(playerPrefTag.userBodyType, 1);
        Debug.Log($"Body Type {bodyType}");

        if (bodyType == 0)
        {
            if (characterInfo.userGender == CharacterInformation.UserGender.Male)
                ChangeMaleBlendShapes(100, 0);
            else
                ChangeFemaleBlendShapes(100, 0);
        }
        else if (bodyType == 1)
        {
            if (characterInfo.userGender == CharacterInformation.UserGender.Male)
                ChangeMaleBlendShapes(0, 0);
            else
                ChangeFemaleBlendShapes(0, 0);
        }
        else if (bodyType == 2)
        {
            if (characterInfo.userGender == CharacterInformation.UserGender.Male)
                ChangeMaleBlendShapes(0, 100);
            else
                ChangeFemaleBlendShapes(0, 100);
        }

    }

    public void UpdateAppearanceUI()
    {
        if (characterInfo.userGender == CharacterInformation.UserGender.Male)
        {
            thinImage.sprite = characterInfo.maleThinSprite;
            regularImage.sprite = characterInfo.maleRegularSprite;
            fatImage.sprite = characterInfo.maleFatSprite;
        }
        else
        {
            thinImage.sprite = characterInfo.femaleThinSprite;
            regularImage.sprite = characterInfo.femaleRegularSprite;
            fatImage.sprite = characterInfo.femaleFatSprite;
        }
    }

    public void UpdatePhysicalAppearace_Thin()
    {
        if (thinToggle.isOn)
        {
            if (characterInfo.userGender == CharacterInformation.UserGender.Male)
                ChangeMaleBlendShapes(100, 0);
            else
                ChangeFemaleBlendShapes(100, 0);

            PlayerPrefs.SetInt(playerPrefTag.userBodyType, 0);
        }
    }

    public void UpdatePhysicalAppearace_Regular()
    {
        if (regularToggle.isOn)
        {
            if (characterInfo.userGender == CharacterInformation.UserGender.Male)
                ChangeMaleBlendShapes(0, 0);
            else
                ChangeFemaleBlendShapes(0, 0);
            
            PlayerPrefs.SetInt(playerPrefTag.userBodyType, 1);
        }
    }

    public void UpdatePhysicalAppearace_Fat()
    {
        if (fatToggle.isOn)
        {
            if (characterInfo.userGender == CharacterInformation.UserGender.Male)
                ChangeMaleBlendShapes(0, 100);
            else
                ChangeFemaleBlendShapes(0, 100);
            
            PlayerPrefs.SetInt(playerPrefTag.userBodyType, 2);
        }
    }

    private void ChangeMaleBlendShapes(int thinNode, int fatNode)
    {
        // set body blend shape
        maleBodyMeshRenderer.SetBlendShapeWeight(0, fatNode);    // fat node
        maleBodyMeshRenderer.SetBlendShapeWeight(1, thinNode);    // thin node

        // set T-Shirt blend shape
        for (int i = 0; i < maleTShirtMeshRenderer.Length; i++)
        {
            maleTShirtMeshRenderer[i].SetBlendShapeWeight(0, fatNode);    // fat node
            maleTShirtMeshRenderer[i].SetBlendShapeWeight(1, thinNode);    // thin node
        }

        // set Trousers blend shape
        for (int i = 0; i < maleTrouserMeshRenderer.Length; i++)
        {
            maleTrouserMeshRenderer[i].SetBlendShapeWeight(0, fatNode);   // fat node
            maleTrouserMeshRenderer[i].SetBlendShapeWeight(1, thinNode);   // thin node
        }
    }

    private void ChangeFemaleBlendShapes(int thinNode, int fatNode)
    {
        // set body blend shape
        femaleBodyMeshRenderer.SetBlendShapeWeight(0, fatNode);    // fat node
        femaleBodyMeshRenderer.SetBlendShapeWeight(1, thinNode);    // thin node

        // set T-Shirt blend shape
        for (int i = 0; i < femaleTShirtMeshRenderer.Length; i++)
        {
            femaleTShirtMeshRenderer[i].SetBlendShapeWeight(0, fatNode);    // fat node
            femaleTShirtMeshRenderer[i].SetBlendShapeWeight(1, thinNode);    // thin node
        }

        // set Trousers blend shape
        for (int i = 0; i < femaleTrouserMeshRenderer.Length; i++)
        {
            femaleTrouserMeshRenderer[i].SetBlendShapeWeight(0, fatNode);   // fat node
            femaleTrouserMeshRenderer[i].SetBlendShapeWeight(1, thinNode);   // thin node
        }
    }
}
