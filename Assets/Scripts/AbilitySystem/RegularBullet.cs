using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour {
    public Player player;

    public float bulletShotCooldown = .25f;
    public int Direction;
    public float bulletSpeed = 5f;
    public float destroyDistance = 100f;
    public float startPos;
    public Rigidbody2D rb;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        transform.SetParent(player.bulletParent);
        transform.position = player.transform.position + (Vector3)player.playerShoot.bulletStartPos * player.isFacingRightInt();
        startPos = transform.position.x;
        Direction = player.isFacingRightInt();
    }


    void Update()
    {

        if(Direction == 1)
        {
            if (transform.position.x >= startPos + destroyDistance)
                Destroy(gameObject);
        }
        else if(Direction == -1)
        {
            if (transform.position.x <= startPos - destroyDistance)
                Destroy(gameObject);
        }
        rb.velocity = Vector2.right * Direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            return;

        Destroy(gameObject);
    }
}
