using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   	[SerializeField] private Transform point1, point2;
	[SerializeField] private GameObject prefabEnemy;
   
	[SerializeField] private List<Enemy> enemiesSpawned = new List<Enemy>();
	[SerializeField] int countSpawnedEnemies;
	int countEnemies;
	
	private void Start()
	{
		StartSpawn();
	}
	
	private void StartSpawn()
	{
		for(int i = 0; i < countSpawnedEnemies; i++)
		{
			Vector3 randPos = new Vector2(Random.Range(point1.position.x, point2.position.x), Random.Range(point1.position.y, point2.position.y));
			Enemy enemy = Instantiate(prefabEnemy, randPos, Quaternion.identity).GetComponent<Enemy>();
			
			enemiesSpawned.Add(enemy);
			
			if(enemy.TryGetComponent(out EntityDeath enemyDeath))
			{
				enemyDeath.onDeath += CheckEnemies;
			}
		}
		
		countEnemies = enemiesSpawned.Count;
		
	}
	
	public void CheckEnemies()
	{
		countEnemies--;
		
		if(countEnemies == 0)
		{
			GameManager.instance.EndSession();
		}
	}
}
