using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cubeScript : MonoBehaviour
{
    public float gazeTime = 2f;
    private float timer;

    private bool gazedAt;

    private BoxCollider myCollider;
    private TextMesh DistCalculate;
    
    private Vector3 OriginalScale;
    

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        DistCalculate = GetComponent<TextMesh>();
        OriginalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        DistCalculate.text = ((int)StaticVar.Dist).ToString() + " m";
        
        if (gazedAt)
        {
            timer += UnityEngine.Time.deltaTime;

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current),
                    ExecuteEvents.pointerDownHandler);
                timer = 0f;
            }
        }
    }

    public void PointerEnter()  // 포인터가 들어오면 바라봄
    {
        gazedAt = true;
        DistCalculate.color = new Color(1, 0, 0, 1);
        Debug.Log("See");
        transform.localScale = OriginalScale * 1.2f;
        timer = 0f;
    }

    public void PointerExit() // 바라보다 멈추면 풀림
    {
        gazedAt = false;
        DistCalculate.color = new Color(0, 0, 0, 1);
        timer = 0f;
        transform.localScale = OriginalScale;
        Debug.Log("NO");
    }

    public void pointerDown()   // 포인터가 눌러졌을때의 함수
    {
        timer = 0f;
        DistCalculate.color = new Color(0, 0, 0, 1);
        myCollider.enabled = false;
        gameObject.SetActive(false);
        Debug.Log("OK");
    }
}
