using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target;
	
	private void Update()
	{
		if(target == null) return;
		
		Vector3 pos = target.position;
		pos.z = transform.position.z;
		transform.position = pos;
	}
}
