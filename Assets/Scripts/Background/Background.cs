using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float scrollAmount;
    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection = Vector3.down;

    private void Update()
    {
        if (transform.position.y <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount;
        }
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
