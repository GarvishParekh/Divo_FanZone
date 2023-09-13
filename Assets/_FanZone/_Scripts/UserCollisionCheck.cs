using TMPro;
using Photon.Pun;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class UserCollisionCheck : MonoBehaviour
{
    [Header (" Scripts Ref ")]
    [SerializeField] private APIManager_Fanzone apiManager;
    [SerializeField] private PlayerInfo playerIDInstance;
    [SerializeField] private PlayerTeleport playerTeleportInstance;
    
    [Header (" Photon Elemets ")]
    [SerializeField] private PhotonView photonView;

    [Header (" API Elemets ")]
    public string getUserURL;
    public string getUserStaticURL;
    public  string finalURL;
    [SerializeField] private string apiData;
    [SerializeField] private UserData userData;

    [Header(" User Interface ")]
    [SerializeField] private TMP_Text T_eventID;

    [Space]
    [SerializeField] private string userIDToCall;
    
    WaitForSeconds thirtySeconds = new WaitForSeconds(5);

    [Header (" User Data")]
    [SerializeField] List<int> userIDs;

    public bool isTesting = false;

    private void Start()
    {
        if(isTesting)
        {
            finalURL = getUserStaticURL;
        }
        else
        {
            ChangeEventID(155);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag ("Network Player"))
        {
            Debug.Log("User not entered");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag ("Network Player"))
        {
            PlayerCheck();
        }
    }

    public void PlayerCheck()
    {
        if (playerIDInstance.isPlayer)
            StartCoroutine(GetRequest(finalURL));
    }

    [PunRPC]
    void CallPlayerForMeeting(string _userID)
    {
        if (playerIDInstance.playerID.ToString() == _userID)
        {
            playerTeleportInstance.GroundToBalconyTeleport();
        }
    }

    public void ChangeEventID (int _eventID)
    {
        finalURL = getUserURL + _eventID.ToString();
        T_eventID.text = $"Current Event: {_eventID}";   
    }

    #region Get User ID To Spawn
    IEnumerator GetRequest(string URL)
    {
        Debug.Log("Get player");
        bool idMatched = false;
        UnityWebRequest request = UnityWebRequest.Get(URL);

        request.SetRequestHeader("Authorization", apiManager.authToken);
        request.SetRequestHeader("Accept", apiManager.acceptToken);

        yield return request.SendWebRequest();
        if (request.error == null)
        {
            Debug.Log("User ID recived");
            apiData = request.downloadHandler.text;
            userData = JsonUtility.FromJson<UserData>(apiData);

            userIDToCall = userData.data.user_id;
            Debug.Log($"User ID: {userIDToCall}");
        }

        for (int i = 0; i < userIDs.Count; i++)
        {
            if(userIDToCall == userIDs[i].ToString())
                idMatched = true;
            else
                idMatched = false;
        }

        if (idMatched)
            photonView.RPC(nameof(CallPlayerForMeeting), RpcTarget.All, userIDToCall);
        else
        {
            StartCoroutine(GetRequest(finalURL));
        }
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

