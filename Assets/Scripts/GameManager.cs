using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public int score = 0; //ScoreKeeping

    public void AddScore(int scoreToAdd)
    {
        //Increases Score Value by incoming score
        score += scoreToAdd;
        //Update UI Here
    }

    //Reloads Current Level
    public void Restart()
    {
        //Loads Active Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        //Loads the Next Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PrevLevel()
    {
        //Loads Previous Level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
