using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class APIData : MonoBehaviour
{
    [SerializeField] APIManager_Fanzone apiManager;

    [Space]
    [SerializeField] private AudioSource BgMusicSource;
    [SerializeField] private TokenInfo tokenInfo;
    [SerializeField] private MaterialInfo matInfo;

    [SerializeField] private Texture2D myTexture;
    [SerializeField] private Texture2D loadedTexture;

    #region Action
    private void OnEnable() => APIManager_Fanzone.ApiRecived += OnAPIRecived;

    private void OnDisable() => APIManager_Fanzone.ApiRecived -= OnAPIRecived;
    #endregion

    private void OnAPIRecived()
    {
        int dataCount = apiManager.myData.data[0].slots.Length;
        for (int i = 0; i < dataCount; i++)
        {
            // Lobby Sponson_L
            if (tokenInfo.lobbySponsor_L == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.lobbySponsor_L_Mat));
            }

            // Lobby Sponson_R
            else if (tokenInfo.lobbySponsor_R == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.lobbySponsor_R_Mat));
            }

            // Football Pitch_1
            else if (tokenInfo.footballPitch_1 == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.footballPitch_1_Mat));
            }

            // Football Pitch_2
            else if (tokenInfo.footballPitch_2 == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.footballPitch_2_Mat));
            }

            // Football Pitch_3
            else if (tokenInfo.footballPitch_3 == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.footballPitch_3_Mat));
            }

            // TV Screen_1
            else if (tokenInfo.TVScreen_1 == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.TVScreen_1_Mat));
            }

            // TV Screen_2
            else if (tokenInfo.TVScreen_2 == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.TVScreen_2_Mat));
            }

            // Curved Screen_1
            else if (tokenInfo.curvedTVScreen_1 == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.curvedTVScreen_1_Mat));
            }

            // Curved Screen_2
            else if (tokenInfo.curvedTVScreen_2 == apiManager.myData.data[0].slots[i].token)
            {
                string textureURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetTexture(textureURL, matInfo.curvedTVScreen_2_Mat));
            }

            // BG Music
            else if (tokenInfo.BGMusic == apiManager.myData.data[0].slots[i].token)
            {
                string audioURL = apiManager.myData.data[0].slots[i].s3_value;
                StartCoroutine(GetMusic(audioURL, BgMusicSource));
            }
        }
    }

    IEnumerator GetTexture(string _imageURL, Material _material)
    {
        // send request for texture
        UnityWebRequest imageRquest = UnityWebRequestTexture.GetTexture(_imageURL);
        yield return imageRquest.SendWebRequest();

        // response
        if (imageRquest.error != null)
        {
            Debug.LogError(imageRquest.error);
        }
        else
        {
            myTexture = ((DownloadHandlerTexture)imageRquest.downloadHandler).texture;

            // increase Aniso level of the texture
            loadedTexture = new Texture2D(myTexture.width, myTexture.height, myTexture.format, true);
            loadedTexture.anisoLevel = 16;
            loadedTexture.LoadImage(imageRquest.downloadHandler.data);

            // load texture to material
            _material.SetTexture("_MainTex", loadedTexture);
        }
    }

    IEnumerator GetMusic(string _audioURL, AudioSource _audioSource)
    {
        // send request for texture
        UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip(_audioURL, AudioType.MPEG);
        yield return audioRequest.SendWebRequest();

        // response
        if (audioRequest.error != null)
        {
            Debug.LogError(audioRequest.error);
        }
        else
        {
            AudioClip _clip = DownloadHandlerAudioClip.GetContent(audioRequest);
            _audioSource.clip = _clip;
            _audioSource.Play();
        }
    }
}



[System.Serializable]
public struct TokenInfo
{
    [Header("[BG Music]")]
    public string BGMusic;

    [Space]
    [Header("[Lobby Sponsor]")]
    public string lobbySponsor_L;
    public string lobbySponsor_R;

    [Space]
    [Header("[Football Pitch Sponsor]")]
    public string footballPitch_1;
    public string footballPitch_2;
    public string footballPitch_3;
    
    [Space]
    [Header("[TV Screens]")]
    public string TVScreen_1;
    public string TVScreen_2;

    [Space]
    [Header("[Curved TV Screens]")]
    public string curvedTVScreen_1;
    public string curvedTVScreen_2;
}

[System.Serializable]
public struct MaterialInfo
{
    [Space]
    [Header("[Lobby Sponsor]")]
    public Material lobbySponsor_L_Mat;
    public Material lobbySponsor_R_Mat;

    [Space]
    [Header("[Football Pitch Sponsor]")]
    public Material footballPitch_1_Mat;
    public Material footballPitch_2_Mat;
    public Material footballPitch_3_Mat;

    [Space]
    [Header("[TV Screens]")]
    public Material TVScreen_1_Mat;
    public Material TVScreen_2_Mat;

    [Space]
    [Header("[Curved TV Screens]")]
    public Material curvedTVScreen_1_Mat;
    public Material curvedTVScreen_2_Mat;
}
