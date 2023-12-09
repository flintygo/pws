//Dit script zorgt ervoor dat de speler objecten op kan pakken

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
    [SerializeField] private GameObject NoClick;
    [SerializeField] private GameObject LeftClick;
    public Rigidbody CurrentObject;
    private Quaternion CurrentObjectRotationOffset;
    private float rotateValue = 0;
    private Vector3 rotateTorque;
    private bool drop = false;
    private bool rayHit;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) //Als de speler op de linkermuisknopt klikt
        {
            if (CurrentObject) //Als hij een obejct al heeft, laat hem los
            {
                CurrentObject.useGravity = true;
                CurrentObject.angularDrag = 0.05f;
                CurrentObject.velocity.Scale(new Vector3 (0.5f,0.5f,0.5f));
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //Anders pak je hem op
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                CurrentObject.angularDrag = 5f;
            }
        }

        if(!(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E)) && Input.GetKey(KeyCode.Q)){ //Als je op q klikt, draai je het object tegen de klok in van bovenaf gezien
            rotateValue = -1;
        }
        else if(!(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E)) && Input.GetKey(KeyCode.E)){ //Als je op e klikt, draai je het object met de klok mee van bovenaf gezien
            rotateValue = 1;
        }
        else{ //Als je hem niet draait, dan draait hij niet
            rotateValue = 0;
        }

        Ray CameraRay3 = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        LeftClick.SetActive(Physics.Raycast(CameraRay3, out RaycastHit HitInfo2, PickupRange, PickupMask) || CurrentObject);
        NoClick.SetActive(true);
    }

    void FixedUpdate()
    {
        //Als je naar een ander object kijk terwijl je een object vast hebt, dus een muur bijvoorbeeld, laat je hem los, zodat je niet een object door een muur heen vast kunt blijven houden enz.
        Ray CameraRay2 = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        rayHit = Physics.Raycast(CameraRay2, out RaycastHit HitInfo, PickupRange);
        if (rayHit && CurrentObject){
            drop = (HitInfo.transform.gameObject.name != CurrentObject.transform.gameObject.name && HitInfo.transform.gameObject.name != "Player");
        }


        if (CurrentObject) //Als je een object vast hebt
        {

            //Neem hem mee
            Vector3 DirectionToPoint = Pickuptarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;

            //Draai hem
            rotateTorque = new Vector3 (0, rotateValue*1f, 0);

            CurrentObject.AddTorque(rotateTorque);

            if (DistanceToPoint > 3f || drop){
                CurrentObject.useGravity = true;
                CurrentObject.angularDrag = 0.05f;
                CurrentObject = null;
            }
        }
    }
}
