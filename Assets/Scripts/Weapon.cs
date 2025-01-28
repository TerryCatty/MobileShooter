using UnityEngine;

public class Weapon : MonoBehaviour, ISaveableObject
{
	private bool isShooting;
	private bool isRealod;
	private Transform weaponKeeper;
	[SerializeField] private Transform shotPoint;
	[SerializeField] private GameObject prefabBullet;
	
	[SerializeField] private int maxAmmo;
	[SerializeField] private int ammo;
	[SerializeField] private float timeBetweenShots;
	[SerializeField] private float timeReload;
	
	private float timer;
	
	private void Start()
	{
		weaponKeeper = GetComponentInParent<Transform>();
	}
	
   	public void StartShooting(){
		isShooting = true;
   	}
   
   	public void StopShooting(){
		isShooting = false;
   	}
   
   	public void CheckShoot()
   	{
		if(isRealod) return;
		
		if(timer <= 0)
		{
			timer = timeBetweenShots;
			Shoot();
		}
		
		if(ammo <= 0)
		{
			timer = timeReload;
			isRealod = true;
		}
   	}
	
	private void Shoot()
	{
		ammo--;
		Bullet bullet = Instantiate(prefabBullet, shotPoint.position, Quaternion.identity).GetComponent<Bullet>();
		bullet.SetRotation(weaponKeeper.rotation.eulerAngles);
		bullet.Init();
	}
	
	private void Reload()
	{
		if(timer <= 0)
		{
			ammo = maxAmmo;
			isRealod = false;
		}
	}
	
	private void Update()
	{
		if(timer > 0)
		{
			timer -= Time.deltaTime;
		}
		
		if(isShooting)
		{
			if(isRealod) Reload();
			else  CheckShoot();
		}
	}

	public void SaveData()
	{
		
	}

	public void LoadData()
	{
		
	}
}
