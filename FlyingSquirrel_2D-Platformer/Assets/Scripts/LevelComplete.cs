using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelComplete : MonoBehaviour
{
    public Text acornsText;    
    public Text secondsText;

    public void Setup(int score, int time) {
        gameObject.SetActive(true);
        acornsText.text = score.ToString() + " Acorns";
        secondsText.text = time.ToString() + " Acorns";
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game 1");
    }

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
