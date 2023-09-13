using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [Header (" Settings ")]
    public int playerID;

    [Header (" User Interface")]
    [SerializeField] private TMP_Text T_yourID;
    
    [Header (" Checks ")]
    public bool isPlayer = false;


    public void SetPlayerID (int _id)
    {
        Debug.Log("Button Pressed");
        playerID = _id;
        T_yourID.text = $"Your ID: {_id}";
    }
}
