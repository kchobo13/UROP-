using UnityEngine;
using System.Collections;

public class RemoveDoor : MonoBehaviour {

    public GameObject player;
    public GameObject wall;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        PlayerController playerscript = player.GetComponent<PlayerController>();
        if (playerscript.count == 8 )
        {
            wall.SetActive(false);
        }
	}
}
