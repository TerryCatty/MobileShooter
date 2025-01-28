
using UnityEngine;

public class EntityMovement : EntityPart
{
	protected Vector2 moveValues;
	protected Rigidbody2D rb;
	
	[SerializeField] protected GameObject body;

	[SerializeField] protected float _speed;
	
	protected bool isFlip;
	
	private void Start()
	{
		Init();
	}

	public override void Init()
	{
		base.Init();

		rb = GetComponent<Rigidbody2D>();
	}
	
	protected virtual void Update()
	{
		if (isActive == false) return;
		
		SetMoveValues();
		CheckFlip();

		Move(moveValues);
	}

	
	protected virtual void SetMoveValues()
	{
		
	}
	
	public void Move(Vector2 moveValues)
	{
		rb.velocity = new Vector2 (moveValues.x, moveValues.y) * _speed;
	}
	
	
	protected virtual void CheckFlip()
	{
		if(moveValues.x < 0 && isFlip == false)
		{
			Flip();
		}
		else if(moveValues.x > 0 && isFlip == true)
		{
			Flip();
		}
	}
	
	public virtual void Flip()
	{
		body.transform.localScale = new Vector3(body.transform.localScale.x * -1, 1, 1);
		isFlip = !isFlip;
	}
}
