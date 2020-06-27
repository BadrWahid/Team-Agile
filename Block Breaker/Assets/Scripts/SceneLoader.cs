using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneLoader : MonoBehaviour {

    int numLevel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;

    
	public void LoadNextScene()
    {
        numLevel = PlayerPrefs.GetInt("Num_Lev");   
        SceneManager.LoadScene(numLevel+1);
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(numLevel);
        //FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static int ActualLevel(){
        return PlayerPrefs.GetInt("Num_Lev");
    }

    public static int ActualScore(){
        return PlayerPrefs.GetInt("my_score");
    }
    public void Start()
    {
        scoreText.text = "Score: "+PlayerPrefs.GetInt("my_score").ToString(); 
        levelText.text = "Level: "+(PlayerPrefs.GetInt("Num_Lev")+1).ToString();
    }
    public void LoadNewGame()
    {
        PlayerPrefs.SetInt("Num_Lev",0);
        PlayerPrefs.SetInt("my_score",0);
        SceneManager.LoadScene(1);
    }
}
