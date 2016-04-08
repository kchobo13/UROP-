using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VR;


public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 0.04f;
	public float clockwise = 150.0f;
	public float counterClockwise = -150.0f;
    public int count;
    public Text countText;
    public GameObject main;
	public GameObject vr;
    

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

		var turn = vr.transform.eulerAngles.y;

		if (turn > 5.0f && turn < 90.0f) 
		{
			transform.Rotate(0, 0.5f * Time.deltaTime * clockwise, 0);
		}

		if (turn < 355.0f && turn > 185.0f) 
		{
			transform.Rotate(0, 0.5f * Time.deltaTime * counterClockwise, 0);
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
