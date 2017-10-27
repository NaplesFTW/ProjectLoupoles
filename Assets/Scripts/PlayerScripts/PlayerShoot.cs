using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    Player player;

    public GameObject bulletPrefab;
    public Vector2 bulletStartPos;
    public Transform bulletParent;

    List<GameObject> bullets;

    public float bulletCooldownTimer;
	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        bullets = new List<GameObject>();
    }


    void Update()
    {

        if (Input.GetAxis("Shoot") == 0)
        {
            player.anim.SetBool("Shooting", false);
        }

        if(player.getState() == PlayerState.Dashing)
            player.anim.SetBool("Shooting", false);

        if (bulletCooldownTimer > 0)
            bulletCooldownTimer -= Time.deltaTime;
    }

    void FixedUpdate () {

        if (Input.GetAxis("Shoot") == 1 && bulletCooldownTimer <= 0)
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

            bullets[i].transform.Translate(Vector2.right * bullets[i].GetComponent<RegularBullet>().Direction * bullets[i].GetComponent<RegularBullet>().bulletSpeed * Time.deltaTime);
            bullets[i].GetComponent<Rigidbody2D>().velocity = Vector2.right * bullets[i].GetComponent<RegularBullet>().Direction * bullets[i].GetComponent<RegularBullet>().bulletSpeed;

        }

    }

    void Shoot()
    {
        player.anim.SetBool("Shooting", true);
        bulletCooldownTimer = bulletPrefab.GetComponent<RegularBullet>().bulletShotCooldown;
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);
        bullet.transform.SetParent(bulletParent);
        bullet.transform.position = (transform.position + (Vector3)bulletStartPos * player.isFacingRightInt());
        bullet.GetComponent<RegularBullet>().Direction = player.isFacingRightInt();

        bullets.Add(bullet);

        Debug.Log("Bullets1: " + bullets.Count);
    }

}
