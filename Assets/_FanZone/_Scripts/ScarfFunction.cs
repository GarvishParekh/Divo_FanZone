using Photon.Pun;
using UnityEngine;
using Unity.Mathematics;

public class ScarfFunction : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;

    [SerializeField] private SpriteRenderer scarfRenderer;

    [SerializeField] private Transform mainCameraTransform;
    [SerializeField] private Transform handTransform;

    [SerializeField] private GameObject informationCanvas;

    bool isShowing = false;

    private void Start()
    {
        mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        if (photonView.IsMine)
        {
            //HideScarf();
        }
        else
        {
            informationCanvas.SetActive(false);
        }
    }

    private void Update()
    {
        if (mainCameraTransform != null)
        {
            transform.LookAt(mainCameraTransform.position);
            Vector3 rotationVector = new Vector3(0, transform.rotation.y, 0);

            transform.rotation = quaternion.Euler(rotationVector);
        }

        Vector3 handVector = handTransform.position;
        transform.position = handVector;

        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            if (!isShowing)
            {
                ShowScarf();
                isShowing = true;
            }
            else
            {
                HideScarf();
                isShowing = false;
            }
        }
    }

    private void ShowScarf() => scarfRenderer.enabled = true;

    private void HideScarf() => scarfRenderer.enabled = false;
}
