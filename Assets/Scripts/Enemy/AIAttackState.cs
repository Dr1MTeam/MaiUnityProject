using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIBaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float attackTimer;

    // Start is called before the first frame update
    public override void Enter()
    {

    }
    public override void Perform()
    {
        //Debug.Log(enemy.CanSeePlayer());
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            attackTimer += Time.deltaTime;
            //Debug.Log(Vector3.Distance(enemy.transform.position, enemy.player.transform.position));
            if (attackTimer > enemy.attackRate && (Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) < 2.5f))
            {
                
                    
                Attack();
            }

            if (moveTimer > Random.Range(0f, 1.5f))
            {
                //enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                enemy.Agent.SetDestination(enemy.Player.transform.position);
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
    public void Attack()
    {
        Transform atkZone = enemy.AttackZone;
        GameObject atk = GameObject.Instantiate(Resources.Load("Prefabs\\Attack") as GameObject, atkZone.position, enemy.transform.rotation);
        Vector3 atkDirrection = (enemy.Player.transform.position - atkZone.transform.position).normalized;
        atk.GetComponent<Rigidbody>().velocity = atkDirrection * 5;
        Debug.Log("Attack");
        attackTimer = 0f;
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
