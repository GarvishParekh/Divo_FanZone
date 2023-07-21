using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandResetController : MonoBehaviour
{
    [SerializeField] SyncWithOVR ovrSync;
    [SerializeField] private Slider xSlider;
    [SerializeField] private Slider ySlider;
    [SerializeField] private Slider zSlider;

    [Space]
    [SerializeField] private float xValue;
    [SerializeField] private float yValue;
    [SerializeField] private float zValue;

    [Header("User Interface")]
    [SerializeField] private TMP_Text T_xValue;
    [SerializeField] private TMP_Text T_yValue;
    [SerializeField] private TMP_Text T_zValue;


    public void GetNetworkPlayer(GameObject player)
        => ovrSync = player.GetComponent<SyncWithOVR>();

    public void _XSLiderChange()
    {
        xValue = xSlider.value;
        T_xValue.text = xValue.ToString();
        ovrSync.positionOffset_L.x = xValue;
    }
    public void _YSLiderChange()
    {
        yValue = ySlider.value;
        T_yValue.text = yValue.ToString();
        ovrSync.positionOffset_L.y = yValue;
    }
    public void _ZSLiderChange()
    {
        zValue = zSlider.value;
        T_zValue.text = zValue.ToString();
        ovrSync.positionOffset_L.z = zValue;
    }
}
