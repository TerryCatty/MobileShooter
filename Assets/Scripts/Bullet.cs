

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private int damage;
	[SerializeField] private int _speed;
	[SerializeField] private float lifetime;
	
	
	private Rigidbody2D rb;
	
	public void Init()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * _speed;
		Invoke("DestroyBullet", lifetime);
	}
	
	public void SetRotation(Vector3 rot)
	{
		transform.rotation = Quaternion.Euler(rot);
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.TryGetComponent(out EntityHealth entity))
		{
			entity.GetDamage(damage);
		}
		
		DestroyBullet();
	}
	
	private void DestroyBullet()
	{
		Destroy(gameObject);
	}
	
}
