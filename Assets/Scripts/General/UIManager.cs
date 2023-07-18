using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	// General UI Events
	public Action<string> OnSelectLevel;
	public Action OnResume;
	public Action OnPause;
	public Action OnRestart;
	public Action OnMainMenu;
	public Action OnQuit;

	// General UI Functions
	public void ResumeButton () {
		OnResume?.Invoke();
	}

	public void PauseButton () {
		OnPause?.Invoke();
	}

	public void RestartButton () {
		OnRestart?.Invoke();
	}

	public void MainMenuButton () {
		OnMainMenu?.Invoke();
	}

	public void QuitButton() {
		OnQuit?.Invoke();
	}

	public void SelectLevelButton (string levelName) {
		OnSelectLevel?.Invoke(levelName);
	}

	public virtual void UpdateScoreText(int value) {

	}
}