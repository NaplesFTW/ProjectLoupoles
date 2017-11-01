using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    Player player;

    public GameObject bulletPrefab;
    public Vector2 bulletStartPos;


    List<GameObject> bullets;
    public bool shot;

    public float shootCooldownTime = .25f;
    public float bulletCooldownTimer;
	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        bullets = new List<GameObject>();
    }


    void Update()
    {
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
        bulletCooldownTimer = shootCooldownTime = .25f;
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = bulletStartPos;
        bullets.Add(bullet);
    }

}
