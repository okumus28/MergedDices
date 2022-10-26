using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int dicesChangeCount;
    public int point;
    public int nextGiftPoint;

    public Text dicesChangeCountText;

    public NewNumber newNumber;

    // Start is called before the first frame update
    void Start()
    {
        point = newNumber.point;
        UpdateChangeText();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.point >= nextGiftPoint)
        {
            dicesChangeCount++;
            UpdateChangeText();
            nextGiftPoint *= 2;
        }
    }

    public void UpdateChangeText()
    {
        dicesChangeCountText.text = dicesChangeCount.ToString();
    }

    public void DicesChangeButton()
    {
        if (dicesChangeCount > 0)
        {
            newNumber.first.NewNumber();
            newNumber.second.NewNumber();
            newNumber.transform.localEulerAngles = new Vector3(0,0,0);
            dicesChangeCount--;
            UpdateChangeText();
        }
    }
}
