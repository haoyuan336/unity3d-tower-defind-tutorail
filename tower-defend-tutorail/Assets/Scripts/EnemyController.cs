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
    private ObjectPool enemyPool = new ObjectPool();
    void Start()
    {
        for (int i = 0; i < 5; i ++) {
            GameObject enemy = CreateEnemy();
            enemyPool.RecoverObject(enemy);
        }
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
        //Debug.Log("add one enemy");
        // GameObject enemy = Instantiate(enemyPrefab);
        //enemy.transform.parent = transform;
        //enemy.GetComponent<Enemy>().InitPathObject(pathGameObject);
        //enemy.transform.position = pathGameObject.transform.GetChild(0).transform.position;
        GameObject enemy = enemyPool.GetObject();
        if (enemy == null)
        {
            Debug.Log("未取到敌人");
            enemy = CreateEnemy();
        }
        enemy.transform.position = pathGameObject.transform.GetChild(0).transform.position;
        enemy.GetComponent<Enemy>().InitPathObject(pathGameObject);
        enemy.SetActive(true);

    }
    GameObject  CreateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.parent = transform;
        enemy.GetComponent<Enemy>().SetEnemyPool(enemyPool);
        return enemy;
    }
}
