using Photon.Pun;
using UnityEngine;

public class LegController : MonoBehaviour
{
    [Header("Photon components")]
    [SerializeField] private PhotonView photonView;

    [Header ("Animation components")]
    [SerializeField] private Animator playerAnimation;
    [SerializeField] float playerSpeed;

    [Header ("Animation tags")]
    [SerializeField] string walking;
    [SerializeField] string forwardSpeed;
    [SerializeField] string sideSpeed;

    [Header("Values")]
    [SerializeField] private float input_X;
    [SerializeField] private float input_Y;

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        input_X = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        input_Y = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

        if (input_X == 0 && input_Y == 0)
        {
            playerAnimation.SetBool(walking, false);
        }
        else
        {
            playerAnimation.SetBool(walking, true);
            playerAnimation.SetFloat(forwardSpeed, input_Y);
            playerAnimation.SetFloat(sideSpeed, input_X);
        }

    }
}
