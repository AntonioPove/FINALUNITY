using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraScript : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;


    private void Update()
    {
        transform.position = Camera.main.transform.position + offset;
        transform.LookAt(Camera.main.transform.position);
    }
}
