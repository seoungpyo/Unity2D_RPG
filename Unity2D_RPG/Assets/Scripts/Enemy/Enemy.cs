using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;
    #region Header Move Info
    [Space(10)]
    [Header("Move info")]
    #endregion
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    #region Header Attack Info
    [Space(10)]
    [Header("Attack info")]
    #endregion
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;

    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
    }

    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, whatIsPlayer);

    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3((transform.position.x + attackDistance * facingDir), transform.position.y));
    }
}
