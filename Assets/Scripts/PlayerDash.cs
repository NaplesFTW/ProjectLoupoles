using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tempory testing how to do a dash.
/// </summary>

public class PlayerDash : MonoBehaviour {
    public DashState dashState;
    Player player;
    public float dashTimer;
    public float dashCooldownTimer;
    public float dashSpeed = 3f;
    public float maxDash = 2f;
    public float dashCooldown = .5f;

    Rigidbody2D playerRigidBody;
    float savedGravityScale;
    public float savedVelocityX;
    // Use this for initialization
	void Start () {
        playerRigidBody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame




	void Update () {
        savedVelocityX = playerRigidBody.velocity.x;
        switch (dashState)
        {
            case DashState.Ready:
                if(Input.GetKeyDown(KeyCode.LeftShift) && player.getState() == PlayerState.Moving)
                {
                    
                    GetComponent<Animator>().SetBool("Dashing",true);
                    savedGravityScale = playerRigidBody.gravityScale;
                    playerRigidBody.gravityScale = 0;
                    //playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x * dashSpeed, 0);
                    //playerRigidBody.AddForce(new Vector2(maxDash*10000, 0),ForceMode2D.Force);
                    dashState = DashState.Dashing;
                    player.setState(PlayerState.Dashing);
                }
                break;

            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if(dashTimer < maxDash)
                {
                    savedVelocityX = playerRigidBody.velocity.x;
                    //transform.Translate(savedVelocityX)
                    playerRigidBody.velocity =  new Vector3(dashSpeed * (player.isFacingRight ? 1 : -1),0,0);

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
                player.setState(PlayerState.Moving);
                playerRigidBody.gravityScale = savedGravityScale;
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
