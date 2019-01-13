using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;

enum EventEnum
{
    ShowBuildMenu,ShowUpdateMenu,CloseMenu, BuildTower1,BuildTower2,RecoverEnemy
}
class TowerUnityEvent: UnityEvent<EventEnum ,GameObject>
{

}
class OneParamEvent: UnityEvent<EventEnum>
{

}
class Global
{
    public static Global instance;
    public TowerUnityEvent myEvent = new TowerUnityEvent();
    private List<GameObject> enemyList = new List<GameObject>();
    private int enemyIndex = 1;
    private BulletController bulletController;
    public TowerUnityEvent GetEvent()
    {
        return myEvent;
    }
    public static Global GetInstance()
    {
        if (instance == null)
        {
            instance = new Global();
        }

        return instance;
    }
    public void PushEnemy(GameObject enemy)
    {
        enemy.transform.GetComponent<Enemy>().SetEnemyIndex(enemyIndex);
        enemyIndex++;
        enemyList.Add(enemy);
    }
    public void RemoveEnemy(int index)
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].transform.GetComponent<Enemy>().index == index) {
                enemyList.RemoveAt(i);
                return;
            }
        }
    }
    public List<GameObject> GetEnemyList(){
        return enemyList;
    }
    public void SetBulletController(BulletController control)
    {
        bulletController = control;
    }
    public BulletController GetBulletController()
    {
        return bulletController;
    }
}