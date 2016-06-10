using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector2 velocity;
	public Rigidbody2D rb2D;
	public bool grounded = false;
	public int VelX = 0;
	public int Health = 10;

	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	

	void Update () {
		Jump();
		Movement();
		rb2D.velocity = new Vector2 (VelX, rb2D.velocity.y);

		if (Health <= 0) {
			Destroy(gameObject);
		}
	}

	//Collision checking code
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {
			grounded = true;
		}


		//Player taking damage
		if (collision.gameObject.tag == "Enemy") {
			Stats stats = collision.gameObject.GetComponent<Stats>();
			if(stats != null) {
				Health -= stats.damage;
			}
		}
	}

	void Jump() {
		if (Input.GetKeyDown("space")) {
			if (grounded == true) {
				rb2D.velocity = new Vector2 (VelX, rb2D.velocity.y + 10);
				grounded = false;
			}
		}
	}

	void Movement() {
		if (Input.GetKey("a")) {
			VelX = -5;
		} else if (Input.GetKey("d")) {
			VelX = 5;
		} else {
			VelX = 0;
		}
	}
}
