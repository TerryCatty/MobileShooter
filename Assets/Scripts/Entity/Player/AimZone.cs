using System.Collections.Generic;
using UnityEngine;

public class AimZone : DetectZone
{
	
	private PlayerShoot playerShoot;
	private PlayerMove playerMove;
	[SerializeField] private GameObject defaultTargetRotate;
	

	public override void Init()
	{
		base.Init();
		
		playerMove = GetComponent<PlayerMove>();
		playerShoot = GetComponent<PlayerShoot>();
	}


	protected override void CheckNearTarget()
	{
		if(targetList.Count == 0) 
		{
			playerShoot.SetTarget(defaultTargetRotate);
			if(playerMove.BlockFlip) playerMove.BlockFlip = false;
			return;
		}
		
		base.CheckNearTarget();
		
		playerShoot.SetTarget(nearTarget);
		if(playerMove.BlockFlip == false) playerMove.BlockFlip = true;
	}

}
