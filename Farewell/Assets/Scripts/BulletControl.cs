using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//碰撞子弹后消失，碰撞角色后减少生命值(调用healthScript中的ApplyDamage)
//沿一定路径飞行，飞过一定距离或时间后消失
//参考：https://www.bilibili.com/video/BV1pE411n7Bg?p=20
public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_playerbullet;
    public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
