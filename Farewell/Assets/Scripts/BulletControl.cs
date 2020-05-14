using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//碰撞角色后减少生命值(调用healthScript中的ApplyDamage),碰撞其他消失（delete）
//沿一定路径飞行(需完成直线和Mode2)，飞过一定距离或时间后delete该物体
//参考：https://www.bilibili.com/video/BV1pE411n7Bg?p=20

public enum LaunchMode
{
    Straight, Mode2, Mode3
}

public class BulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_playerbullet;
    public float damage;
    private Rigidbody myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(float speed,Vector3 dir,LaunchMode m,float d)
    {
        if(m==LaunchMode.Straight)
        {
            damage = d;
            myBody.velocity = dir * speed;
            transform.LookAt(transform.position + myBody.velocity);
        }
    }
}
