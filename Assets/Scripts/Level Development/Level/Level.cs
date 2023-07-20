using UnityEngine;

public class Level : MonoBehaviour
{

	private void Start () {
		if (Time.timeScale == 0f) {
			Resume();
		}
	}

	public void Pause () {
		Time.timeScale = 0f;
	}

	public void Resume () {
		Time.timeScale = 1f;
	}
}
