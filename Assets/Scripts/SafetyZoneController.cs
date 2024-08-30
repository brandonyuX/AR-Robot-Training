using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafetyZoneController : MonoBehaviour
{
    public Button showZonebutton;
    public Button hideZonebutton;
    public GameObject zone;
    // Start is called before the first frame update
    void Start()
    {
        
        zone.SetActive(false);
        if (showZonebutton != null)
            showZonebutton.onClick.AddListener(ShowZone);

        if (hideZonebutton != null)
        {
            hideZonebutton.onClick.AddListener(HideZone);
            hideZonebutton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ShowZone()
    {
        zone.SetActive(true);
        showZonebutton.gameObject.SetActive(false);
        hideZonebutton.gameObject.SetActive(true);
    }

    void HideZone()
    {
        zone.SetActive(false);
        showZonebutton.gameObject.SetActive(true);
        hideZonebutton.gameObject.SetActive(false);
    }
}
