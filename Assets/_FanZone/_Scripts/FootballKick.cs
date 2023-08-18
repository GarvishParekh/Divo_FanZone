using UnityEngine;

public class FootballKick : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Transform playerTransform;

    [Header("Football")]
    [SerializeField] private string footballTag;

    [Space]
    [SerializeField] private Rigidbody footballRigidBody;

    [Range(50, 1000)]
    [SerializeField] private float footballForwardForce;
    [Range(50, 1000)]
    [SerializeField] private float footballUpwardsForce;

    private void OnTriggerEnter(Collider objectsCollider)
    {
        if (objectsCollider.CompareTag(footballTag))
        {
            footballRigidBody = objectsCollider.gameObject.GetComponent<Rigidbody>();
            if (footballRigidBody != null)
            {
                footballRigidBody.AddForce(playerTransform.forward * footballForwardForce * Time.deltaTime, ForceMode.Impulse);
                footballRigidBody.AddForce(playerTransform.up * footballUpwardsForce * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}
