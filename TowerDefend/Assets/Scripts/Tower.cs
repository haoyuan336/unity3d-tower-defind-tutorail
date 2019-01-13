using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject body;
    public float attackDistance;
    public float attackDuraction;
    public GameObject bulletPrefab;
    private float currentAttackTime;
    private ObjectPool bulletPool = new ObjectPool();
    public GameObject bulletPos;
    private Color currentColor;

    // Start is called before the first frame update
    private int towerLevel = 0;
    private List<Color> levelColor = new List<Color>();
    private GameObject targetEnemy = null;
    GameObject enemyController = Global.GetInstance().GetEnemyController();
    void Start()
    {
        levelColor.Add(Color.blue);
        levelColor.Add(Color.red);
        levelColor.Add(Color.black);
        currentColor = body.transform.GetComponent<MeshRenderer>().material.color;
        for (int i = 0; i < 5; i ++)
        {
            GameObject obj = this.CreateBullet();
            bulletPool.PushObject(obj);
        }
    }
    GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = this.bulletPos.transform.position;
        bullet.transform.GetComponent<Bullet>().SetObjectPool(bulletPool);
        bullet.transform.parent = transform.parent;
        return bullet;
    }
    void AddBullet(GameObject target)
    {
        GameObject bullet = bulletPool.GetObject();
        if (bullet == null)
        {
            bullet = this.CreateBullet();
        }
        bullet.SetActive(true);
        bullet.transform.position = bulletPos.transform.position;
        bullet.transform.GetComponent<Bullet>().SetTarget(target);
    }
    // Update is called once per frame
    void Update()
    {
        if (targetEnemy == null)
        {
            
            List<GameObject> enemyList =  enemyController.transform.GetComponent<EnemyController>().GetEnemyList();
            for (int  i = 0; i < enemyList.Count; i ++)
            {
                GameObject enemy = enemyList[i];
                Vector3 enemyPos = enemy.transform.position;
                Vector3 towerPos = transform.position;
                float dis = Vector3.Distance(enemyPos, towerPos);
                if (dis < attackDistance)
                {
                    this.targetEnemy = enemy;

                }
            }
        }
        else
        {

            if (this.currentAttackTime > this.attackDuraction)
            {
                this.AddBullet(this.targetEnemy);
                this.currentAttackTime = 0.0f;
            }
            else
            {
                this.currentAttackTime += Time.deltaTime;
            }

            Vector3 towerV = new Vector3(0, 0, 1);
            Vector3 enemyV = this.targetEnemy.transform.position - transform.position;
            float angle = Vector3.SignedAngle(towerV, enemyV, Vector3.up);
            //Debug.Log("angle" + angle);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

            Vector3 enemyPos = this.targetEnemy.transform.position;
            Vector3 towerPos = transform.position;
            float dis = Vector3.Distance(enemyPos, towerPos);
            if (dis > this.attackDistance)
            {
                this.targetEnemy = null;
            }
        }
    }
    public void OnMouseDown()
    {
        this.body.transform.GetComponent<MeshRenderer>().material.color = Color.green;
        Global.GetInstance().GetEvent().Invoke(EventEnum.ShowUpdateMenu, gameObject);
    }
    public void OnMouseUp()
    {
        this.body.transform.GetComponent<MeshRenderer>().material.color = currentColor;
    }
    public void UpdateLevel()
    {
        if (towerLevel == 3)
        {
            return;
        }
        towerLevel++;
        this.body.transform.GetComponent<MeshRenderer>().material.color = levelColor[towerLevel - 1];
        currentColor = levelColor[towerLevel - 1];
    }
}
