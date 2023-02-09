using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgDealtText : MonoBehaviour
{

    public Vector3 randomize = new Vector3(1.2f, 1.2f, 0);

    void Start()
    {
        Destroy(this.gameObject, 0.5f);
        transform.localPosition += new Vector3(Random.Range(-randomize.x, randomize.x), Random.Range(-randomize.y, randomize.y));

        var euler = transform.eulerAngles;
        //euler.z = Random.Range(0.0f, 360.0f);
        euler.z = Random.Range(-60f, 60.0f);
        transform.eulerAngles = euler;

    }


}
