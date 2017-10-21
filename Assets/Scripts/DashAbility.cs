using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tempory testing how to do a dash.
/// </summary>

public class DashAbility : MonoBehaviour {
    public DashState dashState;
    public float dashTimer;
    public float dashCooldownTimer;
    public float dashSpeed = 3f;
    public float maxDash = 2f;
    public float dashCooldown = .5f;

    Rigidbody2D playerRigidBody;

    public float savedVelocityX;
    // Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame




	void Update () {
        savedVelocityX = playerRigidBody.velocity.x;
        switch (dashState)
        {
            case DashState.Ready:
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    
                    GetComponent<Animator>().SetBool("Dashing",true);
                    //playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x * dashSpeed, 0);
                    //playerRigidBody.AddForce(new Vector2(maxDash*10000, 0),ForceMode2D.Force);
                    dashState = DashState.Dashing;
                }
                break;

            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if(dashTimer < maxDash)
                {
                    savedVelocityX = playerRigidBody.velocity.x;
                    //transform.Translate(savedVelocityX)
                    //playerRigidBody.velocity =  new Vector3(0,0,0);

                }
                else
                {
                    dashTimer = 0;
                    GetComponent<Animator>().SetBool("Dashing", false);
                    dashState = DashState.Cooldown;
                }
                //do stuff 
                break;

            case DashState.Cooldown:
                dashCooldownTimer += Time.deltaTime;
                if (dashCooldownTimer > dashCooldown)
                {
                    dashCooldownTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
	}


}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}
