using Photon.Pun;
using UnityEngine;
using UnityEngine.XR;

public class NetworkPlayer : MonoBehaviour
{
    PhotonView photonView;

    [SerializeField] private Transform mainPlayer;

    [Space]
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;


    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            mainPlayer = GameObject.Find("TrackingSpace").transform;

            transform.SetParent(mainPlayer);
            transform.localPosition = Vector3.zero;
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);

            MapNodes(leftHand, XRNode.LeftHand);
            MapNodes(rightHand, XRNode.RightHand);
        }
        else
        {
            leftHand.gameObject.SetActive(true);
            rightHand.gameObject.SetActive(true);
        }
    }

    private void MapNodes (Transform target, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.localPosition = position;
        target.localRotation = rotation;
    }
}
