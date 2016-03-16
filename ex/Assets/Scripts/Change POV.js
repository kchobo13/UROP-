#pragma strict

var Player : GameObject;
var FPCam : GameObject;
var TPCam : GameObject;
var check;


function Start () {
	FPCam.gameObject.active = false;
	TPCam.gameObject.active = true;
	check = true;
}

function Update () {
	if (Input.GetKeyDown(KeyCode.R)) {
		if (check) {
			FPCam.gameObject.active = true;
			TPCam.gameObject.active = false;
		}
		else {
			FPCam.gameObject.active = false;
			TPCam.gameObject.active = true;
		}

		check = !check;
	}
}