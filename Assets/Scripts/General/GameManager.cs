using UnityEngine;

public class GameManager : MonoBehaviour
{

	[Header("Managers")]
	[SerializeField] protected UIManager _uiManager;
	[SerializeField] private GameSceneManager _gameSceneManager;

	private void OnEnable () {

		_uiManager.OnRestart += RestartGame;
		_uiManager.OnMainMenu += MainMenu;
		_uiManager.OnQuit += QuitGame;

		_uiManager.OnSelectLevel += _gameSceneManager.LoadScene;

	}

	private void Start () {
		_gameSceneManager.Initialize();
	}

	private void OnDisable () {

		_uiManager.OnRestart -= RestartGame;
		_uiManager.OnMainMenu -= MainMenu;
		_uiManager.OnQuit -= QuitGame;

		_uiManager.OnSelectLevel -= _gameSceneManager.LoadScene;
	}



	private void RestartGame () {
		_gameSceneManager.LoadScene(
			_gameSceneManager.GetCurrentSceneName()
		);
	}

	private void MainMenu () {
		_gameSceneManager.LoadMainMenu();
	}

	private void QuitGame () {
		#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
		#else
				Application.Quit();
		#endif
	}

}
