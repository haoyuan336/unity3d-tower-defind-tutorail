using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public List<GameObject> towerPrefabList;
    // Start is called before the first frame update
    void Start()
    {
        Global.GetInstance().GetEvent().AddListener(ProcessEvent);
    }
    void ProcessEvent(EventEnum eventType, GameObject obj)
    {
        switch (eventType) {
            case EventEnum.BuildTower1:
                this.BuildTower(towerPrefabList[0], obj);
                break;
            case EventEnum.BuildTower2:
                this.BuildTower(towerPrefabList[1], obj);

                break;
            default:
                break;
        }
    }
    void BuildTower(GameObject obj, GameObject tb)
    {
        GameObject tower = Instantiate(obj);
        tower.transform.parent = transform;
        tower.transform.position = tb.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
