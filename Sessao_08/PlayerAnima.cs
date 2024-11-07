//
// Copyright (c) 2023 IndieDevPt. All rights reserved.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnima : MonoBehaviour
{
    Animator _animator;
    PlayerMove _playerMove;
    Saude _saude;
    bool _morreu = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMove = GetComponent<PlayerMove>();
        _saude=GetComponent<Saude>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_saude.Morreu() && _morreu==false)
        {
            _morreu = true;
            _animator.SetTrigger("morto");
            Destroy(_playerMove);
            return;
        }
        _animator.SetFloat("velocidade", _playerMove._inputAndar);
        if (_playerMove.IsJumping)
            _animator.SetTrigger("saltar");
    }
}
