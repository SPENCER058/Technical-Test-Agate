using UnityEngine;

public class SpawnerCalculator : MonoBehaviour
{
	[SerializeField] private Vector2 minSpawnOffset;
	[SerializeField] private Vector2 maxSpawnOffset;
	[SerializeField] private float spawnRadius;
	private Vector2 playerPosition;
	private Vector2 spawnPoint;

	public void TrackPlayer(Vector2 playerPosition) {
		this.playerPosition = playerPosition;
	}

	public Vector2 GetRandomSpawnPoint () {
		CalculateSpawnPoint();
		return spawnPoint;
	}

	private void CalculateSpawnPoint () { 
		bool isSpawnPointValid = false;

		while (!isSpawnPointValid) {
			CalculateRandomSpawnPoint();
			isSpawnPointValid = CheckSpawnPointCollision();
		}
	}

	private void CalculateRandomSpawnPoint () {
		spawnPoint = new Vector2 (
			Random.Range(minSpawnOffset.x, maxSpawnOffset.x),
			Random.Range(minSpawnOffset.y, maxSpawnOffset.y)
		);
	}

	private bool CheckSpawnPointCollision () {

		Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(
			spawnPoint + playerPosition,
			spawnRadius
		);

		if (collider2Ds.Length > 0) {
			return true;
		}

		return false;
	}

}
