using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        
        GetComponent<TextMesh>().text = a.ToString() + " + " + b.ToString() + " = ? ";
        
        //t.text = "new text set";

        //Sign.text = "a"; //((int)Random.Range(1, 9)).ToString(); //a.ToString(); // + " + " + b + " = ? ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
