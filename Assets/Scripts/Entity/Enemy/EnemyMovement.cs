using UnityEngine;

public class EnemyMovement : EntityMovement
{
	private Transform targetMove;
	[SerializeField] private float minDistance;
	
	public void SetTargetMove(Transform target)
	{
		targetMove = target;
	}

	protected override void SetMoveValues()
	{
		if(targetMove == null || Vector2.Distance(transform.position, targetMove.position) <= minDistance)
		{
			 moveValues = new Vector2(0,0);
			 return;
		}
		
		moveValues = (targetMove.position - transform.position).normalized;
	}
}
