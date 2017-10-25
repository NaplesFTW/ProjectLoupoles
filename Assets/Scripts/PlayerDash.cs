using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tempory testing how to do a dash.
/// </summary>

public class PlayerDash : MonoBehaviour {
    public DashState dashState;
    Player player;

    public float dashXStart;
    public float dashTimer;
    public float dashCooldownTimer;
    public float dashDistance = 3f;
    public float dashTime = 2f;
    public float dashCooldown = .5f;

    
	void Start () {
        player = GetComponent<Player>();
	}
	

    //REDO: Change DashState to regular playerstate and just add a cooldown boolean.

	void Update () {



        switch (dashState)
        {
            case DashState.Ready:
                if(Input.GetKeyDown(KeyCode.LeftShift) && player.getState() == PlayerState.Moving)
                {
                    dashXStart = transform.position.x;

                    player.anim.SetBool("Dashing",true);
                    player.rb.gravityScale = 0;
                    player.setState(PlayerState.Dashing);

                    dashState = DashState.Dashing;
                }
                break;

            case DashState.Dashing:
                dashTimer += Time.deltaTime;
                if(dashTimer < dashTime)
                {
                    player.rb.velocity =  new Vector3(dashDistance * player.isFacingRightInt()/ dashTime, 0,0);
                }
                else
                {
                    dashTimer = 0;
                    GetComponent<Animator>().SetBool("Dashing", false);
                    player.rb.velocity = Vector2.zero;

                    if(player.hit.collider == null)
                        transform.position = new Vector2( dashXStart  + dashDistance * player.isFacingRightInt() , transform.position.y );


                    dashState = DashState.Cooldown;

                }
                //do stuff 
                break;

            case DashState.Cooldown:
                player.setState(PlayerState.Moving);
                player.rb.gravityScale = player.savedGravityScale;
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
