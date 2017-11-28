using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {
    Player player;
    public int healthPoints = 10;

    public float healthSafeTime = .25f;
    float healthSafeTimer;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public float playerDeadTime;
    float playerDeadTimer;
    bool playerDead;
    bool damaged;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        damageImage = GameObject.Find("DamageImage").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (healthSafeTimer > 0)
            healthSafeTimer -= Time.deltaTime;

        if (playerDeadTimer > 0)
            playerDeadTimer -= Time.deltaTime;
        else if(playerDead)
        {
            if (player.gm != null)
                player.gm.changeLevel.restartLevel();
        }
        
	}

    public void takeDamage(int damage)
    {
        if (healthSafeTimer <= 0 && healthPoints > 0)
        {
            healthSlider.value = healthPoints;
            healthPoints -= damage;
            healthSafeTimer = healthSafeTime;
            damaged = true;
        }

        if (healthPoints <= 0)
            die();

    
    }

        public void takeDamageKnockback(int damage)
    {
        takeDamage(damage);
        player.playerHit.hit();
    }


    public void die()
    {
        player.setState(PlayerState.Dead);
        playerDeadTimer = playerDeadTime;
        playerDead = true;
    }
}
