using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Vector2 intialForce = new Vector2(5f, 5f);
	[SerializeField] private Vector2 addForce = new Vector2(0f, 0f);
	[SerializeField] private float forceStrength = 5f;
	[SerializeField] private Rigidbody2D rigidBody2D;

	public void Initialize () {
		rigidBody2D.AddForce(intialForce, ForceMode2D.Impulse);
	}

	public void OnMove (InputValue value) {
		Vector2 temporaryValue = value.Get<Vector2>();
		addForce = new Vector2(temporaryValue.x, temporaryValue.y) * forceStrength;
	}

	private void FixedUpdate () {
		rigidBody2D.AddForce(addForce, ForceMode2D.Impulse);
		ResetForce();
	}

	private void OnCollisionStay2D (Collision2D collision) {

		Vector2 collisionNormal = collision.contacts[0].normal;
		Vector2 newDirection = Vector2.Reflect(rigidBody2D.velocity.normalized, collisionNormal);
		rigidBody2D.velocity = newDirection * rigidBody2D.velocity.magnitude;
	}

	private void ResetForce () {
		addForce = new Vector2(0f, 0f);
	}
}
