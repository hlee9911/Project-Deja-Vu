using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Vector3 offset = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    public float distance = 10f;
    float currentDistance;
    public float minDistance = 16f;
    public float maxDistance = 20f;
    public float height = 8f;
    public float targetHeadHeight = 7f;
    float smooth = 0.0f;

    public Transform target;
    void Awake()
    {
        offset = new Vector3(target.position.x, (target.position.y + height), (target.position.z - distance));
        transform.position = offset;
    }
    void Update()
    {
        LookAtTarget();
    }
    void LateUpdate()
    {
        UpdatePosition();
    }
    void LookAtTarget()
    {
        Vector3 relativePos = target.position - transform.position;
        Vector3 y = new Vector3(0, targetHeadHeight, 0);
        Quaternion newRotation = Quaternion.LookRotation(relativePos + y);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10f * Time.deltaTime);
    }

    void UpdatePosition()
    {
        currentDistance = Vector3.Distance(transform.position, target.position);
        if (currentDistance < minDistance)
        {
            currentDistance = minDistance;
        }
        else if (currentDistance > maxDistance)
        {
            currentDistance = maxDistance;
        }
        distance = currentDistance;
        offset = new Vector3(target.position.x, (target.position.y + height), (target.position.z - distance));
        transform.position = Vector3.SmoothDamp(transform.position, offset, ref velocity, smooth);
    }
}
