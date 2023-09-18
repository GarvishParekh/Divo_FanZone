using UnityEngine;

public class CreateCollider : MonoBehaviour
{
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private string tagToFind;
    [SerializeField] private float timer;
    [SerializeField] private float timeToReset = 15f;

    void Update() => TimerFunction();

    void TimerFunction()
    {
        if (timer >= timeToReset)
        {
            timer = 0;
            CheckForPlayer();
        }
        else
            timer += Time.deltaTime;
    }

    void CheckForPlayer()
    {
        bool isMeetingOn = false;
        Collider[] _collider = Physics.OverlapBox(transform.position, boxSize);

        foreach (var _objects in _collider)
        {
            if (_objects.CompareTag(tagToFind))
            {
                Debug.Log("Player Found");
                isMeetingOn = true;
                return;
            }
            else isMeetingOn = false;
        }

        if (!isMeetingOn) CallAPI();
    }

    void CallAPI() => Debug.Log("Call API");

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, boxSize * 2);
    }
}
