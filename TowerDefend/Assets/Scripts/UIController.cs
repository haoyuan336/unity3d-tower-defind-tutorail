using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject buildMenu;
    public GameObject updateMenu;
    private GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {

        Global.GetInstance().GetEvent().AddListener(ProcessEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ProcessEvent(EventEnum eventType, GameObject obj)
    {
        this.targetObject = obj;
        switch (eventType)
        {
            case EventEnum.BuildMenu:
                Debug.Log("显示建造塔的ui");
                this.ShowBuildMenu(obj);
                break;
            case EventEnum.ShowUpdateMenu:
                this.ShowUpdateMenu(obj);
                break;
            default:
                break;
        }

   
    }
    void ShowUpdateMenu(GameObject obj)
    {
        this.buildMenu.SetActive(false);
        this.updateMenu.SetActive(true);
        this.updateMenu.transform.position = Camera.main.WorldToScreenPoint(obj.transform.position);
    }
    void ShowBuildMenu(GameObject obj)
    {
        this.updateMenu.SetActive(false);
        this.buildMenu.SetActive(true);
        this.buildMenu.transform.position = Camera.main.WorldToScreenPoint(obj.transform.position);
    }
    public void OnButtonClick(string data)
    {
        Debug.Log("button click =- "+ data);
        switch (data)
        {
            case "build-tower-1":
                Global.GetInstance().GetEvent().Invoke(EventEnum.BuildTower1, this.targetObject);
                this.buildMenu.SetActive(false);
                break;
            case "build-tower-2":
                Global.GetInstance().GetEvent().Invoke(EventEnum.BuildTower2, this.targetObject);
                this.buildMenu.SetActive(false);
                break;
            case "update":
                this.targetObject.transform.GetComponent<Tower>().UpdateLevel();
                this.updateMenu.SetActive(false);

                break;
            case "sell":
                //Global.GetInstance().GetEvent().Invoke(EventEnum.SellTower, this.targetObject);
                Destroy(this.targetObject);
                this.updateMenu.SetActive(false);
                break;
            default:
                break;

        }
    }
}
