using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject pathObject;
    public GameObject enemyPrefab;
    private GameObject enemy;
    // Start is called before the first frame update
    private float currentAddEnemeyTime = 0.0f;
    public float addEnemeyDutaction = 0.0f;
    private ObjectPool enemyPool = new ObjectPool();
    void Start()
    {
       
        for (int i = 0; i < 10; i ++)
        {
            GameObject enemy = this.CreateEnemey();
            enemyPool.pushObject(enemy);
        }
       
    }
    GameObject CreateEnemey()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.parent = this.transform;
        enemy.transform.GetComponent<Enemy>().SetObjectPool(enemyPool);
        return enemy;
    }
    void AddEnemey(){
        //GameObject enemy = Instantiate(enemyPrefab);

        GameObject enemy = enemyPool.getObject();
        if (enemy == null){
            enemy = this.CreateEnemey();
        }
        enemy.SetActive(true);
        enemy.transform.parent = transform;
        enemy.transform.position = pathObject.transform.GetChild(0).transform.position;
        enemy.transform.GetComponent<Enemy>().InitWithData(pathObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (this.currentAddEnemeyTime >= this.addEnemeyDutaction)
        {
            this.AddEnemey();
            this.currentAddEnemeyTime = 0.0f;
        }
        else
        {
            this.currentAddEnemeyTime += Time.deltaTime;
        }
    }
}
