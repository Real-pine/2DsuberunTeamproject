using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static readonly int isWalking = Animator.StringToHash("IsRunning");
    private static readonly int isHit = Animator.StringToHash("IsHit");

    private readonly float magnituteThreshold = 0.5f;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Move(Vector2 vector)
    {
        // 작으면 false 크면 true
        animator.SetBool(isWalking, Mathf.Abs(vector.x) > magnituteThreshold);
    }

    public void Hit()
    {
        // 스프라이트 색을 빨간색으로 변경, 일정 시간(무적시간) 뒤 다시 흰색으로 변경할 것
        // 무적시간 구현할 것
        
        //animator.SetBool(isHit, true);
    }

    private void CharacterFlipX(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}