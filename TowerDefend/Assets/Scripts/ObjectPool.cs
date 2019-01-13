using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> objectList = new List<GameObject>();
    public ObjectPool()
    {
        
    }
    public GameObject getObject()
    {
        if (objectList.Count == 0)
        {
            return null;
        }
        else
        {
            GameObject obj = objectList[objectList.Count - 1];
            objectList.RemoveAt(objectList.Count - 1);
            return obj;
        }
    }
    public void pushObject(GameObject obj)
    {
        obj.SetActive(false);
        objectList.Add(obj);
    }
}