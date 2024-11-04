//
// Copyright (c) 2022 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public float IntervaloSpawn = 5;
    public int Limite = -1; //-1 não tem limite; 0 acabou >0 contagem de spawns
    public Transform PontoSpawn;
    float ProximoSpawn;
    public Vector3 SpawnForce = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        ProximoSpawn = Time.time + IntervaloSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > ProximoSpawn && Limite != 0)
            NovoSpawn();
    }
    void NovoSpawn()
    {
        if(Limite>0)
            Limite--;
        ProximoSpawn = Time.time + IntervaloSpawn;
        var GO = Instantiate(Prefab, PontoSpawn.position, Quaternion.identity);
        Vector3 Direcao = new Vector3(
                SpawnForce.x * Utils.RandomOneMinusOne(),
                SpawnForce.y,
                SpawnForce.z*Utils.RandomOneMinusOne()
            );
        var rb = GO.GetComponent<Rigidbody>();
        rb.AddForce(Direcao, ForceMode.Impulse);
        rb.AddRelativeTorque(Direcao,ForceMode.Impulse);
    }
}
