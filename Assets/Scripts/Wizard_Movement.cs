using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Movement : MonoBehaviour
{
    public float xVelocity = 5F;
    public float yVelocity = 7F;
    private Rigidbody2D rigidBody;
    bool facingRight = false;
    private void Awake()
    {
	Debug.Log("Awake");
    }

    // Start is called before the first frame update
    private void Start()
    {
    	rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         UpdatePlayerPosition();
    }

    private void UpdatePlayerPosition()
    {
    	float moveInput = Input.GetAxis("Horizontal");
	float jumpInput = Input.GetAxis("Jump");
	bool isJump = rigidBody.velocity.y == 0 ? false : true;
	if (moveInput < 0)   //To the left
	{
		rigidBody.velocity = new Vector2(-xVelocity, rigidBody.velocity.y);
		if(facingRight) Flip();
	}
	else if (moveInput > 0) //To the right
	{
		rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
		if(!facingRight) Flip();
	}
	if (jumpInput > 0 && isJump == false)
	{
		rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
	}

    }

    void Flip(){
	Vector3 currentScale = gameObject.transform.localScale;
	currentScale.x *= -1;
	gameObject.transform.localScale = currentScale;

	facingRight = !facingRight;
    }
}
