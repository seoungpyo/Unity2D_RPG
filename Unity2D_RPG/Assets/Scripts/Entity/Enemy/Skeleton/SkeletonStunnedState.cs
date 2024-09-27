using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    private Skeleton skeleton;

    public SkeletonStunnedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Skeleton skeleton) : base(enemyBase, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        skeleton.fx.InvokeRepeating("RedColorBlink",0,0.1f);

        stateTimer = skeleton.stunDuration;

        rb.velocity = new Vector2(-skeleton.facingDir * skeleton.stunDiretion.x, skeleton.stunDiretion.y);
    }

    public override void Exit()
    {
        base.Exit();

        skeleton.fx.Invoke("CancelRedBlink",0);
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer < 0)
        {
            stateMachine.ChangeState(skeleton.idleState);
        }
    }
}
