using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField] private ItemType itemType;
	[SerializeField] private int value;
	[SerializeField] private PickableItem pickableItem;
	[SerializeField] private GameObject thisGameObject;

	private void OnCollisionEnter2D (Collision2D collision) {
		pickableItem.PickUp(this.itemType, this.value, this.thisGameObject);
	}
}
