using UnityEngine;

public class UIGamePlayManager : UIManager
{
	[SerializeField] private TMPro.TextMeshProUGUI scoreText;
	[SerializeField] private TMPro.TextMeshProUGUI timeText;
	[SerializeField] private TMPro.TextMeshProUGUI skillText;
	[SerializeField] private TMPro.TextMeshProUGUI skillCDText;

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

}
