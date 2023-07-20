using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController5 : MonoBehaviour
{
	[SerializeField] private float speed = 10f;
	private Vector2 mousePosition;

	private void OnMoveMouse(InputValue value) {
		mousePosition = value.Get<Vector2>();
	}

	private void Update () {
		Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

		transform.position = Vector3.MoveTowards(transform.position, worldMousePosition, speed * Time.deltaTime);
	}
}
