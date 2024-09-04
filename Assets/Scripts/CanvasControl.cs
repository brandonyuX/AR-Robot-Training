using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RootMotion.FinalIK;

public class CanvasControl : MonoBehaviour
{
    public GameObject panel;
    public Button jogButton;
    public Button ikButton;
    public Button placeButton;
    public Button doneButton;
    CCDIK ccdIK;
    char modeFlag;
    // Start is called before the first frame update
    void Start()
    {
        ccdIK = GetComponent<CCDIK>();
        modeFlag = 'J';
        jogButton.onClick.AddListener(jogBtnPressed);
        ikButton.onClick.AddListener(ikBtnPressed);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void jogBtnPressed()
    {
        modeFlag = 'J';
        ccdIK.enabled = false;
        panel.SetActive(true);

    }
    void ikBtnPressed()
    {
        modeFlag = 'I';
        ccdIK.enabled = true;
        panel.SetActive(false);

    }
}
