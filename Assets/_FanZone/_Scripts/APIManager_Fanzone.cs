using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class APIManager_Fanzone : MonoBehaviour
{
    public static Action ApiRecived;

    [SerializeField] private string apiURL;
    [SerializeField] private string fanzoneData;

    [Space]
    public string authToken;
    public string acceptToken;

    [Space]
    public myData myData;

    private void Start()
    {
        StartCoroutine("CallAPI", apiURL);
    }

    IEnumerator CallAPI(string apiURL)
    {
        UnityWebRequest request = UnityWebRequest.Get(apiURL);
        
        request.SetRequestHeader("Authorization", authToken);
        request.SetRequestHeader("Accept", acceptToken);
        
        yield return request.SendWebRequest();

        if(request.error == null)
        {
            fanzoneData = request.downloadHandler.text;

            myData = JsonUtility.FromJson<myData>(fanzoneData);

            ApiRecived?.Invoke();
        }
    }
}

[System.Serializable]
public class myData
{
    public MyData[] data;
}

[System.Serializable]
public class MyData
{
    public string id;
    public string name;
    public string file;

    [Space]
    public Slots[] slots;
}

[System.Serializable]
public class Slots
{
    public string id;
    public string name;
    public string token;
    public string s3_value;
    public string type;
}
