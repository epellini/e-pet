using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private Image _hungerMeter, _thirstMeter, _cleanlinessMeter, _funMeter, _happinessMeter, _energyMeter; // Declare images
    [SerializeField] private Image _healthStatus;
    [SerializeField] private Sprite _healthySprite;
    [SerializeField] private Sprite _sickSprite;
    [SerializeField] private Sprite deathSprite;
    [SerializeField] private GameObject Pet;
    [SerializeField] private GameObject _gameOverPanel;
    public PetName petName;
    [SerializeField] private TMP_Text _ageText, _stageText, _nameText; // Declare text

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        string petName = PlayerPrefs.GetString("PetName");
        _nameText.text = petName;
        //_pausePanel.SetActive(false);
        //_startPanel.SetActive(true);
        //_winPanel.SetActive(false);
    }
    private void FixedUpdate()
    {
        _hungerMeter.fillAmount = _statsManager.HungerPercent; // Set the fill amount of the image to the hunger percent
        _thirstMeter.fillAmount = _statsManager.ThirstPercent; // Set the fill amount of the image to the thirst percent
        _cleanlinessMeter.fillAmount = _statsManager.CleanlinessPercent; // Set the fill amount of the image to the cleanliness percent
        _funMeter.fillAmount = _statsManager.FunPercent; // Set the fill amount of the image to the fun percent
        _happinessMeter.fillAmount = _statsManager.HappinessPercent; // Set the fill amount of the image to the happiness percent
        _energyMeter.fillAmount = _statsManager.EnergyPercent; // Set the fill amount of the image to the energy percent

        if (_statsManager.CurrentHealthStatus == StatsManager.HealthStatus.Healthy)
        {
            _healthStatus.sprite = _healthySprite;
        }
        else
        {
            _healthStatus.sprite = _sickSprite;
        }

        // Update the age display
        if (_ageText != null && _statsManager != null)
        {
            _ageText.text = _statsManager.GetFormattedAge();
        }

        if (_stageText != null && _statsManager != null)
        {
            _stageText.text = _statsManager.GetFormattedStage();
        }


        if (_nameText != null && _statsManager != null)
        {
            _nameText.text = _statsManager.GetFormattedName();
        }
    }

    // [SerializeField] private GameObject _pausePanel;
    // [SerializeField] private GameObject _gamePanel;
    // [SerializeField] private GameObject _startPanel;
    // [SerializeField] private GameObject _winPanel;

    private void OnEnable()
    {
        StatsManager.OnPlayerDeath += GameOver;
    }

    private void OnDisable()
    {
        StatsManager.OnPlayerDeath -= GameOver;
    }

    public void GameOver()
    {
        SpriteRenderer spriteRenderer = Pet.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = deathSprite;
        _gameOverPanel.SetActive(true);
        //Time.timeScale = 0;
    }

    public void StartGame()
    {
        _gameOverPanel.SetActive(false);
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         Pause();
    //     }
    // }

    // public void Pause()
    // {
    //     _pausePanel.SetActive(true);
    //     _gamePanel.SetActive(false);
    //     Time.timeScale = 0;
    // }

    // public void Resume()
    // {
    //     _pausePanel.SetActive(false);
    //     _gamePanel.SetActive(true);
    //     Time.timeScale = 1;
    // }


    // public void Win()
    // {
    //     _winPanel.SetActive(true);
    //     _gamePanel.SetActive(false);
    //     Time.timeScale = 0;
    // }

    // public void StartGame()
    // {
    //     _startPanel.SetActive(false);
    //     _gamePanel.SetActive(true);
    //     Time.timeScale = 1;
    // }

    // public void Quit()
    // {
    //     Application.Quit();
    // }

}
