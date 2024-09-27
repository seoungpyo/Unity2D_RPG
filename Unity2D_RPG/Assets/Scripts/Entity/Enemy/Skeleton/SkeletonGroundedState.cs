using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected Skeleton skeleton;
    protected Transform player;

    public SkeletonGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Skeleton skeleton) : base(enemyBase, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (skeleton.IsPlayerDetected() || Vector2.Distance(skeleton.transform.position, player.position) < 2)
            stateMachine.ChangeState(skeleton.battleState);

    }
}
