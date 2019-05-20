using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	[SerializeField]
	float speed;

	float radius;
	Vector2 direction;
	[SerializeField]
	Vector2 move;
	// Use this for initialization
	void Start () {
		direction = -Vector2.one.normalized;
		radius = transform.localScale.x / 2;
	}
	
	// Update is called once per frame
	void Update () {
		move = direction * speed * Time.deltaTime;
		transform.Translate(direction * speed * Time.deltaTime);

		if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0) {
			direction.y = -direction.y;
		}
		if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
		{
			direction.y = -direction.y;
		}

		if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0) {
			Debug.Log("Right Player wins");
			
            this.transform.position = new Vector3(0f, 0f, 0f);
		}
		if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0) {
			Debug.Log("Left Player wins");
			
            this.transform.position = new Vector3(0f, 0f, 0f);
        }
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Paddle") {
			bool isRight = other.GetComponent<Paddle>().isRight;

			if (isRight == true && direction.x > 0) {
				direction.x = -direction.x;
			}
			if (isRight == false && direction.x < 0) {
				direction.x = -direction.x;
			}
			
		}
	}
}
