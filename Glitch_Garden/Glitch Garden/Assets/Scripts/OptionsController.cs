using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;
    [SerializeField] Slider _difficultySlider;

    [SerializeField] float _defaultVolume = 0.5f;
    [SerializeField] float _defaultDifficulty = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this._volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        this._difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(this._volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found. Did you start from Splash Screen?");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(this._volumeSlider.value);
        PlayerPrefsController.SetDifficulty(this._difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        this._volumeSlider.value = _defaultVolume;
        this._difficultySlider.value = _defaultDifficulty;
    }
}
