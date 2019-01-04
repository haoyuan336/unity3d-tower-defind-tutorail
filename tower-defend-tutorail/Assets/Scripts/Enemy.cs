using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Vector3> pathList = new List<Vector3>();
    private int pathIndex = 0;
    private Vector3 targetPos = Vector3.zero;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pathList != null && targetPos.Equals(Vector3.zero))
        {
            if (pathIndex == pathList.Count)
            {
                Debug.Log("移动结束");
                Destroy(gameObject);
                pathList = null;
            }
            else
            {
                targetPos = pathList[pathIndex];
                pathIndex++;
            }
        }
        if (!targetPos.Equals(Vector3.zero))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);
            float dis = Vector3.Distance(transform.position, targetPos);
            if (dis < 0.1f)
            {
                targetPos = Vector3.zero;
            }
        }
    }
    public void InitPathObject(GameObject pathObject)
    {
        for (int i = 0; i < pathObject.transform.childCount; i ++)
        {
            pathList.Add(pathObject.transform.GetChild(i).transform.position);
        }
    }
}
