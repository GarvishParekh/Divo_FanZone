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

        //SetPositionAndRotation(M_PlayerController, OvrPlayerController, false, true, controllerOffsetValue);

        //SetPositionAndRotation(M_HandAnchor_L, OvrHandAnchor_L, true, positionOffset_L, rotationOffset_L);
        //SetPositionAndRotation(M_HandAnchor_R, OvrHandAnchor_R, true, positionOffset_R, rotationOffset_R);

        SetHead();
        SetHands();
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

    private void SetHands()
    {
        M_HandAnchor_L.position = OvrHandAnchor_L.TransformPoint(positionOffset_L);
        M_HandAnchor_L.rotation = OvrHandAnchor_L.rotation * Quaternion.Euler(rotationOffset_L);

        M_HandAnchor_R.position = OvrHandAnchor_R.TransformPoint(positionOffset_R);
        M_HandAnchor_R.rotation = OvrHandAnchor_R.rotation * Quaternion.Euler(rotationOffset_R);
    }

    private void SetHead()
    {
        headPosition.x = OvrCameraRig.position.x;
        headPosition.y = OvrPlayerController.position.y + controllerOffsetValue.y;
        headPosition.z = OvrCameraRig.position.z;

        M_PlayerController.position = headPosition;
        M_PlayerController.forward = Vector3.ProjectOnPlane(OvrCameraRig.forward, Vector3.up);
    }
}
