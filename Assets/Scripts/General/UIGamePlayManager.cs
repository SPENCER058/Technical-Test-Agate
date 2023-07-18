using UnityEngine;

public class UIGamePlayManager : UIManager
{

	[SerializeField] private TMPro.TextMeshProUGUI scoreText;

	public override void UpdateScoreText (int value) {
		scoreText.text = $"Score : {value.ToString()}";
	}

}
