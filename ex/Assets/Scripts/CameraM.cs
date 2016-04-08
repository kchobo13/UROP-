using UnityEngine;
using System.Collections;

public class CameraM : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
	}


	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.R)) 
		{
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 1.0f);
		}
	}
}
