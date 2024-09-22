using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    private Skeleton skeleton;

    public SkeletonAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Skeleton skeleton) : base(enemyBase, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        skeleton.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        skeleton.SetZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(skeleton.battleState);

    }
}
