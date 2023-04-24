using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    float launchVel;
    [SerializeField]
    GameObject proyectile;
    [SerializeField]
    Transform target;

    bool shooting = false;

    Quaternion iniRot;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        iniRot = transform.localRotation;
    }

 private void Start()
    {
        //InvokeRepeating("ShootP", 0, launchVel);
    }
    
    private void LateUpdate()
    {
        if (shooting)
        {
            //transform.localRotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }


    void ShootP()
    {
        Instantiate<GameObject>(proyectile, target.position, Quaternion.LookRotation(transform.forward));
    }


    public void ChangeShoot()
    {
        shooting = !shooting;

        if (!shooting)
        {
            CancelInvoke();
            animator.enabled = true;
            transform.localRotation = iniRot;
        }
        else
        {
            animator.enabled = false;
          
            InvokeRepeating("ShootP", 0, launchVel);
        }

       
    }
}
