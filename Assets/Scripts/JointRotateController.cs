using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointRotateController : MonoBehaviour
{
    public float speed = 1f;
    public GameObject baseJoint;
    public GameObject shoulderJoint;
    public GameObject elbowJoint;
    public GameObject wrist1Joint;
    public GameObject wrist2Joint;
    public GameObject wrist3Joint;
    public Slider baseSlider;
    public Slider shoulderSlider;
    public Slider elbowSlider;
    public Slider wrist1Slider;
    public Slider wrist2Slider;
    public Slider wrist3Slider;
 
    // Start is called before the first frame update
    void Start()
    {
        baseSlider.onValueChanged.AddListener(delegate { RotateJoint(baseSlider, baseJoint); });
        shoulderSlider.onValueChanged.AddListener(delegate { RotateJoint(shoulderSlider,shoulderJoint); });
        elbowSlider.onValueChanged.AddListener(delegate { RotateJoint(elbowSlider,elbowJoint); });
        wrist1Slider.onValueChanged.AddListener(delegate { RotateJoint(wrist1Slider,wrist1Joint); });
        wrist2Slider.onValueChanged.AddListener(delegate { RotateJoint(wrist2Slider,wrist2Joint); });
        wrist3Slider.onValueChanged.AddListener(delegate { RotateJoint(wrist3Slider,wrist3Joint); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RotateJoint(Slider slide, GameObject Joint)
    {
        if (slide == baseSlider)
        {
            float sliderValue = slide.value;
            Joint.transform.localRotation = Quaternion.Euler(0,0, sliderValue);
        }
        if (slide == shoulderSlider)
        {
            float sliderValue = slide.value;
            Joint.transform.localRotation = Quaternion.Euler(0, sliderValue, 0);
        }
        if (slide == elbowSlider)
        {
            float sliderValue = slide.value;
            Joint.transform.localRotation = Quaternion.Euler(0, sliderValue, 0);
        }
        if (slide == wrist1Slider)
        {
            float sliderValue = slide.value;
            Joint.transform.localRotation = Quaternion.Euler(sliderValue,0, 0);
        }
        if (slide == wrist2Slider)
        {
            float sliderValue = slide.value;
            Joint.transform.localRotation = Quaternion.Euler(0, sliderValue, 0);
        }
        if (slide == wrist3Slider)
        {
            float sliderValue = slide.value;
            Joint.transform.localRotation = Quaternion.Euler(sliderValue, 0, 0);
        }

    }
}
