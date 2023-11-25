using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TruckDurability _truckDurability;
    [SerializeField] private FuelTank _fuelTank;

    private CanvasGroup _canvasGroup;
    private TMP_Text _text;
    private string _endReason;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _text = GetComponentInChildren<GameOverText>().GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _truckDurability.TruckCrashed += OnTruckCrashed;
        _fuelTank.OutOfFuel += OnOutOfFuel;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _truckDurability.TruckCrashed -= OnTruckCrashed;
        _fuelTank.OutOfFuel -= OnOutOfFuel;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void OnTruckCrashed()
    {
        _endReason = "crashed";
        PrepareScreenUI();
        ShowScreen();
    }

    private void OnOutOfFuel()
    {
        _endReason = "out of fuel";
        PrepareScreenUI();
        ShowScreen();
    }

    private void ShowScreen()
    {
        float maxAlphaCanalValue = 1;
        _text.text = $"You are {_endReason}\r\nYour time: {Time.timeSinceLevelLoad: 0.00} seconds\r\nDo you wanna try again?";
        _canvasGroup.alpha = maxAlphaCanalValue;
    }

    private void PrepareScreenUI()
    {
        Time.timeScale = 0;
        _restartButton.interactable = true;
        _exitButton.interactable = true;
    }

    private void OnRestartButtonClick()
    {
        float realTimeScaleValue = 1;
        Time.timeScale = realTimeScaleValue;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
