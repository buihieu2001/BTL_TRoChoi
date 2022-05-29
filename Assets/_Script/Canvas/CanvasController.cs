using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private static CanvasController instant;
    public static CanvasController Instant => instant;
    public int Score = 0;
    public bool win = true;
    [SerializeField] int Scorewin = 5;
    [SerializeField] float Timer = 60;
    [SerializeField] Text timeText;
    [SerializeField] Text scoreTextNow;
    public Text scoreTextEnd;

    public GameObject NotifyEnd;
    [SerializeField] Text TextEnd;

    private void Awake()
    {
        if (CanvasController.Instant == null)
            instant = this;
        //DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        checkTime();
        if (win == false)
        {
            GameOver();
            return;
        }
        if(Score == Scorewin)
        {
            Winner();
            return;
        }
        scoreTextNow.text = "Score: " + Score.ToString();
    }

    void checkTime()
    {
        if(Timer <= 0)
        {
            win = false;
            return; 
        }
        Timer -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.RoundToInt(Timer).ToString() + " s";
    }
    
    void GameOver()
    {
        NotifyEnd.SetActive(true);
        TextEnd.text = "Game Over!";
        scoreTextEnd.text = "Score: "+ Score.ToString();
        Time.timeScale = 0;
    }
    void Winner()
    {
        NotifyEnd.SetActive(true);
        TextEnd.text = "Win!";
        scoreTextEnd.text = "Score: " + Score.ToString();
        Time.timeScale = 0;
    }
}
