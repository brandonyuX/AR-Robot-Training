using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class RobotArmController : MonoBehaviour
{
    CCDIK ccdIK; // Reference to the CCDIK component
    public Vector3 initialPosition = new Vector3(-1, 1, 0); // Initial position for the end effector
    public float moveSpeed = 1.5f; // Speed at which the robot moves towards the target
    private Transform target; // The target for the robot to reach

    void Start()
    {
        ccdIK = GetComponent<CCDIK>();
        if (ccdIK != null)
        {
            // Set initial position for the end effector
            ccdIK.solver.IKPosition = initialPosition;
            ccdIK.solver.Update();
        }
    }

    void LateUpdate()
    {
        if (ccdIK != null && target != null)
        {
            // Calculate the target position with smooth interpolation
            Vector3 targetPosition = target.position;
            Vector3 currentPosition = ccdIK.solver.IKPosition;

            // Smoothly move the IK position towards the target position
            Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * moveSpeed);
            ccdIK.solver.IKPosition = newPosition;

            // Check if the end effector is close enough to the target
            if (Vector3.Distance(ccdIK.solver.IKPosition, targetPosition) < 0.1f)
            {
                // Destroy the target object
                Destroy(target.gameObject);
                target = null; // Clear the target
            }

            // Update the IK solver
            ccdIK.solver.Update();
        }
    }

    // Method to set the target from the ObjectPlacer script
    public void SetTarget(Transform newTarget)
    {
        target = newTarget; // Assign the new target
    }
}