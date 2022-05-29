using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisiablePopup : MonoBehaviour
{
    [SerializeField] GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VisiableNotify(float t = 1)
    {
        Time.timeScale = t;
        popup.SetActive(!popup.activeInHierarchy);
    }
}
