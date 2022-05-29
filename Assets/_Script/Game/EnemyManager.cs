using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //[SerializeField] GameObject prefabEnemy;
    [SerializeField] List<GameObject> prefabEnemy = new List<GameObject>();

    List<GameObject> enemyPool = new List<GameObject>();

    Vector2 screen;
    int countenemy = 0;
    // Start is called before the first frame update
    void Start()
    {
        screen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screen.x -= 1;
        screen.y -= 1;
        StartCoroutine(spawCreep());
    }
    IEnumerator spawCreep()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(3);
            ArrayList selpos = new ArrayList();
            selpos.Add(new Vector2(screen.x, Random.Range(-screen.y, screen.y)));
            selpos.Add(new Vector2(-screen.x, Random.Range(-screen.y, screen.y)));
            selpos.Add(new Vector2(Random.Range(-screen.x, screen.x), screen.y));
            selpos.Add(new Vector2(Random.Range(-screen.x, screen.x), -screen.y));
            Vector2 pos = (Vector2)selpos[Random.Range(0,selpos.Count)];
            bool Found = false;
            foreach (GameObject g in enemyPool)
            {
                if (g.activeSelf)
                    continue;

                g.transform.position = pos;
                g.SetActive(true);
                Found = true;
                break;
            }

            if (Found)
                continue;
            if (countenemy > 3)
            {
                continue;
            }
            countenemy++;
            enemyPool.Add(Instantiate(prefabEnemy[Random.Range(0,prefabEnemy.Count)], pos, Quaternion.identity));

        }
    }
}
