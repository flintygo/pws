using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{

    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform Pickuptarget;
    [Space]
    [SerializeField] private float PickupRange;

    [SerializeField] private float RotateSpeed;
    private Rigidbody CurrentObject;

    private Quaternion CurrentObjectRotationOffset;

    private float rotateValue = 0;

    private Vector3 rotateTorque;

    private bool drop = false;

    private bool rayHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject.angularDrag = 0.05f;
                CurrentObject.velocity.Scale(new Vector3 (0.5f,0.5f,0.5f));
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                CurrentObject.angularDrag = 5f;
            }
        }

        if(!(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E)) && Input.GetKey(KeyCode.Q)){
            rotateValue = -1;
        }
        else if(!(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E)) && Input.GetKey(KeyCode.E)){
            rotateValue = 1;
        }
        else{
            rotateValue = 0;
        }
    }

    void FixedUpdate()
    {
        Ray CameraRay2 = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        rayHit = Physics.Raycast(CameraRay2, out RaycastHit HitInfo, PickupRange);
        if (rayHit && CurrentObject){
            drop = (HitInfo.transform.gameObject.name != CurrentObject.transform.gameObject.name);
        }


        if (CurrentObject)
        {

            Vector3 DirectionToPoint = Pickuptarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;

            rotateTorque = new Vector3 (0, rotateValue*2f, 0);

            CurrentObject.AddTorque(rotateTorque);

            if (DistanceToPoint > 3f || drop){
                CurrentObject.useGravity = true;
                CurrentObject.angularDrag = 0.05f;
                CurrentObject = null;
            }
        }
    }
}
