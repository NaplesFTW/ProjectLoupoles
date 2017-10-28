using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    Player player;

    public GameObject bulletPrefab;
    public Vector2 bulletStartPos;


    List<GameObject> bullets;
    public bool shot;

    public float bulletCooldownTimer;
	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        bullets = new List<GameObject>();
    }


    void Update()
    {
        if (player.anim == null)
            player.anim = GetComponent<Animator>();

        if (Input.GetAxis("Shoot") == 0 && shot == true)
        {
            shot = false;
            player.anim.SetBool("Shooting", false);
        }

        if(player.getState() == PlayerState.Dashing)
            player.anim.SetBool("Shooting", false);

        if (bulletCooldownTimer > 0)
            bulletCooldownTimer -= Time.deltaTime;
    }

    void FixedUpdate () {

        if (Input.GetAxis("Shoot") == 1 && bulletCooldownTimer <= 0 && player.getState() != PlayerState.Dashing)
        {
            Shoot();
        }

        for (int i = 0; i < bullets.Count; i++)
        {
            if(bullets[i] == null)
            {
                bullets.Remove(bullets[i]);
                continue;
            }


        }

    }

    void Shoot()
    {
        shot = true;
        player.anim.SetBool("Shooting", true);
        //bulletCooldownTimer = bulletPrefab.GetComponent<RegularBullet>().bulletShotCooldown; //need to make seperate cooldown in abilities.
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);

        bullets.Add(bullet);
    }

}
