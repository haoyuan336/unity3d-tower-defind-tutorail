using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Vector3> pathList = new List<Vector3>();
    private int pathIndex = 0;
    private Vector3 targetPos = Vector3.zero;
    public int index;
    private ObjectPool enemyPool;
    private bool isRuning = false;
    void Start()
    {
    }
    public void SetEnemyPool(ObjectPool objPool)
    {
        enemyPool = objPool;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isRuning)
        {
            return;
        }
        if (pathList.Count != 0 && targetPos.Equals(Vector3.zero))
        {
            if (pathIndex == pathList.Count)
            {
                Global.GetInstance().RemoveEnemy(index);
                enemyPool.RecoverObject(gameObject);
                pathList.RemoveRange(0, pathList.Count);
                Global.GetInstance().GetEvent().Invoke(EventEnum.RecoverEnemy, gameObject);
            }
            else
            {
                targetPos = pathList[pathIndex];
                pathIndex++;
            }
        }
        if (!targetPos.Equals(Vector3.zero))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);
            float dis = Vector3.Distance(transform.position, targetPos);
            if (dis < 0.1f)
            {
                
                targetPos = Vector3.zero;
            }
        }
    }
    public void InitPathObject(GameObject pathObject)
    {
        for (int i = 0; i < pathObject.transform.childCount; i ++)
        {
            pathList.Add(pathObject.transform.GetChild(i).transform.position);
        }
        pathIndex = 0;
        targetPos = Vector3.zero;
        isRuning = true;
        Global.GetInstance().PushEnemy(gameObject);

    }
    public void SetEnemyIndex(int value)
    {
        index = value;
    }
    
}
