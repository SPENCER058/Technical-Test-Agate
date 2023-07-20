using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController4 : MonoBehaviour
{
	[SerializeField] private Rigidbody2D playerRigidbody2D;

	private Vector2 moveForce;

	private void OnMove (InputValue value) {
		moveForce = value.Get<Vector2>().normalized;
	}

	private void FixedUpdate () {
		playerRigidbody2D.AddForce(new Vector2(moveForce.x, moveForce.y), ForceMode2D.Impulse);
	}
}
