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
    private float error = 0.01f;
    private float angleError = 0.1f;

    Vector3 velocity = Vector3.zero;

    void Start()
    {
        pointA.transform.position = transform.position;
		pointA.transform.rotation = transform.rotation;
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
                                                                   smoothTime);

                    if ((transform.position - pointA.transform.position).magnitude <= error &&
                        (Quaternion.Angle(transform.rotation, pointA.transform.rotation) <= angleError))
                    {
                        start_smooth = !start_smooth;
                        switch_cam = !switch_cam;
                        in_room = !in_room;
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
                                                                   smoothTime);

                    if ((transform.position - player.transform.position).magnitude <= error &&
                        (Quaternion.Angle(transform.rotation, player.transform.rotation) <= angleError))
                    {
                        start_smooth = !start_smooth;
                        switch_cam = !switch_cam;
                        in_room = !in_room;
                    }
                }

            }
        }
    }
}
