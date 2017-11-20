using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour {
    Player player;
    
    public float speed = 3;
    public Vector2 velocity;
    public float maxVel = 50;
    public float horState;
	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
       // move();
    }


    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        if (player.getState() == PlayerState.Dead)
            return;

        //again checks if in moving state
        if (player.getState() == PlayerState.Moving)
        {
            if(player.hor == 0 && player.hor != horState)
            {
                player.rb.AddForce(new Vector2(-horState * speed, 0), ForceMode2D.Impulse);
            }
            //moving left and right jumping and not jumping
            //player.rb.velocity = new Vector2(player.hor * speed, player.rb.velocity.y);
            player.rb.AddForce(new Vector2(player.hor * speed,0), ForceMode2D.Impulse);
            velocity = player.rb.velocity;

            //check if moving at all and sets the animations accordingly.
            if (player.hor != 0)
                player.anim.SetBool("Running", true);
            else
                player.anim.SetBool("Running", false);

            if (player.hor != horState)
            {
                if(player.hor == 0)
                {
                    player.rb.velocity = new Vector2(0,player.rb.velocity.y);
                    //player.rb.AddForce(new Vector2(-horState * speed + -player.rb.velocity.x *3/6, 0), ForceMode2D.Impulse);
                }

                horState = player.hor;

            }

            if (player.hor != 0)
            {
                if (player.rb.velocity.x > maxVel)
                    player.rb.velocity = new Vector2(maxVel, player.rb.velocity.y);
                if (player.rb.velocity.x < -maxVel)
                    player.rb.velocity = new Vector2(-maxVel, player.rb.velocity.y);
            }
        }
    }


}
