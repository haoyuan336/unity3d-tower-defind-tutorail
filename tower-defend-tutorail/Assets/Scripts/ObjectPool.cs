using System.Collections.Generic;
using UnityEngine;  
public class ObjectPool
{
    private List<GameObject> objectList = new List<GameObject>();
    public void RecoverObject(GameObject obj){
        obj.SetActive(false);
        objectList.Add(obj);
    }
    public GameObject GetObject()
    {
        if (objectList.Count > 0)
        {
            GameObject obj = objectList[objectList.Count - 1];
            objectList.RemoveAt(objectList.Count - 1);
            return obj;
        }
        return null;
    }
}