using Photon.Pun;
using UnityEngine;
using Unity.Mathematics;

public class SyncWithOVR : MonoBehaviour
{
    PhotonView photonView;

    [Header ("OVR Components")]
    [SerializeField] private Transform OvrPlayerController;
    [SerializeField] private Transform OvrCameraRig;
    [SerializeField] private Transform OvrTrackingSpace;

    [Space]
    [SerializeField] private Transform OvrHandAnchor_L;
    [SerializeField] private Transform OvrHandAnchor_R;

    [Header ("Multiplayer Conponents")]
    [SerializeField] private Vector3 controllerOffsetValue;
    [SerializeField] private Transform M_PlayerController;

    [Space]
    [SerializeField] private Transform M_HandAnchor_L;
    public Vector3 positionOffset_L;
    [SerializeField] private Vector3 rotationOffset_L;

    [Space]
    [SerializeField] private Transform M_HandAnchor_R;
    [SerializeField] private Vector3 positionOffset_R;
    [SerializeField] private Vector3 rotationOffset_R;

    [SerializeField] private quaternion rotationOffset;

    Vector3 headPosition = Vector3.zero;

    [Header("Animations components")]
    [SerializeField] private Animator handAnimation;


    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
            return;
        GetOVRPoints();
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        SetHandAndHead();
    }

    private void GetOVRPoints()
    {
        OvrPlayerController = GameObject.FindGameObjectWithTag("Player").transform;

        if (OvrPlayerController != null)
        {
            OvrCameraRig = OvrPlayerController.GetChild(1);
            OvrTrackingSpace = OvrCameraRig.GetChild(0);

            OvrHandAnchor_L = OvrTrackingSpace.GetChild(4);
            OvrHandAnchor_R = OvrTrackingSpace.GetChild(5);
        }
    }

    private void SetHandAndHead()
    {
        #region Hands
        M_HandAnchor_L.position = OvrHandAnchor_L.TransformPoint(positionOffset_L);
        M_HandAnchor_L.rotation = OvrHandAnchor_L.rotation * Quaternion.Euler(rotationOffset_L);

        M_HandAnchor_R.position = OvrHandAnchor_R.TransformPoint(positionOffset_R);
        M_HandAnchor_R.rotation = OvrHandAnchor_R.rotation * Quaternion.Euler(rotationOffset_R);
        #endregion

        #region Head
        headPosition.x = OvrCameraRig.position.x + controllerOffsetValue.x;
        headPosition.y = OvrPlayerController.position.y + controllerOffsetValue.y;
        headPosition.z = OvrCameraRig.position.z;

        M_PlayerController.position = headPosition;
        M_PlayerController.forward = Vector3.ProjectOnPlane(OvrCameraRig.forward, Vector3.up);
        #endregion
    }
}
