using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;

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

        SetPositionAndRotation(M_PlayerController, OvrPlayerController, false, true, controllerOffsetValue);

        SetPositionAndRotation(M_HandAnchor_L, OvrHandAnchor_L, true, positionOffset_L, rotationOffset_L);
        SetPositionAndRotation(M_HandAnchor_R, OvrHandAnchor_R, true, positionOffset_R, rotationOffset_R);
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

    private void SetPositionAndRotation(Transform toChange, Transform target, bool isLocal, bool isCustomValues, Vector3 customValues)
    {
        if (isLocal)
        {
            toChange.localPosition = target.localPosition;
            toChange.localRotation = target.localRotation;
        }
        else
        {
            if (isCustomValues)
            {
                Vector3 newPosition = Vector3.zero;

                newPosition.x = target.position.x + customValues.x;
                newPosition.y = customValues.y;
                newPosition.z = target.position.z + customValues.z;

                toChange.position = newPosition;
                toChange.rotation = target.rotation;
            }
            else
            {
                toChange.position = target.position;
                toChange.rotation = target.rotation;
            }
        }
    }

    private void SetPositionAndRotation(Transform toChange, Transform target, bool isLocal)
    {
        if (isLocal)
        {
            toChange.position = target.position;
            toChange.rotation = target.rotation;
        }
        else
        {
            toChange.localPosition = target.localPosition;
            toChange.localRotation = target.localRotation;
        }
    }

    private void SetPositionAndRotation(Transform toChange, Transform target, bool isLocal, Vector3 positionOffset, Vector3 rotationOffset)
    {
        if (isLocal)
        {
            toChange.position = target.position + positionOffset;
            toChange.localRotation = target.rotation * Quaternion.EulerAngles(rotationOffset);
        }
        else
        {
            toChange.localPosition = target.localPosition + positionOffset;
            toChange.localRotation = target.rotation * Quaternion.EulerAngles(rotationOffset);

        }
    }
}
