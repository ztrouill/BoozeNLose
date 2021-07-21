using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCollision : MonoBehaviour
{
    private GestionScore score;
    private SoundEffect s_bottle;
    private SoundEffect s_err;
    private StartMenu play;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<GestionScore>();
        s_bottle = GameObject.Find("bottle").GetComponent<SoundEffect>();
        s_err = GameObject.Find("error").GetComponent<SoundEffect>();
        play = GameObject.Find("Play").GetComponent<StartMenu>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!play.IsPlaying())
            return;

        if (collision.transform.CompareTag("Alcohol") || collision.transform.CompareTag("Soft"))
        {
            Destroy(collision.gameObject);
            if (collision.transform.CompareTag("Alcohol"))
                DrinkAlcohol();
            if (collision.transform.CompareTag("Soft"))
                if (score.GetScore() > 0)
                    DrinkSoft();
            score.changeEmojiState();
        }
        if (collision.transform.CompareTag("CloudsToy"))
            s_err.PlaySound(0);
    }

    private void DrinkAlcohol()
    {
        score.IncrementScore();
        s_bottle.PlaySound(1);
    }

    private void DrinkSoft()
    {
        score.DecrementScore();
        s_bottle.PlaySound(0);
    }
}