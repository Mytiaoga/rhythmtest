using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SynchedAnim : MonoBehaviour
{
    //The animator controller attached to this GameObject
    public Animator animator;

    //Records the animation state or animation that the Animator is currently in
    public AnimatorStateInfo animatorStateInfo;

    //Used to address the current state within the Animator using the Play() function
    public int currentState;

    public Conductor cond;

    void Start()
    {
        //Load the animator attached to this object
        animator = GetComponent<Animator>();

        //Get the info about the current animator state
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //Convert the current state name to an integer hash for identification
        currentState = animatorStateInfo.fullPathHash;

        cond = GameObject.Find("Conductor").GetComponent<Conductor>();
    }

    // Update is called once per frame
    void Update()
    {
        //Load the animator attached to this object
        animator = GetComponent<Animator>();

        //Get the info about the current animator state
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //Convert the current state name to an integer hash for identification
        currentState = animatorStateInfo.fullPathHash;

        if(cond.playNow == true)
        {
            animator.enabled = true;
            animator.Play("BackN'Forth");
        }
        if(cond.playNow == false)
        {
            animator.enabled = false;
        }

    }
    
    public void staph()
    {
        cond.playNow = false;
    }
   
}
