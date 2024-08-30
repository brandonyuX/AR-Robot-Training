using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectPlacer : MonoBehaviour
{
    public GameObject objectToPlace; // The object to place in AR
    public Camera arCamera; // AR camera

    public Button placeObjectButton;
    public Button doneButton;

    public GameObject tableModel; // Reference to the 3D table model
    public GameObject reticlePrefab; // Prefab for the visual reticle

    bool isPlacingObject = false;
    GameObject currentReticle;

    RobotArmController robotArmController; // Reference to the robot arm controller script

    private void Start()
    {
        robotArmController = GetComponent<RobotArmController>();
        
        if (placeObjectButton != null)
            placeObjectButton.onClick.AddListener(StartPlacingObject);

        if (doneButton != null)
        {
            doneButton.onClick.AddListener(FinishPlacingObject);
            doneButton.gameObject.SetActive(false);
        }

        currentReticle = Instantiate(reticlePrefab);
        currentReticle.SetActive(false);
    }
    void Update()
    {
        if (isPlacingObject)
        {
            UpdateReticlePosition();

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                PlaceObject();
            }
        }
    }

    void PlaceObject()
    {
        if (currentReticle.activeSelf)
        {
            GameObject placedObject = Instantiate(objectToPlace, currentReticle.transform.position, Quaternion.identity);

            if (robotArmController != null)
            {
                robotArmController.SetTarget(placedObject.transform);
            }
        }
    }

    void UpdateReticlePosition()
    {
        Ray ray = arCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == tableModel)
        {
            currentReticle.SetActive(true);
            currentReticle.transform.position = hit.point;
            currentReticle.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        else
        {
            currentReticle.SetActive(false);
        }
    }
    
    void PlaceObjectAtTouch(Vector2 touchPosition)
    {
        Ray ray = arCamera.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Instantiate the object at the hit point
            GameObject placedObject = Instantiate(objectToPlace, hit.point, Quaternion.identity);

            // Update the robot arm controller with the new target
            if (robotArmController != null)
            {
                robotArmController.SetTarget(placedObject.transform);
            }
        }
    }

    void StartPlacingObject()
    {
        isPlacingObject = true;
        if (placeObjectButton != null)
            placeObjectButton.gameObject.SetActive(false);
        if (doneButton != null)
            doneButton.gameObject.SetActive(true);

        currentReticle.SetActive(true);
    }

    void FinishPlacingObject()
    {
        isPlacingObject = false;
        if (placeObjectButton != null)
            placeObjectButton.gameObject.SetActive(true);
        if (doneButton != null)
            doneButton.gameObject.SetActive(false);

        currentReticle.SetActive(false);
    }
}
