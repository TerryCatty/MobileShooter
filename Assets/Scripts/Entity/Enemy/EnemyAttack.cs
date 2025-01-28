using UnityEngine;

public class EnemyAttack : EntityPart
{
   [SerializeField] private float distanceAttack;
   [SerializeField] private float timeBetweenAttacks;
   [SerializeField] private int damage;
   private float timer;
   
   private EnemyZoneDetected zoneDetected;
   
   private GameObject targetAttack => zoneDetected?.getTarget;

	public override void Init()
	{
		base.Init();
		zoneDetected = GetComponent<EnemyZoneDetected>();
	}

	private void Update()
	{
		if(timer >= 0) timer -= Time.deltaTime;
		
		if(targetAttack != null)
		{
			if(Vector2.Distance(transform.position, targetAttack.transform.position) <= distanceAttack)
			{
				Attack();
			}
		}
		
	}
	
	private void Attack()
	{
		if(timer <= 0)
		{
			if(targetAttack.TryGetComponent(out EntityHealth entity))
			{
				entity.GetDamage(damage);
				timer = timeBetweenAttacks;
			}
		}
	}
}
