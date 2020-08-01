using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoShop : MonoBehaviour
{
    public Animator anim;
    public bool shopOpen = false;

    public void showShop()
    {
        anim.SetTrigger("showShop");
        shopOpen = true;
    }

    public void hideShop()
    {
        anim.SetTrigger("hideShop");
        shopOpen = false;
    }
}
