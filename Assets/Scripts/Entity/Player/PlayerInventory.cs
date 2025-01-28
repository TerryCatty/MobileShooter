using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : EntityPart
{
	[SerializeField] private List<Cell> cells = new List<Cell>();
	
	
	private InventoryUI inventoryUI;
	
	public override void Init()
	{
		SaveManager.instance?.AddSaveableObject(this);
		
		filePath = Application.persistentDataPath + "/";
		base.Init();
	}
	
	public void AddItem(Item item)
	{
		try
		{
			int indexFreeCell = -1;
			indexFreeCell = cells.IndexOf(cells.FirstOrDefault(cell => cell.item == item.getItemData));
			
			if(indexFreeCell == -1)
			{
				indexFreeCell = cells.IndexOf(cells.FirstOrDefault(cell => cell.isTake == false));
			}
			
			cells[indexFreeCell].count++;
			cells[indexFreeCell].item = item.getItemData;
			
			inventoryUI?.SetCell(indexFreeCell, cells[indexFreeCell]);
			
			Destroy(item.gameObject);	
		}
		
			catch
			{
				
			}
	}
	
	public void DeleteItem(int indexCell)
	{
		cells[indexCell].count = 0;
		cells[indexCell].item = null;
		inventoryUI?.SetCell(indexCell, cells[indexCell]);
	}
	
	public void SetInventoryUI(InventoryUI inventoryUI)
	{
		this.inventoryUI = inventoryUI;
	}
	
	public void InitUI()
	{
		if(inventoryUI == null) return;
		
		for(int i = 0; i < cells.Count; i++)
		{
			inventoryUI?.SetCell(i, cells[i]);
		}
		
	}

	public override void LoadData()
	{
		for(int i = 0; i < cells.Count; i++)
		{
			if(File.Exists(filePath + $"cell{i}.json"))
			{
				string json = File.ReadAllText(filePath + $"cell{i}.json");
				cells[i] = JsonUtility.FromJson<Cell>(json);
			}
		}
	}

	public override void SaveData()
	{
		int index = 0;
		foreach(Cell cell in cells)
		{
			string json = JsonUtility.ToJson(cell);
			Debug.Log(json);
			File.WriteAllText(filePath + $"cell{index}.json", json);
			index++;
		}
		Debug.Log("Данные сохранены в " + filePath);
	}
}

[Serializable]
public class Cell
{
	public int count;
	public ItemData item;
	public bool isTake => item != null;
	
}
