using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIBaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float attackTimer;
    private float seenTimer = 0f;

    // Start is called before the first frame update
    public override void Enter()
    {

    }
    public override void Perform()
    {
        //Debug.Log(enemy.CanSeePlayer());
        if (enemy.CanSeePlayer() || seenTimer < 4f)
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            attackTimer += Time.deltaTime;
            seenTimer += Time.deltaTime;
            //Debug.Log(Vector3.Distance(enemy.transform.position, enemy.player.transform.position));
            enemy.temp = false;
            if (attackTimer > enemy.attackRate && (Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) < 2.5f))
            {
                enemy.temp = true;
                Attack();
            }
            //Debug.Log(Vector3.Distance(enemy.transform.position, enemy.Player.transform.position));
            if ((Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) <= 2f))
            {
                enemy.Agent.speed = 0f;
                seenTimer = 0f;
                Vector3 directionToPlayer = enemy.Player.transform.position - enemy.transform.position;

                // Обнуляем компоненты X и Z
                directionToPlayer.y = 0;

                // Создаем кватернион, поворачивающий врага в нужное направление
                Quaternion rotation = Quaternion.LookRotation(directionToPlayer);

                // Применяем поворот только по оси Y
                enemy.transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
            }
            else if ((Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) <= 9.5f))
            {
                enemy.Agent.speed = enemy.walkSpeed;
            }
            else
            {
                enemy.Agent.speed = enemy.runSpeed;

            }

            if (moveTimer > Random.Range(0f, 0.5f))
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
