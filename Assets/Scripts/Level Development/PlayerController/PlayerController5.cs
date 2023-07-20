using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController5 : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	private Vector2 mousePosition;

	private void OnMoveMouse(InputValue value) {
		mousePosition = value.Get<Vector2>();
	}

	private void FixedUpdate () {
		transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
	}
}
