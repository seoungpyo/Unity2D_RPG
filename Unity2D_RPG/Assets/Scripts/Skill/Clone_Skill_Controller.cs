using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Skill_Controller : MonoBehaviour
{

    [SerializeField] private float colorLossingSpeed;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRadius = .8f;
    private Animator animator;
    private float cloneTimer;
    private Transform closesEnemy;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        cloneTimer -= Time.deltaTime;

        if (cloneTimer < 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - (Time.deltaTime * colorLossingSpeed));

            if(spriteRenderer.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetupClone(Transform newTransform, float cloneDuration, bool canAttack)
    {
        if (canAttack)
        {
            animator.SetInteger("AttackNumber", Random.Range(1,3));
        }

        transform.position = newTransform.position;
        cloneTimer = cloneDuration;

        FaceClosestTarget();

    }

    private void AnimationTrigger()
    {
        cloneTimer = -.1f;
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().Damage();
            }
        }
    }

    private void FaceClosestTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 25);

        float closestDistance = Mathf.Infinity;

        foreach(var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, hit.transform.position);

                if(distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closesEnemy = hit.transform;
                }
            }
        }

        if(closesEnemy != null)
        {
            if(transform.position.x > closesEnemy.position.x)
            {
                transform.Rotate(0, 180, 0);
            }
        }
    }
}
