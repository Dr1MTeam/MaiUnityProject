using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; }
    [SerializeField]
    private string currentState;
    public Path path;
    [HideInInspector]
    public GameObject player;
    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fov = 90f;
    public float eyeHeight = 2.3f;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent> ();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
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
