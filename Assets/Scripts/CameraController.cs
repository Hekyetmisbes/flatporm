/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Control camera position
    public Transform target;
    public float smoothing = 5f;
    public float minX = 0f;
    public float maxX = 135f;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        targetCamPos.x = Mathf.Clamp(targetCamPos.x, minX, maxX); // Limit x value
        targetCamPos.y = transform.position.y; // Keep y value unchanged

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Control camera position
    public Transform target;
    public float smoothing = 5f;
    public float minX = 0f;
    public float maxX = 135f;
    public float minY = 0f;
    public float maxY = 22f;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        targetCamPos.x = Mathf.Clamp(targetCamPos.x, minX, maxX); // Limit x value
        float lastY = 0f;

        if(target.transform.position.y < 9)
        {
            targetCamPos.y = lastY;
        }
        else
        {
            targetCamPos.y = Mathf.Clamp(targetCamPos.y, minX, 22f);
            targetCamPos.x = target.position.x;
        }

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
