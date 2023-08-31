using UnityEngine;

public class CharacterSpawnSimultation : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private float spawnCount;

    [Space]
    [SerializeField] private Vector2 xRange;
    [SerializeField] private Vector2 zRange;

    private float xPosition;
    private float zPosition;
    private float yRotation;

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            xPosition = Random.Range(xRange.x, xRange.y);
            zPosition = Random.Range(zRange.x, zRange.y);
            yRotation = Random.Range(0, 360);

            Vector3 spawnPositionVector = new Vector3(xPosition, 0, zPosition);
            Instantiate(playerPrefab, spawnPositionVector, Quaternion.Euler(0, yRotation, 0));
        }
    }
}
