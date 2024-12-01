using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainView;
    [SerializeField] private GameObject secondView;
    [SerializeField] private GameObject instructionView;

    private void Awake()
    {
        mainView.SetActive(true);
        secondView.SetActive(false);
        instructionView.SetActive(false);
    }

    public void StartClick()
    {
        instructionView.SetActive(true);
        mainView.SetActive(false);
    }

    public void Start2Click()
    {
        SceneManager.LoadScene("SV1");
    }

    public void CreditsClick()
    {
        mainView.SetActive(false);
        secondView.SetActive(true);
    }

    public void ExitClick()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void BackClick()
    {
        mainView.SetActive(true);
        secondView.SetActive(false);
    }
}
