using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSkeletonController : MonoBehaviour
{
    Animator animator;
    SkinnedMeshRenderer skinnedMesh;
    private Enemy enemy;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = transform.parent.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;


         //if (Input.GetKey(KeyCode.L))
            //animator.SetTrigger("lying");
        //else if (Input.GetKeyDown(KeyCode.Space))
            //animator.SetTrigger("jump");
        if (enemy.IsDead) animator.SetTrigger("knockdown");
                
        if (enemy.IsAttacking)
        {
            if (Random.value > 0.5f) animator.SetTrigger("punch_L");
            else animator.SetTrigger("punch_R");

        }

        animator.SetFloat("Vertical", enemy.Agent.speed);
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        if(enemy.IsRunning)
            animator.SetBool("running", true);
        else
            animator.SetBool("running", false);
        /*
        if (Input.GetKey(KeyCode.LeftControl))
            animator.SetBool("sidefix", true);
        else
            animator.SetBool("sidefix", false); 
          
         // */
    }
}
