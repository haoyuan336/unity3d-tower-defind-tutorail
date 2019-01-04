using UnityEngine.Events;
using UnityEngine;
enum EventEnum
{
    ShowBuildMenu
}
class TowerUnityEvent: UnityEvent<EventEnum ,GameObject>
{

}
class Global
{
    public static Global instance;
    public TowerUnityEvent myEvent = new TowerUnityEvent();
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
}