using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instant;
    public static GameController Instant => instant;
    public GameObject player;
    public GameObject bulletplayer;
    public GameObject bulletRed;

    private void Awake()
    {
        if (GameController.Instant == null)
            instant = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

}
