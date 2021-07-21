using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    private Move move;
    private MouseLook look;
    private AudioSource music;
    private GameObject points;
    private GameObject menu;
    private GameObject timer;
    private GameObject end;
    public bool play = false;

    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.Find("Character").GetComponent<Move>();
        look = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        music = GameObject.Find("music").GetComponent<AudioSource>();
        points = GameObject.Find("Points");
        menu = GameObject.Find("Start Menu");
        timer = GameObject.Find("Timer");
        end = GameObject.Find("EndScreen");

        points.SetActive(false);
        timer.SetActive(false);
        end.transform.GetChild(0).gameObject.SetActive(false);
        end.transform.GetChild(1).gameObject.SetActive(false);
        end.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void StartGame()
    {
       move.enabled = true;
       look.enabled = true;
       points.SetActive(true);
       menu.SetActive(false);
       timer.SetActive(true);
       music.Play();
       play = true;
    }

    public bool IsPlaying()
    {
        return play;
    }

    public void RestartGame()
    {
        end.transform.GetChild(0).gameObject.SetActive(false);
        end.transform.GetChild(1).gameObject.SetActive(false);
        end.transform.GetChild(2).gameObject.SetActive(false);

        GameObject.Find("Vomi").GetComponent<ParticleSystem>().Stop();
        GameObject.Find("music").GetComponent<AudioSource>().pitch = 1;
        GameObject.Find("Score").GetComponent<GestionScore>().ResetScore();
        GameObject.Find("Main Camera").GetComponent<GetDrunk>().GetSober();
        GameObject.Find("Main Camera").GetComponent<GetDrunk>().enabled = true;
        GameObject.Find("Character").GetComponent<NewGeneration>().ResetBottles();

        timer.GetComponent<Timer>().ResetTimer();

        StartGame();
    }
}
