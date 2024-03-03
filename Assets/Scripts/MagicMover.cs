using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MagicMover : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Magic");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new UnityEngine.Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

    }
}
