using UnityEngine;
class Plane : MonoBehaviour
{

    void OnMouseDown()
    {
        Debug.Log("mouse down");
        //Global.GetInstance().GetEvent().Invoke(EventEnum.CloseMenu, gameObject);
    }
}