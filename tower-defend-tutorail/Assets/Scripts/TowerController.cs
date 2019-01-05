using System.Collections.Generic;
using UnityEngine;
class TowerController: MonoBehaviour
{
    public List<GameObject> towerPrefabs;
    void Start()
    {
        Global.GetInstance().GetEvent().AddListener(EventProcess);
    }
    void EventProcess(EventEnum events, GameObject obj)
    {
        switch (events)
        {
            case EventEnum.BuildTower1:
                Debug.Log("建造Tower1");
                BuildOneTower(1,obj);
                break;
            case EventEnum.BuildTower2:
                BuildOneTower(2, obj);

                break;
            default:
                break;
        }
    }
    void BuildOneTower(int towerType,GameObject obj)
    {
        Debug.Log("建造一个Tower");
        GameObject tower = Instantiate(towerPrefabs[towerType - 1]);
        tower.transform.parent = transform;
        tower.transform.position = obj.transform.position;
    }
    void Update()
    {

    }
}