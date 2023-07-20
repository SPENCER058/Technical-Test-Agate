using Unity.VisualScripting;
using UnityEngine;

public class UIGamePlayManager : UIManager
{
	[Header("UI Gameplay")]
	[SerializeField] private TMPro.TextMeshProUGUI scoreText;
	[SerializeField] private TMPro.TextMeshProUGUI timeText;
	[SerializeField] private TMPro.TextMeshProUGUI skillText;
	[SerializeField] private TMPro.TextMeshProUGUI skillCDText;

	[Header("UI Gameover")]
	[SerializeField] private TMPro.TextMeshProUGUI gameOverText;
	[SerializeField] private GameObject finalScore;
	[SerializeField] private TMPro.TextMeshProUGUI finalScoreText; 
	[SerializeField] private TMPro.TextMeshProUGUI restartText; 
	[SerializeField] private GameObject resumeButton;

	public override void UpdateScoreText (int value) {
		scoreText.text = $"Score : {value.ToString()}";
	}

	public override void UpdateTimeText (float value) {
		int intVal = (int)value; 
		timeText.text = $"Time : {intVal.ToString()}s";
	}

	public override void UpdateSkillText (float value) {
		skillText.text = $"Skill : {value.ToString()}";
	}

	public override void UpdateSkillCDText (float value) {
		int intVal = (int)value;
		skillCDText.text = $"CD : {intVal.ToString()}s";
	}

	public override void UpdateGameOverText (int finalScore) {
		gameOverText.text = "Game Over";
		resumeButton.SetActive(false);
		restartText.text = "Play Again";
		this.finalScore.SetActive(true);
		finalScoreText.text = $"Final Score : {finalScore}";
	}

}
