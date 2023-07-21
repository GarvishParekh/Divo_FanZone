using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] private Animator playerAnimation;

    [Space]
    [SerializeField] private Transform player;
    [SerializeField] private Transform balconyPoint;
    [SerializeField] private Transform groundPoint;

    [Space]
    [SerializeField] private GameObject informationCanvas;

    [Space]
    [SerializeField] private OVRPlayerController playerController;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Application.targetFrameRate = 90;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) || OVRInput.Get(OVRInput.Button.One))
        {
            playerController.enabled = false;

            player.position = balconyPoint.position;
            playerController.enabled = true;
        }

        else if (OVRInput.Get(OVRInput.Button.Two))
        {
            playerController.enabled = false;

            player.position = groundPoint.position;
            playerController.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.B) || OVRInput.GetDown(OVRInput.Button.Three))
        {
            ToggleCanvas();
        }
    }

    private void ToggleCanvas()
    {
        if (informationCanvas.activeInHierarchy)
        {
            informationCanvas.SetActive(false);
        }
        else if (!informationCanvas.activeInHierarchy)
            informationCanvas.SetActive(true);
    }
}
