using System.Collections.Generic;
using UnityEngine;
class Tower : MonoBehaviour {
    public GameObject levelObj;
    private int level = 1;
    void Start()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("mouse tower");
        Global.GetInstance().GetEvent().Invoke(EventEnum.ShowUpdateMenu, gameObject);
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
    }
}