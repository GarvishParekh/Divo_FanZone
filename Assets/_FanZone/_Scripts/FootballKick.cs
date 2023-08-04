using UnityEngine;

public class FootballKick : MonoBehaviour
{
    [Header("Football")]
    [SerializeField] private string footballTag;

    [Space]
    [SerializeField] private Rigidbody footballRigidBody;
    [SerializeField] private float footballForce;

    private void OnCollisionEnter(Collision collisionObject)
    {
        if (collisionObject.collider.CompareTag (footballTag))
        {
            footballRigidBody = collisionObject.gameObject.GetComponent<Rigidbody>();
            if (footballRigidBody != null )
            {
                footballRigidBody.AddForce(transform.forward * footballForce * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}
