using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private Vector3 offset;    //follow distance
    [SerializeField] private PlayerMovement player;

    private Vector3 nextPosition;

    private void FixedUpdate()
    {
        nextPosition = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, nextPosition, delay * Time.fixedDeltaTime);
    }
}
