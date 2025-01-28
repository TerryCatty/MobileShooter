using UnityEngine;

public class EntityPart : MonoBehaviour, ISaveableObject
{
	[SerializeField] protected bool isActive;
	protected string filePath;

	public virtual void Init()
	{
		isActive = true;
		
		LoadData();
	}
	
	public virtual void SaveData()
	{

	}
	
	public virtual void LoadData()
	{

	}
}
