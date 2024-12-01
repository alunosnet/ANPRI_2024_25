//
// Copyright (c) 2022 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject prefabEfeitoExplosao;
    public float RaioExplosao = 10f;
    public float ForcaExplosao = 10f;
    public int DanoExplosao = 50;

    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var temp = collision.transform.GetComponent<Armadilha>();
        if (temp != null)
            Explosao();
    }
    public void Explosao()
    {
        Vector3 posicao = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicao, RaioExplosao);
        foreach(Collider obj in colliders)
        {
            if (obj is CharacterController) continue;
            //aplicar força
            Rigidbody rb = obj.transform.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(ForcaExplosao, posicao, RaioExplosao, 3);

            Saude saude = obj.GetComponent<Saude>();
            if (saude != null)
                saude.PerdeVida(DanoExplosao);

            if(_audioSource!=null)
                _audioSource.Play();

            Destroy(this.gameObject, _audioSource.clip.length);
            transform.GetComponent<Renderer>().enabled = false;
            transform.GetComponent<Collider>().enabled = false;

            if(prefabEfeitoExplosao!=null)
            {
                var temp=Instantiate(prefabEfeitoExplosao,transform.position,Quaternion.identity);
                Destroy(temp, 4);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
