using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform player;
    private Skeleton skeleton;
    private int moveDir;   

    public SkeletonBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Skeleton skeleton) : base(enemyBase, stateMachine, animBoolName)
    {
        this.skeleton = skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        this. player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (skeleton.IsPlayerDetected())
        {
            stateTimer = skeleton.battleTime;

            if(skeleton.IsPlayerDetected().distance < skeleton.attackDistance && CanAttack())
            {
                stateMachine.ChangeState(skeleton.attackState);
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, skeleton.transform.position) > 15)
                stateMachine.ChangeState(skeleton.idleState);
        }

        if (player.position.x > skeleton.transform.position.x)
            moveDir = 1;
        else if (player.position.x < skeleton.transform.position.x)
            moveDir = -1;

        skeleton.SetVelocity(skeleton.moveSpeed * moveDir, rb.velocity.y);
    }

    private bool CanAttack()
    {
        if(Time.time >= skeleton.lastTimeAttacked + skeleton.attackCooldown)
        {
            skeleton.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}
