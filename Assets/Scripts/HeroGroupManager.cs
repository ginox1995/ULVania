using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGroupManager : MonoBehaviour
{
    public Transform hero;
    public Transform gost;
    public float switchRate;


    float nextSwitch;
    GameObject srHero;
    GameObject srGost;
    // Start is called before the first frame update
    void Start()
    {
        srHero = hero.GetComponent<GameObject>();
        srGost = gost.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && Time.time > nextSwitch)
        {
            nextSwitch = Time.time + switchRate;
            switchHeroRender();
        }

    }

    void switchHeroRender()
    {
        srHero.enabled = false;
        srGost.enabled = true;
    }

}
