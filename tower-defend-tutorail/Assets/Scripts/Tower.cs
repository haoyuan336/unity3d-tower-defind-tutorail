using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Tower : MonoBehaviour {
    public GameObject levelObj;
    public GameObject towerRangeObj;
    public float shootDuraction = 0.5f;
    public GameObject bulletPos;

    private int level = 1;
    private GameObject targetEnemy;
    private float attackDistance;
    private float shootCurrentTime = 0.0f;
    void Start()
    {
        Global.GetInstance().GetEvent().AddListener(EventProcess);
        towerRangeObj.SetActive(true);
        //StartCoroutine("DelayRange");
        //attackDistance = GetAttackDistance();
        attackDistance = 4;
        float scale = Mathf.Sqrt(Mathf.Pow(attackDistance, 2) * 2);
        towerRangeObj.transform.localScale = new Vector3(scale + 1, 0.1f, scale + 1);
    }
    float GetAttackDistance()
    {
        Vector3 size = towerRangeObj.transform.localScale;
        return  Vector2.Distance(new Vector2(size.x, 0), new Vector2(0, size.z));
        
    }
    void EventProcess(EventEnum events, GameObject obj)
    {
        switch (events)
        {
            case EventEnum.CloseMenu:
                //关闭按钮的消息
                towerRangeObj.SetActive(false);
                break;
            case EventEnum.RecoverEnemy:
                //敌人被回收了
                if (targetEnemy != null && targetEnemy.transform.GetComponent<Enemy>().index == obj.transform.GetComponent<Enemy>().index) {
                    targetEnemy = null;
                }
                break;
            default:
                break;
        }
    }
    void Update()
    {
        if (targetEnemy == null){
            List<GameObject> enemyList = Global.GetInstance().GetEnemyList();

            //获取到 敌人与自己的 距离
            for (int i = 0; i < enemyList.Count; i ++) {
                GameObject enemy = enemyList[i];
                float dis = Vector3.Distance(enemy.transform.position, transform.position);
                if (dis < attackDistance)
                {
                    //如果tower距离敌人的距离小于攻击距离，那么就锁定了这个敌人
                    targetEnemy = enemy;
                    shootCurrentTime = shootDuraction;
                    break;
                }
            }
        }
        if (targetEnemy != null)
        {
            Vector3 axi = Vector3.down;
            float angle = Vector3.SignedAngle( Vector3.forward,targetEnemy.transform.position - transform.position, Vector3.down) - 90;
            transform.rotation = Quaternion.AngleAxis(angle, axi);

            float dis = Vector3.Distance(targetEnemy.transform.position, transform.position);
            if (dis > attackDistance)
            {
                //重新寻找敌人, 超出了攻击范围
                targetEnemy = null;
            }
            else
            {
                if (shootCurrentTime > shootDuraction) {
                    shootCurrentTime = 0.0f;
                    ShootOneBullet();
                }
                else
                {
                    shootCurrentTime += Time.deltaTime;
                }

            }
        }
       
    }
    void ShootOneBullet()
    {
        //发射一枚子弹
        Global.GetInstance().GetBulletController().CreateOneBullet(bulletPos.transform.position, targetEnemy);
    }
    void OnMouseDown()
    {
        Global.GetInstance().GetEvent().Invoke(EventEnum.ShowUpdateMenu, gameObject);
        towerRangeObj.SetActive(true);
    }
    public void UpdateTower()
    {
        //升级tower 
        if (level == 4)
        {
            return;
        }
        level++;
        Color[] color = new Color[3];
        color[0] = Color.red;
        color[1] = Color.black;
        color[2] = Color.green;
        levelObj.transform.GetComponent<MeshRenderer>().material.color = color[level - 2];
        towerRangeObj.transform.localScale = new Vector3(level + 4, 0.1f, level + 4);
        //StartCoroutine("DelayRange");
        attackDistance += 1;
        float scale = Mathf.Sqrt(Mathf.Pow(attackDistance , 2) * 2) ;

        towerRangeObj.transform.localScale = new Vector3(scale + 1 , 0.1f, scale + 1 );
    }
    IEnumerator DelayRange()
    {
        float time = 0;
        while (time < 0.4)
        {
            time += Time.deltaTime;
            yield return null;
        }
        if (towerRangeObj != null)
        {
            towerRangeObj.SetActive(false);

        }
    }
    void OnDestroy()
    {
        Global.GetInstance().GetEvent().RemoveListener(EventProcess);
    }
}