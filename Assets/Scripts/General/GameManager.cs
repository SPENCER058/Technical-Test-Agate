using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private UIManager _uiManager;
	[SerializeField] private GameSceneManager _gameSceneManager;
	[SerializeField] private PickableItem pickableItem;
	[SerializeField] private PlayerController playerController;

	private int score = 0;

	private void OnEnable () {
		_uiManager.OnPause += PauseGame;
		_uiManager.OnResume += ResumeGame;
		_uiManager.OnRestart += RestartGame;
		_uiManager.OnMainMenu += MainMenu;
		_uiManager.OnQuit += QuitGame;

		_uiManager.OnSelectLevel += _gameSceneManager.LoadScene;
		_uiManager.UpdateScoreText(score);

		pickableItem.OnPickUp += OnitemPickUp;

	}

	private void Start () {
		_gameSceneManager.Initialize();
		playerController.Initialize();

		if (Time.timeScale == 0) {
			ResumeGame();
		}
	}

	private void OnDisable () {
		_uiManager.OnPause -= PauseGame;
		_uiManager.OnResume -= ResumeGame;
		_uiManager.OnRestart -= RestartGame;
		_uiManager.OnMainMenu -= MainMenu;
		_uiManager.OnQuit -= QuitGame;

		_uiManager.OnSelectLevel -= _gameSceneManager.LoadScene;

		pickableItem.OnPickUp -= OnitemPickUp;
	}

	private void PauseGame () {
		Time.timeScale = 0;
	}

	private void ResumeGame () {
		Time.timeScale = 1;
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

	private void OnitemPickUp (ItemType itemType, int value, GameObject gameObject) {

		switch (itemType) {
			case ItemType.coin:
				// TODO Add coin to player

				score += value;
				_uiManager.UpdateScoreText(score);

				break;
			case ItemType.addTime:
				// TODO Add time to player
				break;
		}

		gameObject.SetActive(false);
	}

}
