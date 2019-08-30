using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance = null;
        private void Awake()
        {
        
        }
    #endregion

    public Text scoreText;

    public void Update(int score)
    {
        //change the score text to updated value
        scoreText.text = "Score: " + score.ToString();
    }
}
