using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SkeletonGroundedState
{

    public SkeletonIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,Skeleton skeleton) : base(enemyBase, stateMachine, animBoolName, skeleton)
    {
        
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = skeleton.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(skeleton.moveState);

    }
}
