/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       01/08/2016 19:13
================================================================*/

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : LivingEntity
{
    public enum State { Idle, Chasing, Attacking };
    State currentState;

    // Variable Declarations
    NavMeshAgent pathfinder;

    // Static Variables
    Transform target;
    LivingEntity targetEntity;
    Material skinMat;

    Color origColor;

    float nextAttackTime;
    float enemyCollisionRadius;
    float playerCollisionRadius;

    // Private Variables
    float attackDistThreshold = .5f;
    float timeBetweenAttacks = 1f;
    bool hasTarget;

	// Public Variables
	
	// Function Definitions
	
	// Unity Functions
	
	void Awake ()
    {
		
	}
	
    protected override void Start ()
    {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();

        // setting default mat to origColor
        skinMat = GetComponent<Renderer>().material;
        origColor = skinMat.color;

        // if player object exists (not null)...
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            // on start, set enemy state to chase player
            currentState = State.Chasing;
            hasTarget = true;
            target = GameObject.FindGameObjectWithTag("Player").transform;
            targetEntity = target.GetComponent<LivingEntity>();
            // subscribing OnTargetDeath to OnDeath method
            targetEntity.OnDeath += OnTargetDeath;

            // setting the radii for both enemy and player (to calculate collisions better)
            enemyCollisionRadius = GetComponent<CapsuleCollider>().radius;
            playerCollisionRadius = target.GetComponent<CapsuleCollider>().radius;

            StartCoroutine(UpdatePath());
        }
	}

    void OnTargetDeath ()
    {
        // once target dies, enemy no longer has a target, then change state to Idle
        hasTarget = false;
        currentState = State.Idle;
    }
	
	void OnDestroy ()
    {
		
	}

    void Update ()
    {
        // if enemy has target...
        if (hasTarget)
        {
            if (Time.time > nextAttackTime)
            {
                float sqrDistToTarget = (target.position - transform.position).sqrMagnitude;
                float surfaceAttackRadius = attackDistThreshold + enemyCollisionRadius + playerCollisionRadius;

                if (sqrDistToTarget < surfaceAttackRadius * surfaceAttackRadius)
                {
                    nextAttackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                }
            }
        }
    }

    IEnumerator Attack()
    {
        currentState = State.Attacking;
        pathfinder.enabled = false;

        Vector3 originalPos = transform.position;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        Vector3 attackPos = target.position - dirToTarget * (enemyCollisionRadius);

        float attackSpeed = 3;
        float percent = 0;
        bool hasAppliedDamage = false;

        skinMat.color = Color.red;

        while (percent <= 1)
        {
            if (percent>= .5f && !hasAppliedDamage)
            {
                hasAppliedDamage = true;
                //targetEntity.TakeDamage()
            }
            percent += Time.deltaTime * attackSpeed;
            float interp = (-percent * percent + percent) * 4;
            transform.position = Vector3.Lerp(originalPos, attackPos, interp);

            yield return null;
        }

        skinMat.color = origColor;
        currentState = State.Chasing;
        pathfinder.enabled = true;
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;

        // while enemy has a target...
        while (hasTarget)
        {
            if (currentState == State.Chasing)
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                //Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
                Vector3 targetPosition = target.position - dirToTarget * (enemyCollisionRadius + playerCollisionRadius + attackDistThreshold/2);
                if (!dead)
                {
                    pathfinder.SetDestination(targetPosition);
                }
            }

            yield return new WaitForSeconds(refreshRate);
        }
    }
}