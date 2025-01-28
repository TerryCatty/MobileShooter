using System.Collections.Generic;
using UnityEngine;

public class DetectZone : EntityPart
{
	[SerializeField] protected List<GameObject> targetList;
	[SerializeField] protected float timeCheck;
	
	protected GameObject nearTarget;
	protected float timer;
	
	public GameObject getTarget => nearTarget;
	
	[SerializeField] protected string tagDetected;
	
	void Update()
	{
		if(isActive == false) return;
		
		if(timer >= 0) 
			timer -= Time.deltaTime;
		
		CheckNearTarget();
	}
	
	protected virtual void CheckNearTarget()
	{
		if(targetList.Count == 0 || timer > 0) return;
		
		timer = timeCheck;
		
		nearTarget = targetList[0];
		float distance = Vector2.Distance(transform.position, nearTarget.transform.position);
		
		foreach(GameObject target in targetList)
		{
			float newDistance = Vector2.Distance(transform.position, target.transform.position);
			
			if(newDistance < distance)
			{
				nearTarget = target;
				distance = newDistance;
			}
		}
		
	}
	
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == tagDetected)
		{
			targetList.Add(collider.gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.tag == tagDetected)
		{
			if(targetList.Contains(collider.gameObject)) targetList.Remove(collider.gameObject);
		}
	}
	
}
