using System.Collections;
using System.Collections.Generic;
using UnityEngine;


////实现点击鼠标，从屏幕正中心向相机朝向发出弹幕的效果（弹幕请使用prefabs中的water bullet）
//代码思路参考：https://www.bilibili.com/video/BV1pE411n7Bg?p=14
public class Weaponhandler : MonoBehaviour
{
    

    private Animator anim;
    public float damage=2f;
    // Update is called once per frame
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        shootAnimation();
    }

    void shootAnimation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Shoot");
            LaunchBullet();
        }
    }

    void LaunchBullet()
    {
        //新建一个子弹并发出
    }

}
