using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private Vector2 velocity = Vector2.zero;

    public float smoothTime = 0.1f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 destination = target.position + offset;
        Vector2 smoothPosition = Vector2.SmoothDamp(transform.position, destination,ref velocity, smoothTime);
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y, transform.position.z);

    }
}
