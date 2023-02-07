using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstructionsButtonClick : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        panel.SetActive(false);
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        panel.SetActive(true);
    }
}
