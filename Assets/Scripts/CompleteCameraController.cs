using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

    void Start () 
    {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void LateUpdate () 
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset,Time.deltaTime*5f);
    }
}
