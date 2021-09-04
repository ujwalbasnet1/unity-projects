using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayerController : MonoBehaviour
{
    

    private readonly KeyCode up, right, left;

    public IPlayerController(KeyCode up, KeyCode right, KeyCode left)
    {
        this.up = up;
        this.right = right;
        this.left= left;
    }

    private PlayerMovement playerMovement;
    private Animator animator;

    void Start()
    {
        
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(right))
            playerMovement.MoveHorizontal(1);
        

        if (Input.GetKey(left))
            playerMovement.MoveHorizontal(-1);
        

        if (Input.GetKeyDown(up))
        {
            if (playerMovement.isGrounded)
                AnimatorTrigger("takeOff");

            playerMovement.Jump();
        }

        if(playerMovement.isGrounded)
        {
            AnimatorJump(false);
        }
        else
        {
            AnimatorJump(true);
        }
        
    }


    private void AnimatorJump(bool jump)
    {
        if(animator != null)
            animator.SetBool("jumping", jump);
    }

    private void AnimatorTrigger(string trigger)
    {
        if(animator != null)
            animator.SetTrigger(trigger);
    }

}
