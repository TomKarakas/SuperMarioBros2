using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float minXClamp = -8.54f;
    public float maxXClamp = 50.24f;
    public float minYClamp = -3.88f;
    public float maxYClamp = 20.14f;


    void LateUpdate()
    {
        if (player)
        {
            Vector3 cameraTransform;

            cameraTransform = player.transform.position;
            cameraTransform = new Vector3(Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp), Mathf.Clamp(cameraTransform.y, minYClamp, maxYClamp), transform.position.z);

            transform.position = cameraTransform;
        }
    }
}
