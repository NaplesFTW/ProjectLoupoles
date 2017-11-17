using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public EnemyHealth enemyHealth;
    public int damage = 1;
    public bool ignoreCollision = true;
	// Use this for initialization
	void Start () {
        enemyHealth = GetComponent<EnemyHealth>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>(), ignoreCollision);
            collision.gameObject.GetComponent<PlayerLife>().takeDamage(damage);
        }
    }
}
