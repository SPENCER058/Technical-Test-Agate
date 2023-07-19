using UnityEngine;

public class AudioManager : MonoBehaviour
{

	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip coinSound;

	public void PlayCoinSound () {
		audioSource.PlayOneShot(coinSound);
	}
}
