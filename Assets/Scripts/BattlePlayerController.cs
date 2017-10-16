using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour {
    Rigidbody2D playerRigidbody;
    public float speed = 3;
    public float jumpPower = 120;
    public float moveX;


    public bool isJustStart = false;
    public bool isJump = false;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
            isJustStart = true;

        moveX = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {

        if (isJustStart == true)
        {
            isJustStart = false;
            jump();
        }

        playerRigidbody.velocity = new Vector2(moveX * speed, playerRigidbody.velocity.y);

        
    }

    void jump()
    {
        isJump = true;
        playerRigidbody.AddForce(Vector2.up * jumpPower * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
    }

}
