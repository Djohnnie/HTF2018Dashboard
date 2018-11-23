using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotate : MonoBehaviour
{

    private Vector3[] _challengeAngles = new Vector3[]
    {
        new Vector3(290, 45, -40),
        new Vector3(-1, 74, -37)
    };
    private int _currentChallengeAngle = 0;

    public float RotationSpeed = 10;
    private bool _leftDragging = false;
    private bool _rightDragging = false;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _currentChallengeAngle++;
            transform.eulerAngles = _challengeAngles[_currentChallengeAngle % 2];
        }

        if (Input.GetMouseButtonDown(0))
        {
            _leftDragging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _leftDragging = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _rightDragging = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _rightDragging = false;
        }

        if (_leftDragging)
        {
            float rotateX = Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Deg2Rad;
            float rotateY = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, rotateX);
            transform.RotateAround(Vector3.right, rotateY);
        }

        if (_rightDragging)
        {
            float rotateX = Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Deg2Rad;
            float rotateY = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.forward, -rotateX);
            //transform.RotateAround(Vector3.left, rotateY);
        }
    }
}