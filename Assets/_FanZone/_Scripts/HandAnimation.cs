using Photon.Pun;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] PhotonView photonView;

    [SerializeField] private enum HandTags
    {
        yoo,
        victory
    }
    [SerializeField] private HandTags handTags;

    [Header("Animation components")]
    [SerializeField] Animator handAnimation;

    [Header("Animation tags")]
    [SerializeField] string yoo_L;
    [SerializeField] string yoo_R;
    [SerializeField] string victory_L;
    [SerializeField] string victory_R;


    private void Update()
    {
        if (!photonView.IsMine)
            return;

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            handAnimation.SetBool(HandAnimationTag_L(), true);
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            handAnimation.SetBool(HandAnimationTag_L(), false);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            handAnimation.SetBool(HandAnimationTag_R(), true);
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            handAnimation.SetBool(HandAnimationTag_R(), false);
        }
    }

    private string HandAnimationTag_L()
    {
        if (handTags == HandTags.yoo)
        {
            return yoo_L;
        }
        else if (handTags == HandTags.victory)
        {
            return victory_L; 
        }
        else
        {
            return null;
        }
    }

    private string HandAnimationTag_R()
    {
        if (handTags == HandTags.yoo)
        {
            return yoo_R;
        }
        else if (handTags == HandTags.victory)
        {
            return victory_R;
        }
        else
        {
            return null;
        }
    }

    public void _ChangeGesture(int _index)
    {
        if (photonView.IsMine)
        {
            if (_index == 0)
            {
                handTags = HandTags.yoo;
            }
            else if (_index == 1)
            {
                handTags = HandTags.victory;
            }
        }
    }
}
