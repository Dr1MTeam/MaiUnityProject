using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private PlayerStats pStats;
    private bool isRunning = false;
    private bool isAttacking = false;
    private bool isDead = false;
    private EnemyStats Stats;
    private GameObject death;
    public NavMeshAgent Agent { get => agent; }
    [SerializeField]
    private string currentState;
    public Path path;
    
    public GameObject Player { get => player; }
    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fov = 90f;
    public float eyeHeight = 2.3f;
    [Header("Attack")]
    public Transform AttackZone;
    [Range(0.1f, 10f)]
    public float attackRate;

    [Header("Speed")]
    public float runSpeed=7f;
    public float walkSpeed=2.5f;
    [SerializeField]
    public bool IsRunning { get => isRunning; }
    public bool IsAttacking { get => isAttacking; }
    public bool IsDead { get => isDead; }
    public bool temp = false;

    // Start is called before the first frame update
    void Start()
    {
        Stats = GetComponent<EnemyStats>();
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent> ();
        stateMachine.Initialize();
        
        player = GameObject.FindGameObjectWithTag("Player");
        pStats = player.GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(agent.speed);
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
        if (agent.speed > walkSpeed)
        {
            isRunning = true;
            
        }
        else isRunning = false;
        isAttacking = temp;
        if (Stats.Hp<=0)
        {
            pStats.killScores++;
            if (!isDead) death = GameObject.Instantiate(Resources.Load("Prefabs\\Death") as GameObject, transform.position, transform.rotation);
            isDead = true;
            
            Destroy(gameObject);
            ;
        }
    }
    public bool CanSeePlayer()
    {
        if (player == null) return false;

        if (Vector3.Distance(transform.position, player.transform.position) >= sightDistance) return false;

        Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
        float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

        if (angleToPlayer <= -fov || angleToPlayer >= fov) return false;

        Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
        RaycastHit hitInfo = new RaycastHit();

        if (!Physics.Raycast(ray, out hitInfo, sightDistance)) return false;

        if (hitInfo.transform.gameObject != player) return false;

        //Debug.Log(hitInfo.transform.gameObject == player);
        Debug.DrawRay(ray.origin, ray.direction * sightDistance);

        return true;
    }
}
