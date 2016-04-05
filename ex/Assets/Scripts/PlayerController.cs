using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 0.04f;
	public float clockwise = 150.0f;
	public float counterClockwise = -150.0f;
    public int count;
    public Text countText;
    public GameObject main;
    

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
            rb.position += transform.forward * speed;
        }
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

    IEnumerator Stagger(float speed)
    {
        speed = 0.0f;
        yield return new WaitForSeconds(3.0f);
        speed = 0.5f;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
