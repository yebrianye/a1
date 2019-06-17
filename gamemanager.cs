using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    bool isGameEnd = false;

    public int score;
    int result;
    public Text scoreText;
    public Text timeText;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "gameplay")
            score = 0;

    }
    public void EndGame()
    {
        if (isGameEnd  == false)
        {
            isGameEnd = true;
            Invoke("loadgameoverscene", 2f);
        }
    }

    public void Winning()
    {
        if (isGameEnd == false)
        {
            isGameEnd = true;
            Invoke("loadwinningscene", 2f);
        }
    }
    void loadgameoverscene()
    {
        SceneManager.LoadScene("gameover");
    }

    void loadwinningscene()
    {
        SceneManager.LoadScene("wining");
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "startmenue")
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("gameplay");
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
        if (scene.name == "gameover")
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene("startmenue");
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("gameplay");
        }

        if (scene.name == "wining")
        {
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene("startmenue");
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("gameplay");

        }

        print(score);
        result = score;
        scoreText.text = score.ToString();
        float t = Time.time - startTime;
        timeText.text = t.ToString("0");
    }

    void addscore()
    {
        score = score + 10;
    }
    void addbossscore()
    {
        score = score + 100;
    }
}
