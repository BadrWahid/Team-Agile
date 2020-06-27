using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    // config params
    float gameSpeed = 0.4f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;


    // state variables
    [SerializeField] int currentScore = 0;

    int numLevel = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //GameObject.Find ("Play Space").SetActive (false);
        if (PlayerPrefs.GetInt("my_score") != null)
        {
            //Debug.Log(currentScore);
            currentScore = PlayerPrefs.GetInt("my_score");
            scoreText.text = PlayerPrefs.GetInt("my_score").ToString();   
        }else{
            scoreText.text = currentScore.ToString(); 
        }
        //Debug.Log(PlayerPrefs.GetInt("num_Level"));
    }

    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.GetInt("Num_Lev") != null)
        {
         numLevel = PlayerPrefs.GetInt("Num_Lev");   
        }
        numLevel = numLevel /5;
        Time.timeScale = gameSpeed+gameSpeed*numLevel;
	}

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
        PlayerPrefs.SetInt("my_score",currentScore);
    }

    /*public void ResetGame()
    {
        Destroy(gameObject);
    }*/
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
