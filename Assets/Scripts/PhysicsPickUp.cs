using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickUp : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;
    private bool isHoldingObject = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isHoldingObject)
            {
                DropObject();
            }
            else
            {
                PickUpObject();
            }
        }
    }

    void PickUpObject()
    {
        Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
        {
            CurrentObject = HitInfo.rigidbody;
            if (CurrentObject != null)
            {
                CurrentObject.useGravity = false;
                isHoldingObject = true;
            }
        }
    }

    void DropObject()
    {
        if (CurrentObject != null)
        {
            CurrentObject.useGravity = true;
            CurrentObject = null;
            isHoldingObject = false;
        }
    }


/* 
    void FixedUpdate()
    {
        if(CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;
            CurrentObject.velocity = DirectionToPoint * numeroMultiplica * DistanceToPoint;
        }
    } */
}