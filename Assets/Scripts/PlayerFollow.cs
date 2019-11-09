using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    public Vector3 pOffset;

    // Start is called before the first frame update
    void Start()
    {
        // AdController.instance.showBannerAd();
        offset = transform.position - player.transform.position + pOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
