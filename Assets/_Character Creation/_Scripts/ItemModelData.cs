using UnityEngine;

public class ItemModelData : MonoBehaviour
{
    public static ItemModelData instance;

    public MaleModels maleModels;
    public FemaleModels femaleModels;

    private void Awake() => instance = this;

    #region Male Function
    #region T-Shirt
    public void ChangeMaleTShirt(int index)
    {
        CloseAllMaleTshirt();
        maleModels.tShirtModels[index].SetActive(true);
    }

    public void CloseAllMaleTshirt()
    {
        for (int i = 0; i < maleModels.tShirtModels.Length; i++)
        {
            maleModels.tShirtModels[i].SetActive(false);
        }
    }
    #endregion

    #region T-Trousers
    public void ChangeMaleTrousers(int index)
    {
        CloseAllMaleTrousers();
        maleModels.trousersModels[index].SetActive(true);
    }

    public void CloseAllMaleTrousers()
    {
        for (int i = 0; i < maleModels.trousersModels.Length; i++)
        {
            maleModels.trousersModels[i].SetActive(false);
        }
    }
    #endregion

    #region Hair
    public void ChangeMaleHair(int index)
    {
        CloseAllMaleHair();
        maleModels.hairModels[index].SetActive(true);
    }

    public void CloseAllMaleHair()
    {
        for (int i = 0; i < maleModels.hairModels.Length; i++)
        {
            maleModels.hairModels[i].SetActive(false);
        }
    }
    #endregion

    #region FacialHair
    public void ChangeMaleFacialHair(int index)
    {
        CloseAllMaleFacialHair();
        maleModels.facialHairModels[index].SetActive(true);
    }

    public void CloseAllMaleFacialHair()
    {
        for (int i = 0; i < maleModels.facialHairModels.Length; i++)
        {
            maleModels.facialHairModels[i].SetActive(false);
        }
    }
    #endregion

    #region FacialHair
    public void ChangeMaleHat(int index)
    {
        CloseAllMaleHat();
        maleModels.hatModels[index].SetActive(true);
    }

    public void CloseAllMaleHat()
    {
        for (int i = 0; i < maleModels.hatModels.Length; i++)
        {
            maleModels.hatModels[i].SetActive(false);
        }
    }
    #endregion

    #region Footwear
    public void ChangeMaleFootwearModels(int index)
    {
        CloseAllMaleFootwearModels();
        maleModels.footwearModels[index].SetActive(true);
    }

    public void CloseAllMaleFootwearModels()
    {
        for (int i = 0; i < maleModels.footwearModels.Length; i++)
        {
            maleModels.footwearModels[i].SetActive(false);
        }
    }
    #endregion

    #region Sunglasses
    public void ChangeMaleSunglasses(int index)
    {
        CloseAllMaleSunglassesModels();
        maleModels.sunglassesModels[index].SetActive(true);
    }

    public void CloseAllMaleSunglassesModels()
    {
        for (int i = 0; i < maleModels.sunglassesModels.Length; i++)
        {
            maleModels.sunglassesModels[i].SetActive(false);
        }
    }
    #endregion 
    #endregion

    #region T-Shirt
    public void ChangeFemaleTShirt(int index)
    {
        CloseAllFemaleTshirt();
        femaleModels.tShirtModels[index].SetActive(true);
    }

    public void CloseAllFemaleTshirt()
    {
        for (int i = 0; i < femaleModels.tShirtModels.Length; i++)
        {
            femaleModels.tShirtModels[i].SetActive(false);
        }
    }
    #endregion

    #region T-Trousers
    public void ChangeFemaleTrousers(int index)
    {
        CloseAllfemaleTrousers();
        femaleModels.trousersModels[index].SetActive(true);
    }

    public void CloseAllfemaleTrousers()
    {
        for (int i = 0; i < femaleModels.trousersModels.Length; i++)
        {
            femaleModels.trousersModels[i].SetActive(false);
        }
    }
    #endregion

    #region Hair
    public void ChangeFemaleHair(int index)
    {
        CloseAllfemaleHair();
        femaleModels.hairModels[index].SetActive(true);
    }

    public void CloseAllfemaleHair()
    {
        for (int i = 0; i < femaleModels.hairModels.Length; i++)
        {
            femaleModels.hairModels[i].SetActive(false);
        }
    }
    #endregion

    #region FacialHair
    public void ChangeFemaleHat(int index)
    {
        CloseAllfemaleHat();
        femaleModels.hatModels[index].SetActive(true);
    }

    public void CloseAllfemaleHat()
    {
        for (int i = 0; i < femaleModels.hatModels.Length; i++)
        {
            femaleModels.hatModels[i].SetActive(false);
        }
    }
    #endregion

    #region Footwear
    public void ChangeFemaleFootwearModels(int index)
    {
        CloseAllfemaleFootwearModels();
        femaleModels.footwearModels[index].SetActive(true);
    }

    public void CloseAllfemaleFootwearModels()
    {
        for (int i = 0; i < femaleModels.footwearModels.Length; i++)
        {
            femaleModels.footwearModels[i].SetActive(false);
        }
    }
    #endregion

    #region Sunglasses
    public void ChangeFemaleSunglasses(int index)
    {
        CloseAllfemaleSunglassesModels();
        femaleModels.sunglassesModels[index].SetActive(true);
    }

    public void CloseAllfemaleSunglassesModels()
    {
        for (int i = 0; i < femaleModels.sunglassesModels.Length; i++)
        {
            femaleModels.sunglassesModels[i].SetActive(false);
        }
    }
    #endregion
}

[System.Serializable]
public class MaleModels
{
    public GameObject[] tShirtModels;
    public GameObject[] trousersModels;
    public GameObject[] hairModels;
    public GameObject[] facialHairModels;
    public GameObject[] hatModels;
    public GameObject[] footwearModels;
    public GameObject[] sunglassesModels;
}

[System.Serializable]
public class FemaleModels
{
    public GameObject[] tShirtModels;
    public GameObject[] trousersModels;
    public GameObject[] hairModels;
    public GameObject[] hatModels;
    public GameObject[] footwearModels;
    public GameObject[] sunglassesModels;
}
