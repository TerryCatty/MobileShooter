
public class EnemyZoneDetected : DetectZone
{
	private EnemyMovement movement;
	public override void Init()
	{
		base.Init();
		movement = GetComponent<EnemyMovement>();
	}
	protected override void CheckNearTarget()
	{
		if(targetList.Count == 0)
		{
			 movement.SetTargetMove(null);
			 return;
		}
		
		base.CheckNearTarget();
		
		movement?.SetTargetMove(nearTarget.transform);
	}
}
