using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float scrollAmount; // �� ��� ������ �Ÿ�
    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection = new Vector3(0f, -1f, 0f);
    private void Update()
    {
        // ����� ���� ���� ����� ��ġ �缳��
        if (transform.position.y <= -scrollAmount)
        {
            transform.position = target.position - moveDirection * scrollAmount;
        }
        //
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
    }
}
