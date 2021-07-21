using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionScore : MonoBehaviour
{
    private int score = 0;
    private Text scoreTxt;
    private Image stateImg;
    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.Find("Text").GetComponent<Text>();
        stateImg = GameObject.Find("State").GetComponent<Image>();
        rect = GameObject.Find("State").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();
    }

    public int IncrementScore()
    {
        return score++;
    }

    public int DecrementScore()
    {
        return score--;
    }

   public void changeEmojiState()
   {
        if (score <= 8)
            stateImg.sprite = Resources.Load<Sprite>(score.ToString());
           
        if (score == 8)
            rect.localScale = new Vector3(1, 1.2f, 1); // Corrige le dernier sprite qui a une hauteur + grande
   }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        stateImg.sprite = Resources.Load<Sprite>("0");
    }
}
