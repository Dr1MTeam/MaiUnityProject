using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : Interactable
{
    [SerializeField]
    private GameObject cube;
    private bool cubeMoved = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        cubeMoved = !cubeMoved;
        cube.GetComponent<Animator>().SetBool("isMoved", cubeMoved);
        
    }
}
