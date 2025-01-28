using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "ItemsData/Item")]
public class ItemData : ScriptableObject
{
	public Sprite imageItem;
	public string nameItem;
	public string item_id;
	public Item itemObject;
	public float dropChance;
}
