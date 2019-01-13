using UnityEngine;
class Bullet: MonoBehaviour
{
    private GameObject targetEnemy;
    private ObjectPool bulletPool;
    void Start()
    {
        Global.GetInstance().GetEvent().AddListener(EventProcess);
    }
    public void InitWithData(GameObject enemy, ObjectPool pool)
    {
        targetEnemy = enemy;
        bulletPool = pool;
    }
    void EventProcess(EventEnum events, GameObject obj)
    {
        switch (events)
        {
            case EventEnum.RecoverEnemy:
                if (targetEnemy != null &&
                    targetEnemy.transform.GetComponent<Enemy>().index == obj.transform.GetComponent<Enemy>().index)
                {
                    //如果敌人已经被回收了 那么跟踪他的子弹也需要回收
                    bulletPool.RecoverObject(gameObject);
                }
                break;
            default:
                break;
        }
    }
    void Update()
    {
        if (targetEnemy != null && targetEnemy.active)
        {
            Vector3 targetPos = targetEnemy.transform.position;
            float dis = Vector3.Distance(transform.position, targetEnemy.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.24f/dis);

            if (dis < 0.5) {
                targetEnemy = null;
                bulletPool.RecoverObject(gameObject);
            }
        }

    }
}