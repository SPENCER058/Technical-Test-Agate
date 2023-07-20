using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

	[SerializeField] private string mainMenuSceneName;

	private string currentSceneName;

	public void Initialize () {
		currentSceneName = SceneManager.GetActiveScene().name;
	}

	public string GetCurrentSceneName () {
		return currentSceneName;
	}

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void LoadMainMenu () {
		LoadScene(mainMenuSceneName);
	}

}
