using UnityEngine;

public class PlayerAction : EntityPart
{
	private PlayerInventory inventory;
	public override void Init()
	{
		base.Init();
		inventory = GetComponent<PlayerInventory>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.TryGetComponent(out Item item))
		{
			inventory.AddItem(item);
		}
	}
}
