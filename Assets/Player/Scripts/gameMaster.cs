using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour {

    public int score;
    public int highscore = 0;

    public Text pointsText;
    public Text InputText;
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                PlayerPrefs.DeleteKey("Score");
                score = 0;
            }
            else
            {

                score = PlayerPrefs.GetInt("Score");
            }
        }

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = ("Points: " + score);
    }
}
