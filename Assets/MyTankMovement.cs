using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class tankMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int PlayerNumber = 1;

    public AudioSource MovementAudio;
    public AudioClip EngineIdling;
    public AudioClip EngineDriving;

    public float PitchRange = 0.2f;
    public float OriginalPicth = 1;

    private string MovementAxisName;
    private string TurnAxisName;
    private float MovementInputValue;
    private float TurnInputValue;

    private Rigidbody rb;

    public float straightspeed = 10;
    public float turnspeed = 180;


    public GameObject camera;
    Vector3 v3 = new Vector3();

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        MovementAxisName = "Horizontal" + PlayerNumber;
        TurnAxisName = "Vertical" + PlayerNumber;
        v3 = camera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovementInputValue = Input.GetAxis(TurnAxisName);//�����滻�����м䲿��             ����-1��1����ֵ�����ð�������ȡ
        TurnInputValue = Input.GetAxis(MovementAxisName);//���滻
        //��������
        if (Mathf.Abs(MovementInputValue) < 0.1 && Mathf.Abs(TurnInputValue) < 0.1)
        {
            if (MovementAudio.clip == EngineDriving)
            {
                MovementAudio.clip = EngineIdling;
                MovementAudio.pitch = Random.Range(OriginalPicth - PitchRange, OriginalPicth + PitchRange);
                MovementAudio.Play();
            }

        }
        else
        {
            if (MovementAudio.clip == EngineIdling)
            {

                MovementAudio.clip = EngineDriving;
                MovementAudio.pitch = Random.Range(OriginalPicth - PitchRange, OriginalPicth + PitchRange);
                MovementAudio.Play();
            }
        }
        camera.transform.position = transform.position + v3;

    }
    private void FixedUpdate()
    {
        Move();
        Turn();

    }
    void Move()
    {
        Vector3 movement3 = transform.forward * MovementInputValue * Time.deltaTime * straightspeed;     //���������ƶ����·���
        rb.MovePosition(rb.position + movement3);//(rb,rb.transform,transform).position������
    }
    void Turn()
    {
        //���������ǹ�����ת��һ���·���
        float turn = TurnInputValue * Time.fixedDeltaTime * turnspeed;
        Quaternion turnliang = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnliang);

    }
}
