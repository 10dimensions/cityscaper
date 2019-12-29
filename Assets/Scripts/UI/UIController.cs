using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Threading;

public class UIController : MonoBehaviour {

  private static UIController _instance;
  public static UIController Instance {get {return _instance;}}
  private UIMgr UIManager;

  public Button PlayGame;

  [Header("UI Stats")]
  public int timeLeft = 179; //Seconds Overall
  public Text countdown; //UI Text Object
  public Slider FogToggle;
  public Text TargetCounterText;
  private int CurrentTarget;


  [Header("UI Panels")]
  public GameObject UIPlay;
  public GameObject UIGame;
  public GameObject Player;


  [Header("Environment")]
  public Camera MainCam;
  public GameObject FogEffect;
  public Color DayColor;
  public Color NightColor;
  public Light SceneLight;



  void Awake()
  {
    _instance = this;
  }

  void Start () 
  { 
    UIManager = UIMgr.Instance;

    PlayGame.onClick.AddListener(ShowGameUI);

    FogToggle.onValueChanged.AddListener (delegate {SliderValueChanged ();});

    Time.timeScale = 1; //Just making sure that the timeScale is right
  }

  void Update () 
  { 
    countdown.text = "0" + (timeLeft/60).ToString() + " : " + 
                    ((timeLeft%60) <10? "0"+(timeLeft%60).ToString():(timeLeft%60).ToString()); //Showing the Score on the Canvas

    //countdown.text = ("00 : " + timeLeft.ToString()); //Showing the Score on the Canvas
  }


  private void ShowGameUI()
  {
    UIPlay.SetActive(false);
    UIGame.SetActive(true);
    Player.SetActive(true);

    StartCoroutine("LoseTime");
  }

  //Timer Coroutine
  IEnumerator LoseTime()
  {
    while (true) {
      yield return new WaitForSeconds (1);
      timeLeft--; 
      if(timeLeft == 0)  UIMgr.Instance.ReLoadGame();
    }
  }
  
  public void InitScore()
  {
    CurrentTarget = UIManager.TargetCount;
    TargetCounterText.text =   CurrentTarget.ToString() + "/" + UIManager.TargetCount.ToString();
  }

  public void ChangeScore()
  { 
    CurrentTarget --;
    TargetCounterText.text =   CurrentTarget.ToString() + "/" + UIManager.TargetCount.ToString();

    if(CurrentTarget == 0)  UIMgr.Instance.ReLoadGame();
  }

  public void SliderValueChanged()
  {
    if(FogToggle.value == 0)
    {
      MainCam.backgroundColor = DayColor;
      FogEffect.SetActive(false);
      SceneLight.intensity = 1f;
    }
    else if(FogToggle.value == 1)
    {
      MainCam.backgroundColor = NightColor;
      FogEffect.SetActive(true);
      SceneLight.intensity = 0.1f;
    } 
  }



}