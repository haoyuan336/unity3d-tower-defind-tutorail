using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject body;
    private Color currentColor;
    // Start is called before the first frame update
    private int towerLevel = 0;
    private List<Color> levelColor = new List<Color>();
    void Start()
    {
        levelColor.Add(Color.blue);
        levelColor.Add(Color.red);
        levelColor.Add(Color.black);
        currentColor = body.transform.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnMouseDown()
    {
        this.body.transform.GetComponent<MeshRenderer>().material.color = Color.green;
        Global.GetInstance().GetEvent().Invoke(EventEnum.ShowUpdateMenu, gameObject);
    }
    public void OnMouseUp()
    {
        this.body.transform.GetComponent<MeshRenderer>().material.color = currentColor;
    }
    public void UpdateLevel()
    {
        if (towerLevel == 3)
        {
            return;
        }
        towerLevel++;
        this.body.transform.GetComponent<MeshRenderer>().material.color = levelColor[towerLevel - 1];
        currentColor = levelColor[towerLevel - 1];
    }
}
