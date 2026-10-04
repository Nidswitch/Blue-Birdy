using UnityEngine;
using Unity.Netcode;

public class Bactos_attack : StateMachineBehaviour
{
    public float attackRange = 1f;

    Transform player;
    Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.LocalClient != null && NetworkManager.Singleton.LocalClient.PlayerObject != null)
            {
                player = NetworkManager.Singleton.LocalClient.PlayerObject.transform;
            }
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = player != null ? new Vector2(player.position.x, rb.position.y) : Vector2.zero;

        if (player == null || rb == null) return;
    float directionToPlayer = player.position.x - rb.position.x;
    float enemyFacingDirection = animator.transform.right.x > 0 ? 1f : -1f;
    bool isPlayerInFront = (directionToPlayer * enemyFacingDirection) < 0;
    bool isWithinRange = Vector2.Distance(player.position, rb.position) <= attackRange;
    if (isPlayerInFront && isWithinRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    
}