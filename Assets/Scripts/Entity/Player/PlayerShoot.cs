


using UnityEngine;

public class PlayerShoot : EntityPart
{
	private PlayerWeaponKeeper weaponKeeper;
	
	public override void Init()
	{
		base.Init();
		
		weaponKeeper = GetComponent<PlayerWeaponKeeper>();
	}
	
	
	public void SetTarget(GameObject target)
	{
		weaponKeeper.SetTarget(target);
	}
	
	
	public void ButtonDown()
	{
		weaponKeeper?.getWeapon?.StartShooting();
	}
	
	public void ButtonUp()
	{
		weaponKeeper?.getWeapon?.StopShooting();
	}
	
}
