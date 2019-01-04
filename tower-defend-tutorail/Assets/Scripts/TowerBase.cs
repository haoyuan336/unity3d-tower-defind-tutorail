using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        Debug.Log("点中了");
        //点中之后 ，显示建造tower 的ui
        Global.GetInstance().GetEvent().Invoke(EventEnum.ShowBuildMenu, gameObject);
    }
}
