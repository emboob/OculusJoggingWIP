using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    private int count = 0;
    
    public GameObject StartPoint;
    public GameObject Target;
    
    //public static float Dist;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StaticVar.Dist = Vector3.Distance(Target.transform.position, StartPoint.transform.position);        

        int quotient = ((int)StaticVar.Dist) / 30;
        int remainder = ((int)StaticVar.Dist) % 30;

		// 여기가 문제 (5가 넘어가면 먹통이 되어버림)
        int result = quotient % 5;

        if (remainder == 0)
        {
    		Debug.Log(result);
			Debug.Log((quotient) % 5);
            //Transform trChild = transform.parent.GetChild(17).GetChild(1).GetChild(result);
            Transform trChild = transform.GetChild(0).GetChild(1).GetChild(result);
            //Debug.Log(trChild);
            //trChild.gameObject.SetActive(true);
        }
    }

    /*void OnTriggerEnter(Collider col)
    {
        Debug.Log("Contents Hit");
        count++;

        if (count % 6 == 0)
        {
            count = 1;
        }

        Transform trChild = transform.parent.GetChild(1).GetChild(count);
        Debug.Log(trChild);
        trChild.gameObject.SetActive(true);

        //gameobject.transform.GetChild(i);
        //trChild.gameObject.SetActive(true);
    }*/
}
