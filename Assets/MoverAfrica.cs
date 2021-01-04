using System.Collections;
using UnityEngine;

/**
 * This component moves the surface with keyboard
 */
public class MoverAfrica : MonoBehaviour
{
    [Tooltip("Speed of player keyboard-movement, in meters/second")]
    [SerializeField]
    float _speed = 3.5f;

    [Tooltip("Angle the surface can reach, in degrees")]
    [Range(-90, 90)]
    [SerializeField]
    float angle = 20;

    // Vector the holds the velocity of the surface
    private Vector3 velocity;

    // holds the z degrees after converting from euler angels
    private float rotationZ  ;

    // holds the x degrees after converting from euler angels
    private float rotationX ;

    // Method that converts euler angles to degrees
    private float EulerToDegrees(float input)
    {
        while (input > 360)
        {
            input = input - 360;
        }
        while (input < -360)
        {
            input = input + 360;
        }
        if (input > 180)
        {
            input = input - 360;
        }
        if (input < -180) input = 360 + input;
        return input;
    }

    void Update()
    {
        float x = Input.GetAxis("Vertical");
        float z = -Input.GetAxis("Horizontal");

        velocity.x = x * _speed;
        velocity.z = z * _speed;

        rotationZ = EulerToDegrees(transform.localEulerAngles.z);
        rotationX = EulerToDegrees(transform.localEulerAngles.x);

        Debug.Log("x:"+ transform.localEulerAngles.x);
        // The surface wont pass the given angle
        rotationZ = Mathf.Clamp(rotationZ, -angle, angle);
        rotationX = Mathf.Clamp(rotationX, -angle, angle);
        transform.localEulerAngles = new Vector3(rotationX, 0, rotationZ);

        transform.Rotate(velocity, Space.Self);
    }
}




