using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
<<<<<<< Updated upstream
    private int ScoreNum;
=======

    private int ScoreNum;

>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score: " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "Coin")
        {
            ScoreNum++;
            Destroy(Coin.gameObject);
            MyscoreText.text = "Score: " + ScoreNum;
        }
    }

}