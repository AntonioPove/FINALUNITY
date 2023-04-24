using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    float force;

    bool activate;
    Vector3 lastPos = Vector3.zero;
    Quaternion iniRot;

    Animator animator;

    Rigidbody rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        iniRot = transform.localRotation;
    }

    public void SetActivate(bool to)
    {
        activate = to;
        if (!activate)
        {
            rb.isKinematic = true;
            animator.enabled = true;
            transform.localRotation = iniRot;
        }
        else
        {
             rb.isKinematic = false;
             animator.enabled = false;
        }
            
    }



    private void LateUpdate()
    {
      
      /*
  if (!activate) return;

        //Quaternion newRot = Quaternion.LookRotation(Vector3.up, (lastPos - transform.position).normalized);

        //if (Quaternion.Angle(transform.localRotation, newRot) > 10)
        //    transform.localRotation = Quaternion.LookRotation(Vector3.up, (lastPos - transform.position).normalized);

        if (Math.Abs(transform.position.x - lastPos.x) > Math.Abs(transform.position.y - lastPos.y))
        {
            transform.localRotation = Quaternion.LookRotation(Vector3.up, Vector3.forward);
        }

        else
        {
            transform.localRotation = Quaternion.LookRotation(Vector3.up, Vector3.right);
            //if (transform.position.x - lastPos.x >= 0)
            //    transform.localRotation = Quaternion.LookRotation(Vector3.up, Vector3.right);
            //else
            //    transform.localRotation = Quaternion.LookRotation(Vector3.up, Vector3.left);
        }
           

        if (Vector3.Distance(transform.position, lastPos) > 0.2f)
        {
            //if (Math.Abs(transform.position.x - lastPos.x) > Math.Abs(transform.position.y - lastPos.y))
            //    transform.localRotation = Quaternion.LookRotation(Vector3.up, Vector3.right);
            //else
            //    transform.localRotation = Quaternion.LookRotation(Vector3.up, Vector3.up);

            lastPos = transform.position;
        }
*/
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Destroyable"))
        {
            Debug.Log("colisionMartillo");
            collision.transform.GetComponent<DestroyOnCollision>().
                LaunchPerHit((collision.transform.position - collision.contacts[0].point).normalized,force);
        }
    }
}
