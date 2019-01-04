using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject pathGameObject;
    private float addEnemyCurrentTime = 0.0f;
    const float addEnemyDuractionTime = 1.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (addEnemyCurrentTime > addEnemyDuractionTime)
        {
            this.AddEnemy();
            addEnemyCurrentTime = 0.0f;
        }
        else
        {
            addEnemyCurrentTime += Time.deltaTime;
        }

    }
    void AddEnemy()
    {
        Debug.Log("add one enemy");
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.parent = transform;
        enemy.GetComponent<Enemy>().InitPathObject(pathGameObject);
        enemy.transform.position = pathGameObject.transform.GetChild(0).transform.position;
    }
}
