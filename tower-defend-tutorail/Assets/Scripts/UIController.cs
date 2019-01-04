using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buildTowerMenu;
    public GameObject updateTowerMenu;
    void Start()
    {
        Global.GetInstance().GetEvent().AddListener(EventProcess);
    }

    void EventProcess(EventEnum value, GameObject obj)
    {
        switch (value)
        {
            case EventEnum.ShowBuildMenu:
                buildTowerMenu.SetActive(true);
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
