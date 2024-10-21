using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static readonly int isWalking = Animator.StringToHash("IsRunning");

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

    private void CharacterFlipX(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}