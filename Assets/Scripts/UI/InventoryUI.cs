using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] private List<CellUI> cells;  
	
	 private PlayerInventory inventory;
   
   
   private void Start()
   {
		int index = 0;
		foreach(CellUI cell in cells)
		{
			cell.SetInventoryUI(this);
			cell.SetIndex(index);
			index++;
		}
		
		inventory = FindAnyObjectByType<PlayerInventory>();
		inventory.SetInventoryUI(this);
		inventory.InitUI();
   }
	
	public void SetCell(int index, Cell cell)
	{
		cells[index].SetCell(cell);
	}
	
	

   public void DeleteItem(int indexCell)
   {
		inventory.DeleteItem(indexCell);
   }
}
