﻿using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

//	public Transform target;
	private UnityEngine.AI.NavMeshAgent nav;	
	// Use this for initialization
	void Awake () {
	
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
//		nav.SetDestination (target.position);
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	
	public void MoveTo(Vector3 position)
	{
		nav.SetDestination( position );
		nav.Resume ();
	}

	public void Stop()
	{
		nav.Stop ();
	}

	public bool IsStopped
	{
		get{
			return nav.remainingDistance <= nav.stoppingDistance;
		}
	}
}
