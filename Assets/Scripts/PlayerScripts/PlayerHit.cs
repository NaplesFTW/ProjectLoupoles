using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {
    public bool knockback = true;
    float knockbackTimer;
    float knockbackTime = .25f;
    bool isHit = false;
    Player player;
    public Vector2 knockbackForce;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (knockbackTimer > 0)
            knockbackTimer -= Time.deltaTime;
        else if(isHit)
        {
            isHit = false;
            player.setState(PlayerState.Moving);
        }
	}

    public void hit()
    {
        if (!knockback)
            return;

        if(player.getState() == PlayerState.Moving || player.getState() == PlayerState.Dashing)
        {
            player.setState(PlayerState.Hit);
            GetComponent<Rigidbody2D>().AddForce(knockbackForce, ForceMode2D.Impulse);
            knockbackTimer = knockbackTime;
            isHit = true;
        }
    }
}
