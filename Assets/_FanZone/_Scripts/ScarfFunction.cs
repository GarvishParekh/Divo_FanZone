using Photon.Pun;
using UnityEngine;
using Unity.Mathematics;

public class ScarfFunction : MonoBehaviour
{
    [Header(" Multiplayer Elements ")]
    [SerializeField] private PhotonView photonView;


    [Header(" Elements ")]
    [SerializeField] private Transform scarfTransform;
    [SerializeField] private SpriteRenderer scarfRenderer;
    [SerializeField] private Transform handTransform;
    [SerializeField] private GameObject informationCanvas;


    [Header(" Runtime Elements ")]
    [SerializeField] private Transform mainCameraTransform;

    bool isEquiped = false;

    private void Start()
    {
        mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        EquipScarf(false);
    }

    private void Update()
    {
        if (!photonView.IsMine) return;

        // equip / unequip the scarf
        if (OVRInput.GetDown(OVRInput.Button.Four) || Input.GetKeyDown(KeyCode.E))
            photonView.RPC(nameof(EquipFunction), RpcTarget.AllBuffered);

        // start rotating the scarf
        if (isEquiped) RotateScarfToCamera();
    }

    [PunRPC]
    private void EquipFunction()
    {
        // if not equiped
        if (!isEquiped) isEquiped = true;

        // if equiped
        else isEquiped = false;

        EquipScarf(isEquiped);
    }

    // scarf will look at camera
    private void RotateScarfToCamera()
    {
        if (mainCameraTransform != null)
        {
            scarfTransform.LookAt(mainCameraTransform.position);
            Vector3 rotationVector = new Vector3(0, transform.rotation.y, 0);

            scarfTransform.rotation = quaternion.Euler(rotationVector);
        }

        Vector3 handVector = handTransform.position;
        transform.position = handVector;
    }

    private void EquipScarf(bool _equip) => scarfRenderer.enabled = _equip;
}
