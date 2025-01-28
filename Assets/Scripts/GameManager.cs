using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	
	private void Awake()
	{
		if(instance == null) instance = this;
		else Destroy(gameObject);
	}
	
	public void EndSession()
	{
		Invoke("Save", 2f);
	}
	
	private void Save()
	{
		SaveManager.instance.SaveAll();
	}
}
