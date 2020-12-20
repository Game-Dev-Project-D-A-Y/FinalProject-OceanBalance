using System.Collections;
using UnityEngine;


/**
 * This component moves a player controlled with a CharacterController using the keyboard.
 */
[RequireComponent(typeof(CharacterController))]
public class CharacterKeyBoardMover: MonoBehaviour {
    [Tooltip("Speed of player keyboard-movement, in meters/second")]
    [SerializeField] float _speed = 3.5f;
    [SerializeField] float _gravity = 9.81f;
    [SerializeField] float angle = 45f;
     [SerializeField] float eulerAngleMax = 360;


    private CharacterController _cc;
    void Start() {
        _cc = GetComponent<CharacterController>();
    }

    Vector3 velocity;

    void Update()  {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //if (x == 0 && z == 0) return;
        velocity.x = x * _speed;
        velocity.z = z * _speed;
        if (!_cc.isGrounded) {
            velocity.x -= _gravity*Time.deltaTime;
            velocity.z -= _gravity*Time.deltaTime;

        }
        // Click Up: velocity = (0,0,1)
        if(transform.rotation.eulerAngles.x >= angle){
            transform.localRotation = Quaternion.Euler(angle, 0, 0);
;
        }
            Debug.Log("transform.localRotation.x " + transform.localRotation.eulerAngles );
            transform.Rotate(velocity , Space.Self);
        //Debug.Log("velocity="+velocity+" isGrounded="+ _cc.isGrounded);
        _cc.Move(velocity * Time.deltaTime);
      
    }
}

//transform.rotation.eulerAngles.x <= angle || transform.rotation.eulerAngles.x >= eulerAngleMax - angle) && (transform.rotation.eulerAngles.z <= angle || transform.rotation.eulerAngles.z >= eulerAngleMax - angle)