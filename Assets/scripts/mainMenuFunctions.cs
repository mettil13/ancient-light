using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuFunctions : MonoBehaviour
{
    public GameObject volumeSlider;
    public GameObject fpsLimitDropdown;

    private void Start() {
        volumeSlider.GetComponent<Slider>().value = (int) (AudioListener.volume * 100);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 200;
    }

    public void startGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void startCreditsScene() {
        SceneManager.LoadScene("Credits");
    }

    public void quitGame() {
        Application.Quit();
    }

    public void setVolume() {
        float volume = volumeSlider.GetComponent<Slider>().value;
        // volume is in a 0 - 100 scale, while AudioListener.volume is in a 0 - 1 scale, so we need to convert it
        if(volume != 0) {
            volume = volume / 100;
        }
        AudioListener.volume = volume;
    }

    public void setFpsLimit() {
        int index = fpsLimitDropdown.GetComponent<TMPro.TMP_Dropdown>().value;
        int value = 30;
        switch (index) {
            case 0:
                value = 200;
                break;
            case 1:
                value = 120;
                break;
            case 2:
                value = 60;
                break;
            case 3:
                value = 30;
                break;
        }

        Application.targetFrameRate = value;
    }
}
