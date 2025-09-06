using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fire : MonoBehaviour
{
    public GameObject firetransform;
    public GameObject shell;



    public int PlayerNumber = 1;
    public Slider AimSlider;

    public float MinLuanchForce = 15f;
    public float MaxLuanchForce = 30f;
    public float ChargeTime = 0.75f;
    public AudioSource ShootingAudio;
    public AudioClip Chargingclip;
    public AudioClip FireClip;



    private string FireButton;
    private float CurrentChargeTime;
    private float ChargeSpeed;
    private float CurrentLuanchForce;
    private bool Fired;
    // Start is called before the first frame update
    void Start()
    {
        FireButton = "Fire" + PlayerNumber;
        ChargeSpeed = (MaxLuanchForce - MinLuanchForce) / ChargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(FireButton))
        {
            CurrentLuanchForce = MinLuanchForce;
            Fired = false;

        }
        else if (Input.GetButton(FireButton) && !Fired)
        {
            CurrentLuanchForce += ChargeSpeed * Time.deltaTime;

            if (ShootingAudio.clip == FireClip)
            {
                ShootingAudio.clip = Chargingclip;
                ShootingAudio.Play();
            }





            if (CurrentLuanchForce >= MaxLuanchForce)
            {
                CurrentLuanchForce = MaxLuanchForce;
                Fire();


            }

        }
        else if (Input.GetButtonUp(FireButton) && !Fired)
        {
            Fire();

        }



        //生成炮弹位置
        //if (Input.GetButtonDown("FireButton"))
        //{
        //    GameObject gameObjectInstance = Instantiate(shell, firetransform.transform.position, firetransform.transform.rotation);
        //    Rigidbody rigidbody = gameObjectInstance.GetComponent<Rigidbody>();//引出炮弹物理组件
        //    rigidbody.velocity = firetransform.transform.forward * 15;//给予该方向上的一个速度
        //}
    }
    void Fire()
    {
        Fired = true;
        GameObject gameObjectInstance = Instantiate(shell, firetransform.transform.position, firetransform.transform.rotation);
        Rigidbody rigidbody = gameObjectInstance.GetComponent<Rigidbody>();
        rigidbody.velocity = firetransform.transform.forward * CurrentLuanchForce;

        CurrentLuanchForce = MinLuanchForce;
        ShootingAudio.clip = FireClip;
        ShootingAudio.Play();


    }
}
