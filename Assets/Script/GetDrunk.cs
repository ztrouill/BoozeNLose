using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GetDrunk : MonoBehaviour
{
    private GestionScore score;
    public float min = 55.0f;
    public float max = 75.0f;


    // Booleen pour savoir si on est sur une valeur négative ou pas
    private bool negFov = false;
    private bool negRotate = false;
    private bool negDist = false;

    private float drunk = 0;
    private MouseLook mouseLook;

    // Rotate
    private float camZ = 0.0f;


    private PostProcessVolume volume;
    private MotionBlur blur;
    private AudioSource music;

    private LensDistortion distorsion;
    int distorIntens = 0;
    int oldScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<GestionScore>();
        mouseLook = GetComponent<MouseLook>();
        volume = GameObject.Find("PPVol").GetComponent<PostProcessVolume>();
        blur = volume.profile.GetSetting<MotionBlur>();
        distorsion = volume.profile.GetSetting<LensDistortion>();
        music = GameObject.Find("music").GetComponent<AudioSource>();
        drunk = score.GetScore();
        Camera.main.fieldOfView = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (score.GetScore() == 0)
            return;
       
        drunk = (float)score.GetScore() / 10;
        FeelDrunk();
    }

    private void FeelDrunk()
    {
        FeelDrunk_FOV();
        FeelDrunk_Rotate();
        FeelDrunk_Distorsion();
        FeelDrunk_MotionBlur();

        if (oldScore != score.GetScore())
        {
            FeelDrunk_Pitch();
            oldScore = score.GetScore();
        }
    }

    private void FeelDrunk_FOV()
    {
        float newDrunk = negFov ? Random.Range(-drunk, 0) : Random.Range(0, drunk); // Je récupère le nb de points // Si (neg) => interval max atteint pour le FOV
        float fov = Camera.main.fieldOfView;
        if (fov < min)
        {
            negFov = false;
           Camera.main.fieldOfView = min;
        }
        if (fov > max)
        {
            negFov = true;
            Camera.main.fieldOfView = max;
        }
        Camera.main.fieldOfView += newDrunk;
    }

    private void FeelDrunk_Rotate()
    {
        int min = -score.GetScore();
        int max = score.GetScore();

        camZ -= negRotate ? Random.Range(-drunk, 0) : Random.Range(0, drunk);
        if (camZ < min)
        {
            negRotate = true;
            camZ = min;
        }
        if (camZ > max)
        {
            negRotate = false;
            camZ = max;
        }
   
        transform.localRotation = Quaternion.Euler(mouseLook.GetX(), 0f, camZ);
    }

    private void FeelDrunk_MotionBlur()
    {
        if (!blur.active)
            blur.active = true;
        blur.shutterAngle.value = (float)score.GetScore() * 2;
    }

    private void FeelDrunk_Distorsion()
    {
        int point = score.GetScore() * 10;
        if (point > 50)
            point = 50;
        if (!distorsion.active)
        {
            distorsion.active = true;
            return;
        }
        distorIntens -= negDist ? -1 : 1;
        if (distorsion.intensity.value < -point)
        {
            distorIntens = -point;
            negDist = true;
        }
        if (distorsion.intensity.value > point)
        {
            distorIntens = point;
            negDist = false;
        }
        distorsion.intensity.value = distorIntens;
    }

    private void FeelDrunk_Pitch()
    {
        if (oldScore > score.GetScore())
            music.pitch += 0.02f;
        else
            music.pitch -= 0.02f;
    }

    public float GetCamZ()
    {
        return camZ;
    }

    public void GetSober()
    {
        distorsion.intensity.value = 0;
        blur.shutterAngle.value = 0;
        distorsion.active = false;
        blur.active = false;
        Camera.main.fieldOfView = 60;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f); ;
        oldScore = 0;
        negFov = false;
        negRotate = false;
        distorIntens = 0;
        negDist = false;
        camZ = 0;
    }
}
