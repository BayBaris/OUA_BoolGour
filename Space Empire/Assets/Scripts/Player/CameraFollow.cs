using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed;
    public float yOffset;
    public float xOffset;
    public Transform target;

    private void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x + xOffset ,target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime); 
    }
}
