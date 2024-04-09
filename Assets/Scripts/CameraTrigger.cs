using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [Tooltip("Set True to trigger target camera On elese it will be triggered Off")]
    public bool triggerState;

    [Tooltip("The target virtual camera to trigger")]
    public CinemachineVirtualCamera targetCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetCamera != null && collision.gameObject.tag == "Player")
        {
            targetCamera.gameObject.SetActive(triggerState);
        }
    }
}
