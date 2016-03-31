using UnityEngine;
using System.Collections;

public class Interpolate : MonoBehaviour
{

    public GameObject player;
    public GameObject pointA;
    public float speed;
    public float smoothTime;
    public bool in_room = true;
    public bool switch_cam;
    bool start_smooth;
    public float error;

    Vector3 velocity = Vector3.zero;

    void Start()
    {
        pointA.transform.position = transform.position;
    }

    void Update()
    {
        if (switch_cam)
        {
            if (!in_room)
            {
                start_smooth = true;
                if (start_smooth)
                {
                    transform.position = Vector3.SmoothDamp(transform.position,
                                                            pointA.transform.position,
                                                            ref velocity,
                                                            smoothTime);
                    transform.rotation = Quaternion.SlerpUnclamped(transform.rotation,
                                                                   pointA.transform.rotation,
                                                                   Time.deltaTime * speed);
                    if ((transform.position - pointA.transform.position).magnitude <= error)
                    {
                        start_smooth = !start_smooth;
                        in_room = !in_room;
                        switch_cam = !switch_cam;
                    }
                }
            }
            else
            {
                start_smooth = true;
                if (start_smooth)
                {
                    transform.position = Vector3.SmoothDamp(transform.position,
                                                            player.transform.position,
                                                            ref velocity,
                                                            smoothTime);
                    transform.rotation = Quaternion.SlerpUnclamped(transform.rotation,
                                                                   player.transform.rotation,
                                                                   Time.deltaTime * speed);

                    if ((transform.position - player.transform.position).magnitude <= error)
                    {
                        start_smooth = !start_smooth;
                        in_room = !in_room;
                        switch_cam = !switch_cam;
                    }
                }
            }
        }
    }
}
