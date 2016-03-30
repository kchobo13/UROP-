using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public Transform target;
	public float smoothTime = 5f;
	public float maxSpeed = 10f;
	Vector3 toTarget;
	Vector3 velocity;

	// Use this for initialization
	void Start () {
		toTarget = target.position - this.transform.position;
	}


	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			var newPosition = Vector3.SmoothDamp (this.transform.position, target.position - toTarget, ref velocity, smoothTime, maxSpeed);
			this.transform.position = newPosition;
		}
	}
}
