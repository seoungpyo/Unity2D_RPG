using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    protected Rigidbody2D rb;

    protected bool triggerCalled;
    private string animBoolName;
    protected float stateTimer;

    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBase.rb;
        enemyBase.animator.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        if(stateTimer >= 0)stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        enemyBase.animator.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    } 
}
