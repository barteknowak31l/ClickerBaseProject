using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Enemy enemy;
    public SpriteRenderer sprite;
    public SpriteRenderer child;

    private void Update()
    {
        //child.sprite = sprite.sprite;
    }

    void transitionEnd()
    {
        //enemy.resetEnemy();
    }
}
