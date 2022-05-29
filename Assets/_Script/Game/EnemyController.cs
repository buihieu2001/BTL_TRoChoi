using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float Speed = 3;

    Coroutine randomDir,randomBul;

    List<GameObject> bullet_pool = new List<GameObject>();
    int[] angle = { 0, 90, 180, -90 };
    int anglenow = 0;

    private void OnEnable()
    {
        anglenow = angle[Random.Range(0, 3)];
        this.transform.rotation = Quaternion.Euler(0, 0, anglenow);
        randomDir = StartCoroutine(RandomDir());
        randomBul = StartCoroutine(Fire(2));
    }

    private void OnDisable()
    {
        StopCoroutine(randomDir);
        StopCoroutine(randomBul);
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.up * Speed * Time.deltaTime;        
    }
    IEnumerator Fire(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            bool Found = false;
            foreach (GameObject g in bullet_pool)
            {
                if (g.activeSelf)
                    continue;
                g.transform.rotation = Quaternion.Euler(0, 0, anglenow);
                g.transform.position = this.transform.position;

                g.SetActive(true); 
                Found = true;
                break;
            }
            if (Found)
                continue;

            GameObject b = Instantiate(GameController.Instant.bulletRed, this.transform.position, Quaternion.identity);
            b.transform.rotation = Quaternion.Euler(0, 0, anglenow);
            bullet_pool.Add(b);

        }
    }
    IEnumerator RandomDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            anglenow = angle[Random.Range(0, 3)];
            this.transform.rotation = Quaternion.Euler(0, 0, anglenow);
        }
    }
}
