using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour {
    Rigidbody2D playerRigidbody;
    Animator anim;
    Player player;

    public float speed = 3;
    public float jumpPower = 120;
    public float moveX;

    
    public bool isJustStart = false;
    public bool isJump = false;
	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.getState() == PlayerState.Moving)
        {
            if (Input.GetButtonDown("Jump"))
                isJustStart = true;

            moveX = Input.GetAxisRaw("Horizontal");

            flipPlayer();
        }
    }

    void FixedUpdate()
    {

        if (player.getState() == PlayerState.Moving)
        {
            if (isJustStart == true && isJump == false)
            {
                isJustStart = false;
                jump();
            }

            playerRigidbody.velocity = new Vector2(moveX * speed, playerRigidbody.velocity.y);
            if (moveX != 0)
                anim.SetBool("Running", true);
            else
                anim.SetBool("Running", false);
        }


    }

    void jump()
    {
        isJump = true;
        anim.SetBool("Jumping", true);
        playerRigidbody.AddForce(Vector2.up * jumpPower * 10);
    }

    void flipPlayer()
    {
        if ((moveX == 1 && player.isFacingRight == false) || (moveX == -1 && player.isFacingRight == true))
        {
            player.isFacingRight = !player.isFacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
        anim.SetBool("Jumping", false);
    }

}
