using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private ObjectPool bulletPool = null;
    private GameObject targetEnemy = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.targetEnemy != null && this.targetEnemy.active == true)
        {
            Vector3 enemyPos = this.targetEnemy.transform.position;
            Vector3 bulletPos = transform.position;
            float dis = Vector3.Distance(enemyPos, bulletPos);
            transform.position = Vector3.MoveTowards(bulletPos, enemyPos, 0.1f);
            if (dis < 1)
            {
                bulletPool.PushObject(gameObject);
                this.targetEnemy = null;
            }

        }


    }
    public void SetObjectPool(ObjectPool pool)
    {
        bulletPool = pool;
    }
    public void SetTarget(GameObject target)
    {
        this.targetEnemy = target;
    }
}
