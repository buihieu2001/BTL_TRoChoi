using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button btn; 
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(NextScenes);
    }

    void NextScenes()
    {
        SceneManager.LoadScene(1);
    }
}
