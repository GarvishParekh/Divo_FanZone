using Photon.Pun;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    public int playerID;
    [SerializeField] private GameObject C_playerID;
    
    public bool isPlayer = false;

    public void SetPlayerID (int _id)
    {
        Debug.Log("Button Pressed");
        playerID = _id;
        C_playerID.SetActive(false);
    }
}
