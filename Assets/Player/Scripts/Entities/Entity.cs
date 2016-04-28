using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class Entity : MonoBehaviour {

    public float maxSpeed;
    public float speed;
	public float shotspeed;
	public float damage;
        
    public int curHealth;
    public int maxHealth = 1000;

    private gameMaster gm;

    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            //Die();
        }
    }

    void Die()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            if (PlayerPrefs.GetInt("Highscore") < gm.score)
            {
                PlayerPrefs.SetInt("Highscore", gm.score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Highscore", gm.score);
        }
        SaveScore();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Lose");
    }

   

    void SaveScore()
    {
        PlayerPrefs.SetInt("Score", gm.score);
    }



}
