using UnityEngine;

public class Level2 : Level
{
	[SerializeField] private Rigidbody2D playerRigidbody2D;

	private void Start () {
		playerRigidbody2D.AddForce(new Vector2(10f, 10f), ForceMode2D.Impulse);

		if (Time.timeScale == 0f) {
			Resume();
		}
	}

}
