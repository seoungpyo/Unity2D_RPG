using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Skeleton skeleton) : base(enemyBase, stateMachine, animBoolName, skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        skeleton.SetVelocity(skeleton.moveSpeed * skeleton.facingDir, rb.velocity.y);

        if(skeleton.IsWallDetected() || !skeleton.IsGroundDetected())
        {
            skeleton.Flip();
            stateMachine.ChangeState(skeleton.idleState);
        }

    }
}
