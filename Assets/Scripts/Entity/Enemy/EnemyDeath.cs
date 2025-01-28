
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : EntityDeath
{
   [SerializeField] private List<ItemData> dropList;

	public override void Death()
	{
		DropItem();
		base.Death();
	}

	private void DropItem()
   {
		Instantiate(dropList[Random.Range(0, dropList.Count - 1)].itemObject, transform.position, Quaternion.identity);
   }
}

