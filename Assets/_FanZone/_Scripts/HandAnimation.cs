using Photon.Pun;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] PhotonView photonView;

    public enum HandActions
    {
        YoAction,
        VictoryAction,
        ThumbsUp
    }
    [SerializeField] private HandActions handActions;

    [Header("Animation components")]
    [SerializeField] Animator handAnimation;

    [Space]
    [SerializeField] string handAnimationString_L;
    [SerializeField] string handAnimationString_R;

    [Header("Animation tags")]
    [SerializeField] string yoo_L;
    [SerializeField] string yoo_R;
    [SerializeField] string victory_L;
    [SerializeField] string victory_R;
    [SerializeField] string thumbs_L;
    [SerializeField] string thumbs_R;

    [Header("User interface")]
    [SerializeField] private GameObject[] selectedIcon;

    private void Start() => _ChangeHandAction(0);

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            handAnimation.SetBool(HandAction("Left"), true);
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            handAnimation.SetBool(HandAction("Left"), false);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            handAnimation.SetBool(HandAction("Right"), true);
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            handAnimation.SetBool(HandAction("Right"), false);
        }
    }

    private string HandAction(string hand)
    {
        if (hand == "Left")
        {
            if (handActions == HandActions.YoAction)
                return yoo_L;
            else if (handActions == HandActions.VictoryAction)
                return victory_L;
            else if (handActions == HandActions.ThumbsUp)
                return thumbs_L;
            else return null;
        }
        
        else if (hand == "Right")
        {
            if (handActions == HandActions.YoAction)
                return yoo_R;
            else if (handActions == HandActions.VictoryAction)
                return victory_R;
            else if (handActions == HandActions.ThumbsUp)
                return thumbs_R;
            else return null;
        }
        
        else return null;
    }

    public void _ChangeHandAction(int _index)
    {
        CloseAllImages();
        handActions = (HandActions)_index;
        selectedIcon[_index].SetActive(true);
    }

    private void CloseAllImages()
    {
        for (int i = 0; i < selectedIcon.Length; i++)
        {
            selectedIcon[i].SetActive(false);
        }
    }
}
