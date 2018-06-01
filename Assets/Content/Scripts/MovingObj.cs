using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour {

	public Vector3 MoveBy;
	protected Rigidbody2D MyBody;
	
	protected Vector3 PointA;
	protected Vector3 PointB;
	
	// Use this for initialization
	protected void Start () {
		PointA = transform.position;
		PointB = PointA + MoveBy;
		MyBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	protected static bool IsArrived(Vector3 pos, Vector3 target) 
	{
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 0.02f;
	}
}
