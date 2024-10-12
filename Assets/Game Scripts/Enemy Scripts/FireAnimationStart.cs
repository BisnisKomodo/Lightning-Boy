using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimationStart : MonoBehaviour
{
    private Animator fire;

    private void Awake()
    {
        fire = GetComponent<Animator>();
    }

    private void Start()
    {
        fire.SetTrigger("ActivateFire");
    }
}
