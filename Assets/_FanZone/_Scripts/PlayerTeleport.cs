using TMPro;
using Photon.Pun;
using UnityEngine;
using System.Collections;

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
    [SerializeField] private bool teloportWithButtons = false;

    WaitForSeconds thirtySeconds = new WaitForSeconds(4);


    private void Start()
    {
        if (!photonView.IsMine)
            return;

        Application.targetFrameRate = 90;
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        if (isTeleproting)
            return;

        if (!teloportWithButtons) return;
        
        // Teleport to the balcony
        if (OVRInput.Get(OVRInput.Button.One)) 
            GroundToBalconyTeleport();

        // Teleport to the ground
        else if (OVRInput.Get(OVRInput.Button.Two))
            SpawnBackToGround();
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

    public void GroundToBalconyTeleport()
    {
        countdownCanvas.SetActive(true);
        StartCoroutine(nameof(GroundToBalconyCountdown));
    }

    public void SpawnBackToGround ()
    {
        playerController.enabled = false;

        player.position = groundPoint.position;
        playerController.enabled = true;
    }

    IEnumerator SpawnBack()
    {
        yield return thirtySeconds;
        SpawnBackToGround();
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

        StartCoroutine(nameof(SpawnBack));
    }

    private void TeleportPlayer(Transform _endPositionTransform)
    {
        playerController.enabled = false;

        player.position = _endPositionTransform.position;
        playerController.enabled = true;
    }
}
