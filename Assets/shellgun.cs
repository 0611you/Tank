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
        //Debug.Log("触发了一个物体");
        //播放爆炸特效
        ExplosionParticle.transform.parent = null;
        ExplosionParticle.Play();
        //消除特效
        Destroy(ExplosionParticle.gameObject, ExplosionParticle.main.duration);
        //销毁炮弹
        Destroy(gameObject);
        //发出音效
        Explosionaudio.Play();
        
    }
}
