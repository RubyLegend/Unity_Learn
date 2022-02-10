using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Movement : MonoBehaviour
{
    public int xVelocity = 5;
    public int yVelocity = 5;
    private Rigidbody2D rigidBody;
    
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
    void Update()
    {
         UpdatePlayerPosition();
    }

    private void UpdatePlayerPosition()
    {
    	float moveInput = Input.GetAxis("Horizontal");
		float jumpInput = Input.GetAxis("Jump");
		bool isJump = rigidBody.velocity.y == 0 ? false : true;
		if (moveInput < 0 && isJump == false)
		{
			rigidBody.velocity = new Vector2(-xVelocity, rigidBody.velocity.y);
		}
		else if (moveInput > 0 && isJump == false)
		{
			rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
		}
		if (jumpInput > 0 && isJump == false)
		{
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
			isJump = true;
		}

    }
}
