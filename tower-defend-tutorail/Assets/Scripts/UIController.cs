using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buildTowerMenu;
    public GameObject updateTowerMenu;
    private GameObject currentObj;
    void Start()
    {
        Global.GetInstance().GetEvent().AddListener(EventProcess);
    }

    void EventProcess(EventEnum value, GameObject obj)
    {
        switch (value)
        {
            case EventEnum.ShowBuildMenu:
                updateTowerMenu.SetActive(false);
                buildTowerMenu.SetActive(true);
                buildTowerMenu.transform.position = Camera.main.WorldToScreenPoint(obj.transform.position);
                currentObj = obj;

                break;
            case EventEnum.CloseMenu:
               
                break;
            case EventEnum.ShowUpdateMenu:
                buildTowerMenu.SetActive(false);
                updateTowerMenu.SetActive(true);
                updateTowerMenu.transform.position = Camera.main.WorldToScreenPoint(obj.transform.position);
                currentObj = obj;

                break;
            default:
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonClick(string buttonType)
    {
        switch (buttonType)
        {
            case "build-tower-1":
                Global.GetInstance().GetEvent().Invoke(EventEnum.BuildTower1, currentObj);
                break;
            case "build-tower-2":
                Global.GetInstance().GetEvent().Invoke(EventEnum.BuildTower2, currentObj);

                break;
            case "bg-button":
                buildTowerMenu.SetActive(false);
                updateTowerMenu.SetActive(false);
                currentObj = null;
                Global.GetInstance().GetEvent().Invoke(EventEnum.CloseMenu, gameObject);
                break;
            case "update-tower":
                currentObj.transform.GetComponent<Tower>().UpdateTower();
                break;
            case "sell-tower":
                Destroy(currentObj);
                break;
            default:
                break;
        }
        buildTowerMenu.SetActive(false);
        updateTowerMenu.SetActive(false);
        currentObj = null;
    }
}
