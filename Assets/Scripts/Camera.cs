using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private Transform player;
    private float cameraVerticalClamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        cameraVerticalClamp -= inputY;
        cameraVerticalClamp = Mathf.Clamp(cameraVerticalClamp, -90, 90);
        transform.localEulerAngles = Vector3.right * cameraVerticalClamp;
        
        player.Rotate(Vector3.up * inputX);
    }
}
