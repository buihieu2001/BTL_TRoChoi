using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed = 8;

    Coroutine deactive_routine;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        this.transform.position += transform.up * Speed * Time.deltaTime;
    }

    //private void OnEnable()
    //{
    //    deactive_routine = StartCoroutine(Deactive(5));
    //}
    //void OnDisable()
    //{
    //    StopCoroutine(deactive_routine);
    //}
    //IEnumerator Deactive(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    this.gameObject.SetActive(false);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);
        if (collision.transform.tag == "CanNotDestroy")
        {
            return;
        }
        if (collision.transform.tag == "Bullet")
        {
            return;
        }
        if (collision.transform.tag == "Enemy")
        {
            CanvasController.Instant.Score++;
            collision.gameObject.SetActive(false);
            return;
        }
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Die");
            CanvasController.Instant.win = false;
            return;
        }
        collision.gameObject.SetActive(false);
    }
}
