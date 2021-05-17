using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGroupManager : MonoBehaviour
{
    public Transform hero;
    public Transform gost;
    public float switchRate;


    float nextSwitch;
    SpriteRenderer srHero;
    SpriteRenderer srGost;
    // Start is called before the first frame update
    void Start()
    {
        srHero = hero.GetComponent<SpriteRenderer>();
        srGost = gost.GetComponent<SpriteRenderer>();
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
        srHero.enabled = !srHero.isVisible;
        srGost.enabled = !srGost.isVisible;
    }

}
