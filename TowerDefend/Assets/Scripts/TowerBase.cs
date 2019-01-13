using UnityEngine;
public class TowerBase:MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.gray;
    }
    void Update()
    {

    }
    public void OnMouseDown()
    {
        Debug.Log("touch start");
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        Global.GetInstance().GetEvent().Invoke(EventEnum.BuildMenu, gameObject);

    }
    public void OnMouseUp()
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.gray;
    }
}