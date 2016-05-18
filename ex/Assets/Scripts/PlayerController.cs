using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VR;


public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
	public float room;
	public float hall;
    public int count;
    public Text countText;
    public GameObject main;
	public GameObject vr;
	private float smoothv;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

	void Restart() 
	{
		SceneManager.LoadScene ("minigame");
	}

	void Update()
	{
        Interpolate inter = main.GetComponent<Interpolate>();
        if (!inter.switch_cam)
        {
			if (inter.in_room) {
				speed = 0.03f;
				if (Input.GetMouseButtonDown (0)) {
					speed = 0;
				}
				rb.position += transform.forward * speed;
				var turn = vr.transform.eulerAngles.y;

				if (turn >= 5.0f && turn <= 120.0f) 
				{
					transform.Rotate (0, 0.5f * Time.deltaTime * room, 0);
				}

				if (turn <= 360.0f && turn >= 240.0f) 
				{
					transform.Rotate (0, -0.5f * Time.deltaTime * room, 0);
				}
			} 

			else 
			{
				speed = 0.015f;
				if (Input.GetMouseButtonDown (0)) {
					speed = 0;
				}
				rb.position += transform.forward * speed;
				var turn = vr.transform.eulerAngles.y;
				Vector3 to = new Vector3(0f, turn, 0f);
				transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, to, Time.deltaTime);
			}
        }
			
	}


    void FixedUpdate()
    {
		if(Input.GetKey(KeyCode.Q)) {
			transform.Rotate(0, -Time.deltaTime * hall, 0);
		}
		else if(Input.GetKey(KeyCode.E)) {
			transform.Rotate(0, Time.deltaTime * hall, 0);
		}
    }

    void OnTriggerEnter(Collider other)
    {
        Interpolate inter = main.GetComponent<Interpolate>();
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
		if (other.gameObject.CompareTag("die"))
		{	
			Restart ();
		}
        if (other.gameObject.CompareTag("switch"))
        {
            inter.switch_cam = true;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
