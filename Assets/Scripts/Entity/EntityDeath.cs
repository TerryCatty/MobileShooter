
using System;

public class EntityDeath : EntityPart
{
	public Action onDeath;
	public virtual void Death()
	{
		onDeath?.Invoke();
		Destroy(gameObject);
	}
}
