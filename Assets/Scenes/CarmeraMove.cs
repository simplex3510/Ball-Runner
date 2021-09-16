using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmeraMove : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    // UI 관련은 LateUpdate로
    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
