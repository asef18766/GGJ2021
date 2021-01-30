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

    public IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(originalPos.x+x, originalPos.y+y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;

    }
}
