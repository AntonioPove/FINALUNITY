using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    float force, area, explodeAfterSeconds, deleteAfterSeconds;
    [SerializeField]
    GameObject explosionEffect;
    [SerializeField]
    LayerMask destroyableLayer;
    [SerializeField]
    TextToPlayer text;

    bool catched = false;
    bool countDown = false;


    private void Update()
    {
        if (!catched)
            transform.GetChild(0).rotation *= Quaternion.Euler(new Vector3(0, 10f * Time.deltaTime, 0));
    }
    public void LaunchObject()
    {
        Debug.Log(Camera.main.name);
        var rb = GetComponent<Rigidbody>();
         rb.useGravity = true;
          rb.isKinematic = false;
        rb.AddForce((transform.position - Camera.main.transform.position).normalized * force/10);
       

        Invoke("Bum", explodeAfterSeconds);
        countDown = true;
        text.ActualiceText(explodeAfterSeconds);
    }

    public void Catched()
    {
        catched = true;
        transform.GetChild(0).GetComponent<Animator>().enabled = false;
        transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
    }

    void Bum()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, area, destroyableLayer);

        DestroyOnCollision d;
        foreach (var item in cols)
        {
            d = item.GetComponent<DestroyOnCollision>();

            if(d != null)
                d.DestroyPerHit();
            
        }
        if(explosionEffect != null)
        explosionEffect.SetActive(true);

        transform.GetChild(0).gameObject.SetActive(false);

        Destroy(gameObject, deleteAfterSeconds);
    }
}
