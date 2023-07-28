using TMPro;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private string playerPrefabName;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject playerPrefab;

    [Space]
    public Transform leftHandAnchor;
    public Transform rightHandAnchor;

    [Space]
    [SerializeField] private TMP_Text T_connectionStatus;

    [Header ("PLUGIN")]
    [SerializeField] private HandResetController handController;

    private void Start() => ConnectToPhotonNetwork();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    #region Network connection
    private void ConnectToPhotonNetwork()
    {
        T_connectionStatus.text = "Connecting to network....";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        T_connectionStatus.text = "Connected to photon network \n <size=0.04> Joining room";
        JoinOrCreateRoom("Test Room");
    }
    #endregion

    #region Room connection
    private void JoinOrCreateRoom (string roomName)
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        T_connectionStatus.text = $"Connected to: <b>{PhotonNetwork.CurrentRoom.Name}";
        playerPrefab = PhotonNetwork.Instantiate(playerPrefabName, transform.position, Quaternion.identity);
        handController.GetNetworkPlayer(playerPrefab);
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Destroy(playerPrefab);
    }
    #endregion
}
