using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public AIBaseState activeState;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Initialize()
    {
        ChangeState(new AIPatrolState());
    }
    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }
    
    public void ChangeState(AIBaseState newState)
    {
        if (activeState!=null)
        {
            activeState.Exit(); 
        }
        activeState = newState;


        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
