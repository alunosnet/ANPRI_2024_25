//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController _characterController;

    public float VelocidadeRotacao = 3;
    public float VelocidadeAndar = 3;
    public float VelocidadeSalto = -2;
    [SerializeField]
    float _inputRodar;

    public float _inputAndar;
    public bool IsGrounded;
    public bool IsJumping;
    Vector3 _velocidade;

    // Start is called before the first frame update
    void Start()
    {
        _characterController=GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("O Player tem de ter um character controller");
    }

    // Update is called once per frame
    void Update()
    {
        //rotação
        _inputRodar = Input.GetAxis("Mouse X");
        transform.Rotate(transform.up * _inputRodar*VelocidadeRotacao * Time.deltaTime);

        //movimento
        _inputAndar = Input.GetAxis("Vertical");

        //correr
        if (Input.GetButton("Run") && _inputAndar>0)
            _inputAndar *= 2;

        Vector3 movimento = transform.forward * _inputAndar * VelocidadeAndar * Time.deltaTime;
        _characterController.Move(movimento);

        //saltar
        if (Input.GetButtonDown("Jump") && IsGrounded)
            //Bug corrigido em 10/10/2022: faltava multiplicar por Time.deltaTime
            _velocidade.y = Mathf.Sqrt(VelocidadeSalto * Physics.gravity.y);
		else
            _velocidade += Physics.gravity * Time.deltaTime;

        //aplicar gravidade
        _characterController.Move(_velocidade * Time.deltaTime);


        IsGrounded = _characterController.isGrounded;
    }
}
