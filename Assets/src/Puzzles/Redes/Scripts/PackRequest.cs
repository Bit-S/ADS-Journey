using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackRequest : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, player.position.x, 0.2f),
                Mathf.Lerp(transform.position.y, player.position.y-1, 0.2f),
                transform.position.z
            );
    }
}
