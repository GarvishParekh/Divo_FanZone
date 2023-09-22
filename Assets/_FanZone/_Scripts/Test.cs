using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] APIInformation apiInformation;

    private void Start()
    {
        apiInformation.test = 555;
    }
}
