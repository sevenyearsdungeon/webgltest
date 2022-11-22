using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{

    private float mouseXAmount, mouseYAmount;
    public Transform camTransform;
    float targetFoV = 1;
    Camera cam;
    // Use this for initialization
    void Start()
    {
        cam = camTransform.GetComponent<Camera>();
        targetFoV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 0.1f);

        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -0.1f);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0.05f, 0);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -0.05f, 0);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(0.05f, 0, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(-0.05f, 0, 0);

        }

        if (Input.GetKey(KeyCode.Z))
        {
            this.camTransform.Rotate(-0.05f, 0, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            this.camTransform.Rotate(0.05f, 0, 0);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.camTransform.Rotate(0, -0.05f, 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            this.camTransform.Rotate(0, 0.05f, 0);

        }

        if (Input.mouseScrollDelta.y != 0)
            targetFoV = Mathf.Clamp(targetFoV * ((-Mathf.Sign(Input.mouseScrollDelta.y) > 0) ? 1.05f : 0.95f), 5, 90);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFoV, 0.05f);
    }
}
