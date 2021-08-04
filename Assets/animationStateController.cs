using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    private Animator animator;
    private int isRunningHash;

    private Vector3 movement;
    private float moveSpeed = 3.0f;

    private float accTargetSpeed;
    private float accCurrentSpeed = 0.0f;

    private Rigidbody rigidbody;
    public GameObject RoadAndTrees;
    private AudioSource runningSound;

    public float zPosition = 6.912203f;
    public float movePoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        runningSound = GetComponent<AudioSource>();
        
        isRunningHash = Animator.StringToHash("isRunning");
    }
    
    // Update is called once per frame
    // FixedUpdate = 프레임을 고정시켜놓고 변화
    void FixedUpdate()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool forwardPressed = Input.GetKey("w");

        //float zMove = Input.GetAxis("Vertical");
        float xMove = Input.GetAxis("Horizontal");
        float zMove = 0.01f;
        
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) != 0)
        {
            forwardPressed = true;
        }
        
        Vector3 getVelocity = new Vector3(0,0,0);
        
        //Debug.Log("h= " + h.ToString());
        //Debug.Log("v= " + h.ToString());
        

        // 사용자가 w키를 누르면
        if (!isRunning && forwardPressed)
        {
            // isRunning 매개변수를 true로 설정
            animator.SetBool(isRunningHash, true);
            
            //if (!runningSound.isPlaying)
            //{
            //    runningSound.Play();
            //}
        }
        else if (isRunning && forwardPressed)
        {
            getVelocity = new Vector3(0, 0, zMove) * moveSpeed;
            // 오큘러스 핸들 속도조정 speed 1
            Vector3 moveDir = new Vector3(0, 0, OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) * moveSpeed);

            // w키 속도 변경시 이 부분의 상수 변경
            transform.Translate(new Vector3(0, 0, zMove) * 10f);
            
            //OVRPose tracker = OVRManager.tracker.GetPose();
            //Debug.Log("position = " + tracker.position);

            // 오큘러스 핸들 속도조정 2
            transform.Translate(moveDir * 0.15f);
            
        }
        
        // w키를 떼면
        if (isRunning && !forwardPressed)
        {
            // isRunning 매개변수를 false로 설정
            animator.SetBool(isRunningHash, false);
            
            //runningSound.Stop();
        }
    }

    private float IncrementTowards(float n, float target, float a) // smooting speed
    {
        if (n == target) return n;
        else
        {
            float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target; // if n has now passed target then return target, otherwise return n
        }
    }
    
}
