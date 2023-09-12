using Photon.Pun;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    public int playerID;
    [SerializeField] private PhotonView photonView;
    [SerializeField] private GameObject C_playerID;
    
    public bool isPlayer = false;

    public void SetPlayerID (int _id)
    {
        if (!photonView.IsMine) return;


        playerID = _id;
        C_playerID.SetActive(false);
    }
}
