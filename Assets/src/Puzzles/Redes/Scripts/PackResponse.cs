using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackResponse : MonoBehaviour
{
    public Transform player;
    MeshRenderer meshRenderer;
    public TextMesh txtPackage;

    void Start(){
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerRedes.reachedServer) {
            meshRenderer.enabled = true;
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, player.position.x, 0.2f),
                Mathf.Lerp(transform.position.y, player.position.y-1, 0.2f),
                transform.position.z
            );
        } else {
            meshRenderer.enabled = false;
            transform.position = new Vector3(100, -4, 1);
        }
    }
}
