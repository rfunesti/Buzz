using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public float timer = 0f;
    public float timerRate = 1f;

    public Text scoreDisplay;
    public Text highScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "Score: " + score.ToString();
        highScore = PlayerPrefs.GetInt("High Score", 0);
        highScoreDisplay.text = "High Score: " + highScore.ToString();
    }
    void OnDestroy()
    {
        //ResetHighScore(); // use if reset needed for high score

        PlayerPrefs.SetInt("High Score", highScore);
        PlayerPrefs.Save();
    }
    // Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime * timerRate;
    //    if (timer > 1f)
    //    {
    //        score++;
    //        scoreDisplay.text = "Score: " + score.ToString();
    //        timer = 0f;

    //        if (score > highScore)
    //        {
    //            highScore = score;
    //        }
    //    }
    //}
    public void AddPoints(int amount)
    {
        //Debug.Log("in AddPoints method");
        score += amount;
        scoreDisplay.text = "Score: " + score.ToString();

        if (score > highScore)
        {
            highScore = score;
            highScoreDisplay.text = "High Score: " + highScore.ToString();
        }
    }


    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("High Score", 0);
        PlayerPrefs.Save();
        Debug.Log("High Score reset to 0");
    }
}