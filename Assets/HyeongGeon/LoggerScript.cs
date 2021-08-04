using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoggerScript : MonoBehaviour
{
    public Text TimeTxt;
    public Text DistanceTxt;

    public GameObject StartPoint;

    public GameObject Target;

    public float Dist;
    public float time;
    float hour = 0.0f;
    float min = 0.0f;
    float sec = 0.0f;

	public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Dist = Vector3.Distance(Target.transform.position, StartPoint.transform.position);

        DistanceTxt.text = "Distance : " + ((int)Dist).ToString() + "M";

        time += Time.deltaTime;
        hour = ((int)time / 3600);
        min = ((int)time / 60 % 60);
        sec = ((int)time % 60);

        TimeTxt.text = "Time : " + hour.ToString() + "h" + min.ToString() + "m" + sec.ToString() + "s";
		
		int result = ((int)Dist) % 30;

		/*
		if (result == 2)
		{
			//Transform trChild = transform.parent.GetChild(2).GetChild(4).GetChild(17).GetChild(0).GetChild(1);
        	Transform trChild = transform.parent.GetChild(1);
			Debug.Log(trChild);
        	//trChild.gameObject.SetActive(true);
		}*/

        //if (count % 6 == 0)
        //{
        //    count = 1;
        //}

        //Transform trChild = transform.GetChild(0).GetChild(count);
		//Transform trChild = transform.par
        //Debug.Log(trChild);
        //trChild.gameObject.SetActive(true);
    }

    void TimeFreeze(float num)
    {
        if (num == 1.0f) Time.timeScale = 1.0f;
        else Time.timeScale = 0.0f;
    }

    void TimeReset()
    {
        time = 0.0f;
    }


}
