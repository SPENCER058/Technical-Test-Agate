using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController7 : MonoBehaviour
{
	[SerializeField] private Rigidbody2D playerRigidbody2D;
	[SerializeField] private TMPro.TextMeshProUGUI scoreText;
	private int score = 0;
	private Vector2 moveForce;

	private void OnMove (InputValue value) {
		moveForce = value.Get<Vector2>().normalized;
	}

	private void FixedUpdate () {
		playerRigidbody2D.AddForce(new Vector2(moveForce.x, moveForce.y), ForceMode2D.Impulse);
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.CompareTag("Coin")) {
			collision.gameObject.SetActive(false);
			score++;
			UpdateScoreText(score);
		}
	}

	private void UpdateScoreText (int score) {
		scoreText.text = $"Score : {score}";
	}

}
