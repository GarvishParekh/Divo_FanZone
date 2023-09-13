using TMPro;
using Photon.Pun;
using UnityEngine;
using System.Collections;

public class PlayerTeleport : MonoBehaviour
{
    [Header (" Photon Elements ")]
    [SerializeField] private PhotonView photonView;
    [SerializeField] private Animator playerAnimation;

    [Header (" Unity Components ")]
    [SerializeField] private Transform playerTransform;
    
    [Header (" Spawn Points ")]
    [SerializeField] private Transform balconyPointTransform;
    [SerializeField] private Transform groundTransform;

    [Header(" User Interface ")]
    [SerializeField] private GameObject informationCanvas;
    [SerializeField] private GameObject countdownCanvas;
    [SerializeField] private TMP_Text T_countdown;

    [Header(" Oculus Elements ")]
    [SerializeField] private OVRPlayerController oculusController;

    [Header(" Checks ")]
    [SerializeField] private bool isTeleproting = false;
    [SerializeField] private bool teloportWithButtons = false;

    private WaitForSeconds oneSecond = new WaitForSeconds(1);
    WaitForSeconds thirtySeconds = new WaitForSeconds(30);


    private void Start()
    {
        if (!photonView.IsMine)
            return;

        Application.targetFrameRate = 90;
    }

    private void Update()
    {
        #region Testing
        // if playerTransform is already spawning
        if (isTeleproting) return;

        if (!teloportWithButtons) return;

        SpawnPlayerWithButtons(); 
        #endregion
    }

    private void SpawnPlayerWithButtons ()
    {
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

    #region Public Functions For Spawning
    public void GroundToBalconyTeleport()
    {
        countdownCanvas.SetActive(true);
        StartCoroutine(nameof(GroundToBalconyCountdown));
    }

    public void SpawnBackToGround()
    {
        oculusController.enabled = false;

        playerTransform.position = groundTransform.position;
        oculusController.enabled = true;
    } 
    #endregion

    #region Spawning Functions
    // Spawn to balcony
    IEnumerator GroundToBalconyCountdown()
    {
        isTeleproting = true;

        // countdown for user
        for (int i = 0; i < 6; i++)
        {
            T_countdown.gameObject.SetActive(false);
            T_countdown.gameObject.SetActive(true);

            T_countdown.text = $"{5 - i}";
            yield return oneSecond;
        }
        isTeleproting = false;

        playerTransform.position = balconyPointTransform.position;

        TeleportPlayer(balconyPointTransform);
        countdownCanvas.SetActive(false);

        // spawn the playerTransform back to ground
        StartCoroutine(nameof(SpawnBack));
    }

    // Spawn to ground
    IEnumerator SpawnBack()
    {
        yield return thirtySeconds;
        SpawnBackToGround();
    } 
    #endregion

    private void TeleportPlayer(Transform _endPositionTransform)
    {
        oculusController.enabled = false;

        playerTransform.position = _endPositionTransform.position;
        oculusController.enabled = true;
    }
}
