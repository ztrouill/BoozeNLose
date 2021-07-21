using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    private ParticleSystem vomi;
    private AudioSource music;
    private AudioSource[] endSong;
    private MouseLook mouse;
    private Move move;
    private GestionScore score;
    private Camera cam;
    private GameObject endScreen;
    private GameObject gameOn;
    private GetDrunk drunk;

    // Start is called before the first frame update
    void Start()
    {
        vomi = GameObject.Find("Vomi").GetComponent<ParticleSystem>();
        cam = Camera.main;
        music = GameObject.Find("music").GetComponent<AudioSource>();
        endSong = GameObject.Find("end").GetComponents<AudioSource>();
        mouse = cam.GetComponent<MouseLook>();
        move = GameObject.Find("Character").GetComponent<Move>();
        score = GameObject.Find("Score").GetComponent<GestionScore>();
        endScreen = GameObject.Find("EndScreen");
        gameOn = GameObject.Find("GameOn");
        drunk = GameObject.Find("Main Camera").GetComponent<GetDrunk>();
    }

    private void Win()
    {
        DisableGame();
        endScreen.transform.GetChild(1).gameObject.SetActive(true);
        endSong[1].Play();
        Invoke("LetsVomit", 4f);
    }

    private void Loose()
    {
        DisableGame();
        endScreen.transform.GetChild(0).gameObject.SetActive(true);
        endSong[0].Play();
    }

    private void LetsVomit()
    {
        cam.transform.localRotation = Quaternion.Euler(40, 0, 0);
        vomi.Play();
    }

    private void DisableGame()
    {
        music.Stop();
        mouse.enabled = false;
        move.enabled = false;
        gameOn.transform.GetChild(0).gameObject.SetActive(false);
        gameOn.transform.GetChild(1).gameObject.SetActive(false);
        drunk.enabled = false;
    }

    public void EndScreen()
    {
        if (score.GetScore() >= 8)
            Win();
        else
            Loose();
        Invoke("WaitForIt", 4.5f); // Bloque le bouton pour éviter de relancer le jeu alors que l'animation de fin joue
    }

    private void WaitForIt()
    {
        endScreen.transform.GetChild(2).gameObject.SetActive(true);
    }
}
