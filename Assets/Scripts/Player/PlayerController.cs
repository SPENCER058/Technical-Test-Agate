using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	//[SerializeField] private Vector2 intialForce = new Vector2(5f, 5f);
	[SerializeField] private Vector2 addForce = new Vector2(0f, 0f);
	[SerializeField] private float forceStrength = 5f;
	[SerializeField] private Rigidbody2D rigidBody2D;

	public System.Action OnSkillUsed;

	private float skillAvailable = 0f;
	private float skillDelay = 1f;
	private bool canUseSkill = true;

	public void Initialize () {
		//rigidBody2D.AddForce(intialForce, ForceMode2D.Impulse);
	}

	public void OnMove (InputValue value) {
		Vector2 temporaryValue = value.Get<Vector2>();

		if (skillAvailable >= 1f && canUseSkill) {
			addForce = new Vector2(temporaryValue.x, temporaryValue.y) * forceStrength;
			skillAvailable--;
			OnSkillUsed?.Invoke();
			StartCoroutine(DelaySkillUse());
		}

	}

	private void FixedUpdate () {
		rigidBody2D.AddForce(addForce, ForceMode2D.Impulse);
		ResetForce();
	}

	private void OnCollisionStay2D (Collision2D collision) {

		Vector2 collisionNormal = collision.contacts[0].normal;
		Vector2 newDirection = Vector2.Reflect(rigidBody2D.velocity.normalized, collisionNormal);
		rigidBody2D.velocity = newDirection * rigidBody2D.velocity.magnitude;
	}

	public void SetAvailableSkill (float amount) {
		skillAvailable = amount;
	}

	private void ResetForce () {
		addForce = new Vector2(0f, 0f);
	}

	private IEnumerator DelaySkillUse () {
		canUseSkill = false;
		yield return new WaitForSeconds(skillDelay);
		canUseSkill = true;
	}

}
