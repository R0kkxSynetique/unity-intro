using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float acceleration = 8f;
    public float deceleration = 10f;
    public float maxSpeed = 50f;
    public float pitchSpeed = 50f;
    public float rollSpeed = 50f;

    [SerializeField]
    private float _speed = 0f;
    private float _pitchInput;
    private float _accelerationInput;
    private float _rollInput;
    private float _yawInput;

    void Update()
    {
        // Get the inputs
        _pitchInput = Input.GetAxis("Pitch");
        _accelerationInput = Input.GetAxis("Acceleration");
        _rollInput = Input.GetAxis("Roll");
        _yawInput = Input.GetAxis("Yaw");

        // Update the speed
        _speed = _accelerationInput switch
        {
            // Acceleration
            > 0 => Mathf.Min(_speed + acceleration * Time.deltaTime, maxSpeed),
            // Deceleration
            < 0 => Mathf.Max(_speed - deceleration * Time.deltaTime, 0),
            // Keep speed
            _ => _speed
        };

        // Apply movements

        // Pitch (up/down)
        transform.Rotate(Vector3.right * Time.deltaTime * pitchSpeed * _pitchInput);
        // Forward
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        // Roll (left/right)
        transform.Rotate(Vector3.forward * Time.deltaTime * rollSpeed * _rollInput);
        // Yaw (turn left/right)
        transform.Rotate(Vector3.up * Time.deltaTime * rollSpeed * _yawInput);
    }
}
