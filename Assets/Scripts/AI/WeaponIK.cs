using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIK : MonoBehaviour
{
    PlayerInZone playerInZone;
    bool inRange;

    public Transform targetTransform;
    public Transform aimTransform;
    public Transform bone;

    public int iterations = 10;
    [Range(0,1)]
    public float weight = 1.0f;
    private float angleLimit = 180.0f;
    public float distanceLimit = 1.5f;
    
    void Awake()
    {
        playerInZone = GameObject.FindGameObjectWithTag("Enemy Collider").GetComponent<PlayerInZone>();

        inRange = playerInZone.playerInArea;
    }

    void Update()
    {
        inRange = playerInZone.playerInArea;
    }

    Vector3 GetTargetPosition()
    {
        Vector3 targetDirection = targetTransform.position - aimTransform.position;
        Vector3 aimDirection = aimTransform.forward;
        float blendOut = 0.0f;
        float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        if (targetAngle > angleLimit)
        {
            blendOut += (targetAngle = angleLimit) / 50.0f;
        }
        float targetDistance = targetDirection.magnitude;
        
        if(targetDistance < distanceLimit)
        {
            blendOut += distanceLimit - targetDistance;
        }
        if (inRange == false)
        {
            blendOut += distanceLimit - targetDistance;
        }
        
        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        return aimTransform.position + direction;
    }

    
    void LateUpdate()
    {
        if (aimTransform == null)
        {
            return;
        }
        if (targetTransform == null)
        {
            return;
        }
        Vector3 targetPosition = GetTargetPosition();
        for (int i = 0; i < iterations; i++)
        {
            AimAtTarget(bone, targetPosition, weight);
        }
    }
    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight)
    {
        if (inRange == true)
        {
            Vector3 aimDirection = aimTransform.forward;
            Vector3 targetDirection = targetPosition - aimTransform.position;
            Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
            Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
            bone.rotation = blendedRotation * bone.rotation;
        }
        
    }

    public void SetTargetTransform(Transform target)
    {
        targetTransform = target;
    }
    public void SetAimTransform(Transform aim)
    {
        aimTransform = aim;
    }

    
    
}
