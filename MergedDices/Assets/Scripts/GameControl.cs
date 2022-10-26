using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public bool gameOver = false ;

    public int falseCount;

    public Board[] boards;
    public List<Board> boardss;

    public NewNumber nn;
    public GameObject gameOverPanel;
    public Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        for (int i = 0; i < 24; i++)
        {
            boardss.Add(transform.GetChild(i).GetComponent<Board>());
        }
    }

    private void LateUpdate()
    {
        GameOverr();
    }

    public void GameOverr()
    {
        
        for (int i = 0; i < boardss.Count; i++)
        {
            if (!boardss[i].gameOver)
            {   
                boardss[i].GameControl();
            }
        }

        falseCount = 24;
        for (int i = 0; i < boardss.Count; i++)
        {
            if (boardss[i].gameOver)
            {            
                falseCount --;
            }
        }

        if (falseCount <= 0)
        {
            gameOver = true ;
            //Debug.Log("öldün kanka");
            scoreText.text = nn.point.ToString();
            gameOverPanel.SetActive(true);
        }
    }

    public void RePlay()
    {
        nn.point = 0;
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}