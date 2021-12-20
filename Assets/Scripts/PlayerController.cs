using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D PlayerRB;
    public float jumpSpeed, nextJumpTime, jumpFrequency;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    public Transform groundCheckPosition;
    public bool isgrounded = false;
    Animator playerAnimator;

    void Start()
    {
        PlayerRB = this.GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnGroundCheck();
    }

    void OnGroundCheck()
    {
        isgrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isgrounded);
    }

    public void Jump()
    {
        //zýplama kýsýtlamasý yapmalýsýn
        OnGroundCheck();
        if (isgrounded && nextJumpTime < Time.timeSinceLevelLoad)
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            PlayerRB.AddForce(new Vector2(0f, jumpSpeed));

        }


    }

}
