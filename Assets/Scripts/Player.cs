using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    PlayerState playerState;

    PlayerMotionController playerMotionController;
    PlayerDash playerDash;

    public bool isFacingRight;
	// Use this for initialization
	void Start () {
        playerMotionController = GetComponent<PlayerMotionController>();
        playerDash = GetComponent<PlayerDash>();
        isFacingRight = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public PlayerState getState()
    {
        return playerState;
    }

    public void setState(PlayerState PS)
    {
        playerState = PS;
    }

}

public enum PlayerState
{
    Moving,
    Dashing
}
