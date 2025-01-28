using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Entity : MonoBehaviour
{	
	[SerializeField] protected List<EntityPart> entityParts = new List<EntityPart>();
	

	private void Start()
	{
		Init();
	}
	
	public void Init()
	{
		foreach(EntityPart part in entityParts)
		{
			part.Init();
		}
	}
	
	
}

