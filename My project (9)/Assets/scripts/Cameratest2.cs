using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameratest2 : MonoBehaviour
{
    public float sensitivity = 100f;
    public float smoothing = 2f;

    private Vector2 mouseLook;
    private Vector2 smoothV;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        mouseLook += new Vector2(mouseX, -mouseY) * sensitivity * Time.deltaTime;
        smoothV.x = Mathf.Lerp(smoothV.x, mouseLook.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseLook.y, 1f / smoothing);
        mouseLook = smoothV;

        transform.localRotation = Quaternion.AngleAxis(mouseLook.x, transform.up);
        transform.localRotation *= Quaternion.AngleAxis(mouseLook.y, Vector3.right);
    }
}

