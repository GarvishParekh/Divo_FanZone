using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.Unity;
using Meta.WitAi;

public class MicSettings : MonoBehaviour
{
    private PhotonView photonView;

    [Header ("[Get run time]")]
    [SerializeField] private Recorder networkVoiceManager;
    
    [Header ("UI elements")]
    [SerializeField] private GameObject mainHolder;

    [Space]
    [SerializeField] private Image I_mic;
    [SerializeField] private Image I_MicHolder;

    [Space]
    [SerializeField] private Sprite S_mute;
    [SerializeField] private Sprite S_unmute;
    [SerializeField] private bool isMuted = true;

    [Space]
    [SerializeField] private Color muteColor;
    [SerializeField] private Color unMuteColor;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            networkVoiceManager = GameObject.FindGameObjectWithTag("Network Voice Manager").GetComponent<Recorder>();
        }

        Invoke("ShowMicUI", 2.1f);
    }

    void ShowMicUI()
    {
        mainHolder.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown (KeyCode.M))
        {
            Mic();
        }
    }


    //mute
    public void Mic()
    {
        if (!photonView.IsMine)
            return;

        mainHolder.SetActive(false);
        mainHolder.SetActive(true);

        // unmute
        if (isMuted)
        {
            isMuted = false;
            
            //ui change
            I_mic.sprite = S_unmute;
            I_MicHolder.color = unMuteColor;
            
            //network change
            networkVoiceManager.TransmitEnabled = true;
        }
        // mute
        else
        {
            isMuted = true;

            //ui change
            I_mic.sprite = S_mute;
            I_MicHolder.color = muteColor;
            
            //network change
            networkVoiceManager.TransmitEnabled = false;
        }
    }
}
