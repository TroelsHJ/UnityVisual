using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public float MovementSpeed = 25f;
    public CinemachineFreeLook freeLookCamera;


    private void FixedUpdate()
    {
        float movementY = Input.GetAxis("Vertical");
        transform.Translate(0, movementY * Time.fixedDeltaTime * MovementSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X";
            freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y";
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            freeLookCamera.m_XAxis.m_InputAxisName = "";
            freeLookCamera.m_YAxis.m_InputAxisName = "";
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            freeLookCamera.m_Lens.FieldOfView++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            freeLookCamera.m_Lens.FieldOfView--;
        }

    }
}
