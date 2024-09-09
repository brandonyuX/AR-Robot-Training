using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionWarning : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
        Debug.Log("Collision Detected");
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        Debug.Log("Collision Clear");
    }
  
}
