using UnityEngine;

[CreateAssetMenu(fileName = "PickableItem", menuName = "ScriptableObject/PickableItem")]
public class PickableItem : ScriptableObject
{
	
	public System.Action<ItemType, int, GameObject> OnPickUp;

	public void PickUp(ItemType itemType, int value, GameObject gameObject) {
		OnPickUp?.Invoke(itemType, value, gameObject);
	}
}
