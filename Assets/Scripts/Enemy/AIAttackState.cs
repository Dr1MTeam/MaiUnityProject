using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIBaseState
{
    private float moveTimer;
    private float losePlayerTimer;

    // Start is called before the first frame update
    public override void Enter()
    {

    }
    public override void Perform()
    {
        Debug.Log(enemy.CanSeePlayer());
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(0f, 1.5f))
            {
                //enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                enemy.Agent.SetDestination(enemy.player.transform.position);
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 7)
            {
                // da
                stateMachine.ChangeState(new AIPatrolState());
            }
        }
    }

    public override void Exit()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
