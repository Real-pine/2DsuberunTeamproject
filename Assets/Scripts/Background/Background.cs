using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] sprites;
    private int startIndex;
    private int endIndex;

    float viewHeight;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * (-2) ;
    }
    private void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 nextPosition = Vector3.down * moveSpeed * Time.deltaTime;
        transform.position = currentPosition + nextPosition;

        if (sprites[endIndex].position.y < viewHeight )
        {
            // 배경재사용
            Vector3 backSpritePosition = sprites[startIndex].localPosition;
            Vector3 frontSpritePosition = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePosition + Vector3.up * viewHeight;

            // 스프라이트 인덱스 이어붙이기
            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = startIndexSave - 1 == -1 ? sprites.Length - 1 : startIndexSave - 1;
        }
    }
}
