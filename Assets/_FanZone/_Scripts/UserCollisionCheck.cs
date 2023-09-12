using Photon.Pun;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class UserCollisionCheck : MonoBehaviour
{
    [SerializeField] private APIManager_Fanzone apiManager;
    [SerializeField] private PhotonView photonView;
    [SerializeField] private PlayerID playerIDInstance;
    [SerializeField] private PlayerTeleport playerTeleportInstance;

    [Space]
    [SerializeField] private string apiData;
    WaitForSeconds thirtySeconds = new WaitForSeconds(5);

    public string getUserURL;
    [SerializeField] private string userIDToCall;

    [SerializeField] private UserData userData;


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag ("Network Player"))
        {
            PlayerCheck();
            Debug.Log("NO PLAYER AVAILABLE");
        }
    }

    public void PlayerCheck()
    {
        if (playerIDInstance.isPlayer)
        {
            StartCoroutine(GetRequest(getUserURL));
        }
    }

    [PunRPC]
    void CallPlayerForMeeting(string _userID)
    {
        if (playerIDInstance.playerID.ToString() == _userID)
        {
            playerTeleportInstance.GroundToBalconyTeleport();
        }
    }


    IEnumerator GetRequest(string URL)
    {
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
        }

        photonView.RPC(nameof(CallPlayerForMeeting), RpcTarget.All, userIDToCall);
    }
}

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

