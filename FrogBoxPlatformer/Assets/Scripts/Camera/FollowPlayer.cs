using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject Player;

	void Update () {
		if (Player != null) {
			transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + 1.5f, -6);
		}
	}
}
