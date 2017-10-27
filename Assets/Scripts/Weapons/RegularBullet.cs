using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : MonoBehaviour {
    public float bulletShotCooldown = .25f;
    public int Direction;
    public float bulletSpeed = 5f;
    public float destroyDistance = 100f;
    public float startPos;


    private void Start()
    {
        startPos = transform.position.x;
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            return;

        Destroy(gameObject);
    }
}
