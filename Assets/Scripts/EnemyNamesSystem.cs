using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNamesSystem : MonoBehaviour
{
    public string[] names;
    public string[] adjective1;
    public string[] attribute_adj;
    public string[] attribute;


    public string randomName()
    {
        int a, b, c, d;
        string name;

        a = Random.Range(0, names.Length);
        b = Random.Range(0, adjective1.Length);
        c = Random.Range(0, attribute_adj.Length);
        d = Random.Range(0, attribute.Length);

        name = "The " + adjective1[b] + " " + names[a] + " of the " + attribute_adj[c] + " " + attribute[d];

        return name;

    }


}
