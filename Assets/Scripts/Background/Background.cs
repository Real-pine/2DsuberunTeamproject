using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float scrollAmount; // 두 배경 사이의 거리
    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection = new Vector3(0f, -1f, 0f);
    private void Update()
    {
        // 배경이 설정 범위 벗어나면 위치 재설정
        if (transform.position.y <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount;
        }
        //
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
    }
}
