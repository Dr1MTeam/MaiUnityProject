using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    [Header("Player")]
    public GameObject player;
    public Camera cam;
    [Header("Attack")]
    public Transform AttackZone;
    public PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ProcessAttack()
    {
        if (stats.manaCost< stats.MP)
        {
            player.GetComponent<PlayerStats>().ManaChange(-stats.manaCost);
            Transform atkZone = AttackZone;
            GameObject atk = GameObject.Instantiate(Resources.Load("Prefabs\\FireBall") as GameObject, atkZone.position + transform.forward, player.transform.rotation);
            Vector3 atkDirrection = cam.transform.forward;
            atk.GetComponent<Rigidbody>().velocity = atkDirrection * 7.5f;
        }
 
        
    }
}
