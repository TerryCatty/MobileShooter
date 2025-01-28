
using System;
using UnityEngine;
using UnityEngine.UI;

public class EntityHealth : EntityPart
{
   
	[SerializeField] protected HealthData healthData;
	[SerializeField] protected Image healthBar;	
	private EntityDeath entityDeath;

	public override void Init()
	{
		base.Init();
		
		entityDeath = GetComponent<EntityDeath>();
	}

	public void GetDamage(int damage)
	{
		healthData.health -= damage;
		SetFilled();
		
		if(healthData.health <= 0)
		{
			entityDeath.Death();
		}
	}
	
	protected void SetFilled()
	{
		healthBar.fillAmount = healthData.fillBar;
	}

}

[Serializable]
public struct HealthData
{
	public int health;   
	public int maxHealth;
	
	public float fillBar => 1 / (float)maxHealth * health;
}