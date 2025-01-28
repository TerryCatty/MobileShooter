
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellUI : MonoBehaviour
{
   [SerializeField] private Cell cell;
   [SerializeField] private Image image;
   [SerializeField] private TextMeshProUGUI textCell;
   
   [SerializeField] private GameObject DeleteButton;
   
   private int index;
   
   private InventoryUI inventoryUI;
   
   public void SetCell(Cell cell)
   {
		this.cell = cell;
		
		UpdateText();
		UpdateImage();
   }
   
   public void SetInventoryUI(InventoryUI inventory)
   {
		inventoryUI = inventory;
   }
   
   public void SetIndex(int value)
   {
		index = value;
   }
   
   public void UpdateText()
   {
		if(cell.count <= 1) textCell.text = "";
		else textCell.text = cell.count.ToString();
   }
   
   public void UpdateImage()
   {
		if(cell.item == null)
		{
			image.sprite = null;
			image.color = new Color(1,1,1,0);
		}
		else
		{
			image.sprite = cell.item.imageItem;
			image.color = new Color(1,1,1,1);
		}
   }
   
   public void OpenDeleteButton()
   {
		if(cell.count == 0)
		{
	 		DeleteButton.SetActive(false);
			return;
		}
	
	 	DeleteButton.SetActive(!DeleteButton.activeInHierarchy);
   }
   
   public void DeleteItem()
   {
		inventoryUI.DeleteItem(index);
		OpenDeleteButton();
   }
}
