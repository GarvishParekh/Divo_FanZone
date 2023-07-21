using UnityEngine;

public class FlagSimulation : MonoBehaviour
{
    [SerializeField] private Material[] flagMaterials;

    [Space]
    [SerializeField] private float wind;
    [Range(0f, 1f)]
    [SerializeField] private float windSpeed;

    private void Update()
    {
    }   
}
