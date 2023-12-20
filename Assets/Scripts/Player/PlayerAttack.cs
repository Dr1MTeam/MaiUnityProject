using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    [Header("Attack")]
    public Transform AttackZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ProcessAttack()
    {
        Transform atkZone = AttackZone;
        GameObject atk = GameObject.Instantiate(Resources.Load("Prefabs\\FireBall") as GameObject, atkZone.position + transform.forward, player.transform.rotation);
        Vector3 atkDirrection = transform.forward;
        atk.GetComponent<Rigidbody>().velocity = atkDirrection * 7.5f;
    }
}
