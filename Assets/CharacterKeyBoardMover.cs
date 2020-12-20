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
    [SerializeField] float angle = 20;
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
        Vector3 localRot;
       // Click Up: velocity = (0,0,1);
       if((transform.localEulerAngles.x >=angle && transform.localEulerAngles.x <=(2*angle)) && 
          (transform.localEulerAngles.z >= angle && transform.localEulerAngles.z <= (2*angle))){
                               transform.localEulerAngles = new Vector3(angle,0,angle);
                               //Debug.Log("1");
       }
       if( (transform.localEulerAngles.x <= eulerAngleMax-angle && transform.localEulerAngles.x >= eulerAngleMax-(2*angle)) &&
          (transform.localEulerAngles.z <= eulerAngleMax-angle && transform.localEulerAngles.z >= eulerAngleMax-(2*angle))){
                transform.localEulerAngles = new Vector3(eulerAngleMax-angle,0, eulerAngleMax-angle);
                                               //Debug.Log("2");

       }
       if(transform.localEulerAngles.x >=angle && transform.localEulerAngles.x <=(2*angle)){
                    transform.localEulerAngles = new Vector3(angle,0,transform.localEulerAngles.z);
                                                                  // Debug.Log("3");

       }
        if(transform.localEulerAngles.x <= eulerAngleMax-angle && transform.localEulerAngles.x >=eulerAngleMax-(2*angle) ){
                    transform.localEulerAngles = new Vector3(eulerAngleMax-angle,0,transform.localEulerAngles.z);
                                                                                    // Debug.Log("4");
  
       }
        if(transform.localEulerAngles.z > angle && transform.localEulerAngles.z <= (2*angle)){
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,0,angle);
                                                                                       Debug.Log("5");

       }
        if(transform.localEulerAngles.z <=eulerAngleMax-angle && transform.localEulerAngles.z >= eulerAngleMax-(2*angle)){
                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,0,eulerAngleMax-angle);
                                                                                     //  Debug.Log("6");

       }

        transform.Rotate(velocity , Space.Self);

      
    }
}

