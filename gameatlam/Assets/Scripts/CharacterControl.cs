using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    public float runningspeed;
    private float _currentrunningspeed;
    float NewX = 0;
    float TouchxDelta = 0;
    public float xSpeed;
    public float Xlimit;
    public GameObject Boostpre;
    public GameObject NegBoostpre;
    private ScooterMove _scmove;
    public GameObject scmoveobje;
    private ScooterControl _scont;
    public Animator anim;
    public GameObject animgameobje;
    public GameObject wintext;
    public GameObject restext;
    public GameObject loadtext;
    public TMP_Text _highscore;
    public static CharacterControl Current;




    void Start()
    {
        Current = this;
        Time.timeScale = 0f;
        _scmove = scmoveobje.GetComponent<ScooterMove>();
        anim = animgameobje.GetComponent<Animator>();
        _scmove.scooterspeed = 6f;
        _highscore.text = PlayerPrefs.GetInt("_highscore").ToString();



    }


    void Update()
    {
        if (LevelController.Current == null || !LevelController.Current.gameactive)
        {
            return;
        }
        RotateBoost();
        #region Hareket Sistemi
        ControlMobileOrEditor();
        BorderX();
        CalculatedMovement();
        #endregion
    }

    public void ControlMobileOrEditor()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            TouchxDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            TouchxDelta = Input.GetAxis("Mouse X");
        }

        NewX = transform.position.x + xSpeed * TouchxDelta * Time.deltaTime;
    }

    public void BorderX()
    {
        NewX = Mathf.Clamp(NewX, -Xlimit, Xlimit);
    }
    public void CalculatedMovement()
    {
        Vector3 newpos = new Vector3(NewX, transform.position.y, transform.position.z + _currentrunningspeed * Time.deltaTime);
        transform.position = newpos;
    }
    public void ChangeSpeed(float value)
    {
        _currentrunningspeed = value;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Scooter"))
        {
            restext.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (other.gameObject.CompareTag("Boost"))
        {
            _scmove.scooterspeed = 4f;
            other.gameObject.SetActive(false);

        }

        else if (other.gameObject.CompareTag("NegBoost"))
        {
            _scmove.scooterspeed = 10f;
            other.gameObject.SetActive(false);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            wintext.SetActive(true);
            _currentrunningspeed = 0;
            Xlimit = 0;
            loadtext.SetActive(true);
            anim.SetBool("won", true);

        }
    }
    void RotateBoost()
    {
        Boostpre.transform.Rotate(1f, 1f, 1f);
        NegBoostpre.transform.Rotate(1f, 1f, 1f);

    }
   

}
