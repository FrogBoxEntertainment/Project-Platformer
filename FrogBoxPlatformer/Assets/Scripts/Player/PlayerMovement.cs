using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector2 velocity;
	public Rigidbody2D rb2D;
	public bool grounded = false;
	public int VelX = 0;
	public int VelY = -1;

	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	

	void Update () {
		Jump();
		if (Input.GetKey("a")) {
			VelX = -3;
		} else if (Input.GetKey("d")) {
			VelX = 3;
		} else {
			VelX = 0;
		}

		rb2D.velocity = new Vector2 (VelX, rb2D.velocity.y);
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {
			grounded = true;
		}
	}

	void Jump() {
		if (Input.GetKeyDown("space")) {
			if (grounded == true) {
				rb2D.velocity = new Vector2 (VelX, rb2D.velocity.y + 7);
				grounded = false;
			}
		}
	}
}
