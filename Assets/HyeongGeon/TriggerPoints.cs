using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoints : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[3];

    Vector3 vec;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Point Hit");
        Debug.Log(col.name);
        if (gameObject.name == "P2")
        {

            //Debug.Log("현재의 Tnum : " + StaticVar.Tnum);

            StaticVar.Tnum = (StaticVar.Tnum + 1) % 3;
            
            //Debug.Log("다음 올 Tnum : " + StaticVar.Tnum);

            //Debug.Log("cc" + gameObject.transform.parent.transform.GetChild(2).position);

            vec = gameObject.transform.parent.transform.GetChild(2).position;
            vec.z = -127;
            //vec.x = gameObject.transform.parent.transform.parent.position.x;
        
            Debug.Log(prefabs[StaticVar.Tnum]);
            Debug.Log(vec);
            Debug.Log(Quaternion.identity);			

            Instantiate(prefabs[StaticVar.Tnum], vec, Quaternion.identity);

        }
        else if (gameObject.name == "P3")
        {
            //Debug.Log("P3");
            //Debug.Log(gameObject.transform.parent.transform.parent.transform.parent.name);
            
            Destroy(gameObject.transform.parent.transform.parent.transform.parent.gameObject, 2f);
        }
    }
}
