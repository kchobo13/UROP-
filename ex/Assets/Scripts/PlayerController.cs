using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 0.04f;
	public float clockwise = 150.0f;
	public float counterClockwise = -150.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

	void Restart() 
	{
		SceneManager.LoadScene ("minigame");
	}

	void Update()
	{
		rb.position += transform.forward * speed;
	}


    void FixedUpdate()
    {
		if(Input.GetKey(KeyCode.Q)) {
			transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
		}
		else if(Input.GetKey(KeyCode.E)) {
			transform.Rotate(0, Time.deltaTime * clockwise, 0);
		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
		if (other.gameObject.CompareTag("die"))
		{	
			Restart ();
		}
    }
}
