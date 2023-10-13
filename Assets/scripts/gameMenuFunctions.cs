using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameMenuFunctions : MonoBehaviour
{
    public GameObject gameMenu;

    public void closeMenu() {
        gameMenu.SetActive(false);
        Cursor.visible = false;
    }

    public void goToMainMenu() {
        SceneManager.LoadScene("mainMenu");
    }

    public void quitGame() {
        Application.Quit();
    }
}
