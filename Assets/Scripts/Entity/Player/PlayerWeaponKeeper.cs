using UnityEngine;

public class PlayerWeaponKeeper : EntityPart
{
	[SerializeField] private Weapon currentWeapon;
	[SerializeField] private Transform weaponKeeperObject;
	
	[SerializeField] private GameObject target;
	
	public Weapon getWeapon => currentWeapon;
	public Transform getKeeperObject => weaponKeeperObject;
	[SerializeField] private float speedAim;
	[SerializeField] private GameObject defaultTargetRotate;
	
	private PlayerMove playerMove;
	private Vector2 direction = new Vector2();
	private float angle = 0;
	public override void Init()
	{
		playerMove = GetComponent<PlayerMove>();
		base.Init();
	}
	private void Update()
	{
		AimToTarget();
		
		if(playerMove != null)
		{
			CheckFlip();
		}
	}
	
	private void CheckFlip()
	{
		if(playerMove.BlockFlip == false) return;
		
		if(target == null) return;
		
		if(target.transform.position.x < transform.position.x && playerMove.getIsFlip == false)
		{
			playerMove.Flip();
		}
		else if(target.transform.position.x > transform.position.x && playerMove.getIsFlip == true)
		{
			playerMove.Flip();
		}
	}
	
	public void SetTarget(GameObject target)
	{
		if(this.target == target) return;
		
		RotateAim(direction);
		this.target = target;
	}
	
	public void AimToTarget()
	{
		if(target == null) return;
		
		RotateAim(new Vector3(playerMove.getMoveValues.x, playerMove.getMoveValues.y).normalized);
		
		direction = (target.transform.position - weaponKeeperObject.position).normalized;
		angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		
		weaponKeeperObject.rotation = Quaternion.Slerp(weaponKeeperObject.rotation, Quaternion.Euler(0,0,angle), speedAim * Time.deltaTime);
	}
	
	private void RotateAim(Vector2 dir)
	{
		if(dir.x != 0 && dir.y != 0)
		{
			Vector2 direction = dir; 
			float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
			defaultTargetRotate.transform.rotation = targetRotation;
		}
	}
	
	public void AimToTargetImmediately()
	{
		weaponKeeperObject.rotation = Quaternion.Euler(0,0,angle);
	}
	
	
	public void Flip()
	{
		weaponKeeperObject.localScale = new Vector3(weaponKeeperObject.localScale.x * -1, weaponKeeperObject.localScale.x * -1, 1);
		AimToTargetImmediately();
	}
}
