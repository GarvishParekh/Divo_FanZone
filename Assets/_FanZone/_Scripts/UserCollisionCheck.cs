using TMPro;
using Photon.Pun;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class UserCollisionCheck : MonoBehaviour
{
    [SerializeField] private APIInformation apiInformation;
    [Header(" Scripts Ref ")]
    [SerializeField] private PlayerInfo playerIDInstance;
    [SerializeField] private PlayerTeleport playerTeleportInstance;

    [Header(" Photon Elemets ")]
    [SerializeField] private PhotonView photonView;

    [Header(" API Elemets ")]
    public string finalURL;
    [SerializeField] private string apiData;
    [SerializeField] private UserData userData;

    [Header(" User Interface ")]
    [SerializeField] private TMP_Text T_eventID;


    string userIDToCall;
    WaitForSeconds thirtySeconds = new WaitForSeconds(5);

    [Header(" User Data")]
    [SerializeField] List<int> userIDs;

    public bool isTesting = false;

    private void Start()
    {
        if (apiInformation.testing) finalURL = apiInformation.GetUserURL_Static;
        
        else ChangeEventID(156);
    }


    public void CallGetUserAPI()
    {
        if (playerIDInstance.isPlayer)
            StartCoroutine(GetRequest(finalURL));
    }

    [PunRPC]
    void CallPlayerForMeeting(string _userID)
    {
        if (playerIDInstance.playerID.ToString() == _userID)
            playerTeleportInstance.GroundToBalconyTeleport();
    }

    public void ChangeEventID(int _eventID)
    {
        finalURL = apiInformation.GetUserURL + _eventID.ToString();
        T_eventID.text = $"Current Event: {_eventID}";
    }

    #region Get User ID To Spawn
    IEnumerator GetRequest(string URL)
    {
        Debug.Log("Get player");
        UnityWebRequest request = UnityWebRequest.Get(URL);

        request.SetRequestHeader("Authorization", apiInformation.AuthToken);
        request.SetRequestHeader("Accept", apiInformation.AcceptToken);

        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log("User ID recived");
            apiData = request.downloadHandler.text;
            userData = JsonUtility.FromJson<UserData>(apiData);

            userIDToCall = userData.data.user_id;
            Debug.Log($"User ID: {userIDToCall}");
        }

        photonView.RPC(nameof(CallPlayerForMeeting), RpcTarget.All, userIDToCall);
    }
    #endregion
}

#region API Data Classes
[System.Serializable]
public class UserData
{
    public UserData_data data;
}

[System.Serializable]
public class UserData_data
{
    public string user_id;
}
#endregion

