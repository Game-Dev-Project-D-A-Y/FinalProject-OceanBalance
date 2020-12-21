using System.Collections;
using UnityEngine;

/**
 * This component moves a player controlled with a CharacterController using the keyboard.
 */
[RequireComponent(typeof (CharacterController))]
public class CharacterKeyBoardMover : MonoBehaviour
{
    [Tooltip("Speed of player keyboard-movement, in meters/second")]
    [SerializeField]
    float _speed = 3.5f;

    [SerializeField]
    float _gravity = 9.81f;

    [SerializeField]
    float angle = 20;

    private CharacterController _cc;

    private Vector3 velocity;

    private float rotationZ;

    private float rotationX;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

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

        rotationZ = Mathf.Clamp(rotationZ, -angle, angle);
        rotationX = Mathf.Clamp(rotationX, -angle, angle);
        transform.localEulerAngles = new Vector3(rotationX, 0, rotationZ);

        transform.Rotate(velocity, Space.Self);
    }
}
