using TMPro;
using Photon.Pun;
using UnityEngine;
using System.Collections;
using System;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;
    [SerializeField] private Animator playerAnimation;

    [Space]
    [SerializeField] private Transform player;
    [SerializeField] private Transform balconyPointTransform;
    [SerializeField] private Transform groundPoint;

    [Header("Canvas")]
    [SerializeField] private GameObject informationCanvas;
    [SerializeField] private GameObject countdownCanvas;
    [SerializeField] private TMP_Text T_countdown;

    [Space]
    [SerializeField] private OVRPlayerController playerController;

    private WaitForSeconds oneSecond = new WaitForSeconds(1);

    [SerializeField] private bool isTeleproting = false;


    private void Start()
    {
        if (!photonView.IsMine)
            return;

        Application.targetFrameRate = 90;
    }

    private void Update()
    {

        if (isTeleproting)
            return;

        if (Input.GetKeyDown(KeyCode.L) || OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("Pressed");
            GroundToBalconyTeleport();
        }

        else if (OVRInput.Get(OVRInput.Button.Two))
        {
            playerController.enabled = false;

            player.position = groundPoint.position;
            playerController.enabled = true;
        }

        /*
        if (Input.GetKeyDown(KeyCode.B) || OVRInput.GetDown(OVRInput.Button.Three))
        {
            ToggleCanvas();
        }
        */
    }

    private void ToggleCanvas()
    {
        if (!photonView.IsMine)
            return;

        if (informationCanvas.activeInHierarchy)
        {
            informationCanvas.SetActive(false);
        }
        else if (!informationCanvas.activeInHierarchy)
            informationCanvas.SetActive(true);
    }

    private void GroundToBalconyTeleport()
    {
        countdownCanvas.SetActive(true);
        StartCoroutine(nameof(GroundToBalconyCountdown));
    }

    IEnumerator GroundToBalconyCountdown()
    {
        isTeleproting = true;
        for (int i = 0; i < 6; i++)
        {
            T_countdown.gameObject.SetActive(false);
            T_countdown.gameObject.SetActive(true);

            T_countdown.text = $"{5 - i}";
            yield return oneSecond;
        }
        isTeleproting = false;

        player.position = balconyPointTransform.position;

        TeleportPlayer(balconyPointTransform);
        countdownCanvas.SetActive(false);
    }

    private void TeleportPlayer(Transform _endPositionTransform)
    {
        playerController.enabled = false;

        player.position = _endPositionTransform.position;
        playerController.enabled = true;
    }
}
