using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : GameManager
{
	[SerializeField] private AudioManager _audioManager;
	[SerializeField] private SpawnerCalculator _spawnerCalculator;

	[Header("Script Ref")]
	[SerializeField] private PlayerController playerController;

	[Header("Others")]
	[SerializeField] private GameObject playerGameObject;
	[SerializeField] private PickableItem pickableItem;
	[SerializeField] private GameObject coinPrefabs;

	[Header("Game Data")]
	[SerializeField] private int score = 0;
	[SerializeField] private float skillAvailable = 0f;
	[SerializeField] private List<GameObject> itemPooling;

	[Header("Game Settings")]
	[SerializeField] private int generateCoin = 7;
	[SerializeField] private float maxSkill = 3f;
	[SerializeField] private float skillCooldownTime = 7f;
	[SerializeField] private float itemCooldownTime = 5f;
	[SerializeField] private float gameTimeRemaining = 60f;

	private float itemRespawnTimer = 0f;
	private float skillCooldownTimer = 0f;
	private bool isGamePaused = false;

	private void OnEnable () {
		_uiManager.OnPause += PauseGame;
		_uiManager.OnResume += ResumeGame;

		skillAvailable = maxSkill;

		_uiManager.UpdateScoreText(score);
		_uiManager.UpdateTimeText(gameTimeRemaining);
		_uiManager.UpdateSkillText(skillAvailable);
		_uiManager.UpdateSkillCDText(skillCooldownTimer);

		pickableItem.OnPickUp += OnitemPickUp;

		playerController.OnSkillUsed += SkillUsed;
	}

	private void Start () {
		itemPooling = new List<GameObject>();

		//playerController.Initialize();
		playerController.SetAvailableSkill(skillAvailable);

		itemRespawnTimer = itemCooldownTime;
		_spawnerCalculator.TrackPlayer(playerGameObject.transform.position);

		// TODO : Instantiate coin prefabs with random position
		for (int i = 0; i < generateCoin; i++) {
			GameObject coin = Instantiate(coinPrefabs);
			coin.transform.position = _spawnerCalculator.GetRandomSpawnPoint();
			coin.SetActive(true);
		}

		if (Time.timeScale == 0) {
			ResumeGame();
		}
	}

	private void Update () {

		_spawnerCalculator.TrackPlayer(playerGameObject.transform.position);

		if (!isGamePaused) {
			if (itemPooling.Count > 0) {
				if (itemRespawnTimer <= 0f) {

					GameObject itemToRespawn = itemPooling[0];
					itemPooling.RemoveAt(0);
					RespawnItem(itemToRespawn);
					itemRespawnTimer = itemCooldownTime;

				} else {
					itemRespawnTimer -= Time.deltaTime;
				}
			}

			if (skillAvailable < maxSkill) {

				if (skillCooldownTimer <= 0f) {

					skillAvailable++;
					playerController.SetAvailableSkill(skillAvailable);
					_uiManager.UpdateSkillText(skillAvailable);

					skillCooldownTimer = skillCooldownTime;

				} else {
					skillCooldownTimer -= Time.deltaTime;
				}

				_uiManager.UpdateSkillCDText(skillCooldownTimer);

			}

			if (gameTimeRemaining <= 0f) {

			} else {
				gameTimeRemaining -= Time.deltaTime;
				_uiManager.UpdateTimeText(gameTimeRemaining);
			}

		}

	}

	private void OnDisable () {

		_uiManager.OnPause -= PauseGame;
		_uiManager.OnResume -= ResumeGame;

		pickableItem.OnPickUp -= OnitemPickUp;
		playerController.OnSkillUsed -= SkillUsed;
	}

	private void PauseGame () {
		Time.timeScale = 0;
		isGamePaused = true;
	}

	private void ResumeGame () {
		Time.timeScale = 1;
		isGamePaused = false;
	}

	private void SkillUsed () {
		skillAvailable--;
		_uiManager.UpdateSkillText(skillAvailable);
	}

	private void OnitemPickUp (ItemType itemType, int value, GameObject gameObject) {

		switch (itemType) {
			case ItemType.coin:
				// TODO Add coin to player

				score += value;
				_uiManager.UpdateScoreText(score);
				_audioManager.PlayCoinSound();
				itemPooling.Add(gameObject);

				break;
			case ItemType.addTime:
				// TODO Add time to player
				break;
		}

		gameObject.SetActive(false);
	}

	private void RespawnItem(GameObject item) {
		item.transform.position = _spawnerCalculator.GetRandomSpawnPoint();
		item.SetActive(true);
		itemPooling.Remove(item);
	}
}
