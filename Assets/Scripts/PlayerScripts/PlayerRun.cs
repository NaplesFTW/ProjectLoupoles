using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour {
    Player player;

    public float speed = 3;


	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
    }


    void FixedUpdate()
    {
        //again checks if in moving state
        if (player.getState() == PlayerState.Moving)
        {
            //moving left and right jumping and not jumping
            player.rb.velocity = new Vector2(player.hor * speed, player.rb.velocity.y);


            //check if moving at all and sets the animations accordingly.
            if (player.hor != 0)
                player.anim.SetBool("Running", true);
            else
                player.anim.SetBool("Running", false);
        }

    }







}
