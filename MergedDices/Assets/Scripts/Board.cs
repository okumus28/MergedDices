using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public int number = -1;
    public Sprite[] numberSprites;
    public Sprite sprite;
    public Board[] neighbors;
    public List<Board> joints;
    public bool gameOver = false;

    private void Start()
    {
        //GameControl();
    }

    private void Update() 
    {
        Destroy();
    }

    public void Control()
    {
        joints.Add(this);
        for (int i = 0; i < neighbors.Length; i++)
        {
            if (this.number == neighbors[i].number)
            {
                if (!this.joints.SequenceEqual(neighbors[i].joints))
                {   
                    for (int j = 0; j < neighbors[i].joints.Count; j++)
                    {
                        this.joints.Add(neighbors[i].joints[j]);
                    }
                    
                    for (int k = 1; k < joints.Count; k++)
                    {                    
                        //joints[k].joints = this.joints;
                        if (joints[k].joints != this.joints)
                        {
                            joints[k].joints.Clear();
                            for (int m = 0; m < this.joints.Count; m++)
                            {
                                joints[k].joints.Add(this.joints[m]);
                            }
                        }
                    }             
                }          
            }
        }
    }
    public void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = numberSprites[number-1];
        gameOver = true;
    }

    public void ResetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        gameOver = false ;
        //GameObject.FindObjectOfType<GameControl>().GameOverr();
    }        

    public void Destroy() 
    {        
        if (this.joints.Count >= this.number && number != -1)
        {
            ResetSprite();
            GameObject.Find("NextNumber").GetComponent<NewNumber>().Point(number);
            number = -1 ;
            joints.Clear();
        }
    }

    public void GameControl()
    {
        for (int i = 0; i < neighbors.Length; i++)
        {
            if (neighbors[i].number < 0)
            {
                gameOver = false;
                return;
            }
            else
            {
                gameOver = true;
            }
        }
    }
}
