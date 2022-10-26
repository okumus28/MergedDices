using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewNumber : MonoBehaviour
{
    float zPosition;
    Vector3 offset;
    bool dragging;
    public Next first;
    public Next second;

    public int point;
    public Text pointText;

    public GameControl gc;

    private void Start() {
        point = 0;
        zPosition = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private void Update() {
        if (dragging)
        {
            Vector3 position = new Vector3(Input.mousePosition.x , Input.mousePosition.y , zPosition);
            transform.position = Camera.main.ScreenToWorldPoint(position + new Vector3 (offset.x , offset.y));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.eulerAngles += new Vector3(0,0,-90);
        }
    }
    
#region DragDrop
    void OnMouseDown() {
        if (!dragging)
        {
            BeginDrag();
        }
    }

    private void OnMouseUp() {
        EndDrag();
    }

    public void BeginDrag()
    {
        dragging = true;
        offset = Camera.main.WorldToScreenPoint(transform.position) - Input.mousePosition;
    }

    public void EndDrag()
    {
        Change();

        dragging = false;
        transform.position = new Vector3(2 , -7f , 0);
        first.trigObject = null;     
        second.trigObject = null;     
    }
#endregion

    public void Change()
    {
        if (first.trigBoard == true && second.trigBoard == true)
        {
            if (first.trigObject.GetComponent<Board>().number <= 0 && second.trigObject.GetComponent<Board>().number <= 0)
            {    
                first.trigObject.GetComponent<Board>().number = first.number;
                first.trigObject.GetComponent<Board>().Control();

                second.trigObject.GetComponent<Board>().number = second.number;
                second.trigObject.GetComponent<Board>().Control();

                first.trigObject.GetComponent<Board>().ChangeSprite();
                second.trigObject.GetComponent<Board>().ChangeSprite();
                
                first.NewNumber();
                second.NewNumber();

                //gc.GameOverr();

                transform.eulerAngles = new Vector3(0,0,0);
            }
            //gc.GameOverr();
        }
        
    }

    public void Point(int a)
    {
        point += a ;
        pointText.text = point.ToString();
    }

    public void Rotate()
    {
        transform.eulerAngles += new Vector3(0,0,-90);
    }
}
