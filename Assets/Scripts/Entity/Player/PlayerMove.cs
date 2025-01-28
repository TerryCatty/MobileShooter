using UnityEngine;

public class PlayerMove : EntityMovement
{
	[SerializeField] private Joystick joystick;
	
	
	public bool getIsFlip => isFlip;
	
	public Vector2 getMoveValues => moveValues;
	
	private PlayerWeaponKeeper weaponKeeper;
	
	public bool BlockFlip;

	public override void Init()
	{
		weaponKeeper = GetComponent<PlayerWeaponKeeper>();
		base.Init();
	}


	protected override void SetMoveValues()
	{
		moveValues = new Vector2(joystick.Horizontal, joystick.Vertical);
	}


	protected override void Update()
	{
		base.Update();
	}
	
	protected override void CheckFlip()
	{
		if(BlockFlip) return;
		
		if(moveValues.x < 0 && isFlip == false)
		{
			Flip();
		}
		else if(moveValues.x > 0 && isFlip == true)
		{
			Flip();
		}
	}
	
	public override void Flip()
	{
		body.transform.localScale = new Vector3(body.transform.localScale.x * -1, 1, 1);
		isFlip = !isFlip;
		weaponKeeper.Flip();
	}
}
