using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myshellexplosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxLifeTime = 2f;
    public ParticleSystem ExplosionParticle;
    public AudioSource Explosionaudio;
    void Start()
    {
        Destroy(transform.gameObject, MaxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("������һ������");
        //���ű�ը��Ч
        ExplosionParticle.transform.parent = null;
        ExplosionParticle.Play();
        //������Ч
        Destroy(ExplosionParticle.gameObject, ExplosionParticle.main.duration);
        //�����ڵ�
        Destroy(gameObject);
        //������Ч
        Explosionaudio.Play();
        
    }
}
