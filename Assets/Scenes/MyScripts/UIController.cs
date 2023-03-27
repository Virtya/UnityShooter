using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel1;
    [SerializeField] private SettingsPopup settingsPopup;

    void Start()
    {
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel1.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }
}
