using UnityEngine;

public class WalkingController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [Space]
    [SerializeField] private string horizontal;
    [SerializeField] private string vertical;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 joyStickControl = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (joyStickControl.x == 0  || joyStickControl.y == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat(vertical, joyStickControl.y);
            animator.SetFloat(horizontal, joyStickControl.x);
        }
    }
}
