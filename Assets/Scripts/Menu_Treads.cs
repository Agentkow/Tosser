using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Treads : MonoBehaviour
{
    private Animator animate;

    void Start()
    {
        animate = GetComponent<Animator>();
    }

    void Update()
    {
        animate.SetBool("Treads", true);
    }
}
