using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {
    Player player;
    public int healthPoints = 10;

    public float healthSafeTime = .25f;
    public float healthSafeTimer;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (healthSafeTimer > 0)
            healthSafeTimer -= Time.deltaTime;
	}

    public void takeDamage(int damage)
    {
        if (healthSafeTimer <= 0 && healthPoints > 0)
        {
            healthPoints -= damage;
            healthSafeTimer = healthSafeTime;
        }
        if (healthPoints <= 0)
            die();
    }
    public void die()
    {

        player.setState(PlayerState.Dead);
    }
}
