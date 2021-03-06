﻿using UnityEngine;
using UnityEngine.Events;
public enum EventEnum
{
    BuildMenu,BuildTower1, BuildTower2,ShowUpdateMenu,SellTower
}
public class TowerEvent: UnityEvent<EventEnum, GameObject>
{

}
public class Global
{
    public static Global instance = null;
    private TowerEvent myEvent = new TowerEvent();
    private GameObject enemyController = null;
    public Global()
    {

    }
    public GameObject GetEnemyController()
    {
        return enemyController;
    }
    public void SetEnemeyController(GameObject ctl)
    {
        enemyController = ctl;
    }
    public TowerEvent GetEvent()
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