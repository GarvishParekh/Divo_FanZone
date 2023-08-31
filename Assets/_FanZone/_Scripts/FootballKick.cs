using Photon.Pun;
using UnityEngine;

public class FootballKick : MonoBehaviour
{
    [Header("Multiplayer")]
    [SerializeField] private PhotonView photonView;
    [Header("Player")]
    [SerializeField] Transform playerTransform;

    [Header("Football")]
    [SerializeField] private string footballTag;
    [SerializeField] private Rigidbody footballRigidBody;

    [Space]
    [Range(0, 20)]
    [SerializeField] private float footballForwardForce;
    [Range(0, 20)]
    [SerializeField] private float footballUpwardsForce;

    [Header("Sound components")]
    [SerializeField] private AudioSource footballKickSound;
    [SerializeField] private AudioClip[] footballKickClip;

    private void OnTriggerEnter(Collider objectsCollider)
    {
        if (objectsCollider.CompareTag(footballTag))
        {
            footballRigidBody = objectsCollider.gameObject.GetComponent<Rigidbody>();
            if (footballRigidBody != null)
            {
                footballRigidBody.velocity = transform.forward * footballForwardForce + playerTransform.up * footballUpwardsForce;
            }

            if(photonView.IsMine)
            {
                int _random = Random.Range(0, footballKickClip.Length);
                footballKickSound.PlayOneShot(footballKickClip[_random]);
            }
        }
    }
}
