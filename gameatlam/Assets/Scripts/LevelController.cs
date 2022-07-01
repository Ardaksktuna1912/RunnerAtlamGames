using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public bool gameactive = false;
    public GameObject startmenu;
    public Text currentleveltext, nextleveltext;
    public ScooterControl scontrol;
    int currentlevel;
    public Slider slide;
    public float maxDistance;
    public GameObject finishline;
    //public GameObject loadnextlevel;
   




    void Start()
    {

        Current = this;
        scontrol = GetComponent<ScooterControl>();

        currentlevel = PlayerPrefs.GetInt("currentlevel");
        

        if (currentlevel>=6)
        {
            currentlevel = 0;
        }



        if (SceneManager.GetActiveScene().name != "Level " + currentlevel)
        {
            SceneManager.LoadScene("Level " + currentlevel);
            
        }

        else
        {
            currentleveltext.text = (currentlevel + 1).ToString();
            nextleveltext.text = (currentlevel + 2).ToString();
        }
    }


    void Update()
    {
        if (gameactive)
        {
            CharacterControl player = CharacterControl.Current;
            float distance = finishline.transform.position.z - CharacterControl.Current.transform.position.z;
            slide.value = 1 - (distance / maxDistance);


        }
    }
    public void Startlevel()
    {
        maxDistance = finishline.transform.position.z - CharacterControl.Current.transform.position.z;
        CharacterControl.Current.ChangeSpeed(CharacterControl.Current.runningspeed);
        CharacterControl.Current.anim.SetBool("running", true);
        startmenu.SetActive(false);
        //loadnextlevel.SetActive(true);
        Time.timeScale = 1f;
        gameactive = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextLevel()
    {

        SceneManager.LoadScene("Level " + (currentlevel + 1));

    }
    public void GameReturn()
    {
        SceneManager.LoadScene("Level " +(0));
        gameactive = false;
    }
    public void FinishGame()
    {
        PlayerPrefs.SetInt("currentlevel", currentlevel + 1);
        gameactive = false;
    }


}
