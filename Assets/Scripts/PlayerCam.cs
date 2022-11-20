using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float sensitivity = 2;   // чувствительность
    public float zoom = 0.25f;      // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10;      // макс. увеличение
    public float zoomMin = 3;       // мин. увеличение
    private float Y;                // поворот относительно объекта

    void Start()
    {
        offset = new Vector3(offset.x, offset.y + 1, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
    }

    void LateUpdate()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

        if (Input.GetKey(KeyCode.LeftArrow))
            Y = transform.localEulerAngles.y - sensitivity;
        if (Input.GetKey(KeyCode.RightArrow))
            Y = transform.localEulerAngles.y + sensitivity;

        transform.localEulerAngles = new Vector3(30.0f, Y, 0);
        transform.position = transform.localRotation * offset + target.position;
    }
}
