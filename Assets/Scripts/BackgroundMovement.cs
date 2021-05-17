using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField]
    private Transform hero;

    private bool follow = true;

    private void Update()
    {
        if (follow)
        {
            transform.position = new Vector3(hero.position.x, transform.position.y, 0f);
        }
    }

    public void Follow()
    {
        follow = true;
    }
    public void UnFollow()
    {
        follow = false;
    }
}
