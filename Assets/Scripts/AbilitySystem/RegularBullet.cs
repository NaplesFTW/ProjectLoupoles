using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour {
    public Player player;
    public Vector2 Direction;
    public int damage = 15;
    public float bulletSpeed = 5f;
    public float startPos;
    public float bulletTime = 2f;
    public Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        transform.SetParent(player.bulletParent);
        transform.position = player.transform.position + (Vector3)player.playerShoot.bulletStartPos * player.isFacingRightInt();
        startPos = transform.position.x;
        Direction = player.isFacingRightInt() * Direction;
        Direction.Normalize();
    }

    void Update()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime <= 0)
            Destroy(gameObject);
        rb.velocity = Direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            return;
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().takeDamage(damage);
        }
        Destroy(gameObject);
    }

}
