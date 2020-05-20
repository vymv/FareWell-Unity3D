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
    private LineRenderer laserLine;
    public GameObject t1;    //开始位置  
    public GameObject t2;     //结束位置  
    


    void Awake()
    {
        float deactivate_Timer = 10f;
        myBody = GetComponent<Rigidbody>();
        Destroy(this.gameObject, deactivate_Timer);
        //Invoke("delete", deactivate_Timer);//经过30s后自动deactivate
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(float speed, Vector3 dir, LaunchMode m, float d)
    {
        if (m == LaunchMode.Straight)
        {
            damage = d;
            myBody.velocity = dir * speed;
            transform.LookAt(transform.position + myBody.velocity);
        }
        else if (m == LaunchMode.Mode2)
        {
            damage = d;
            //两者中心点  
            Vector3 center = (t1.transform.position + t2.transform.position) * 0.5f;

            center -= new Vector3(0, 1, 0);

            Vector3 start = t1.transform.position - center;
            Vector3 end = t2.transform.position - center;

            //弧形插值  
            transform.position = Vector3.Slerp(start, end, Time.time);
            transform.position += center;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        //敌人的子弹
        Debug.Log("me"+this.gameObject.name+"collider:" + other.gameObject.name);
        if (!is_playerbullet)
        {
            if (other.gameObject.tag=="PlayerBullet")
            {

                Debug.Log("两方子弹碰撞：" + this.gameObject.name);
                Destroy(this.gameObject);
               
            }
            else if(other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<HealthScript>().ApplyDamage(damage);
                Debug.Log("碰撞player销毁" + this.gameObject.name);
                Destroy(this.gameObject);
            }
            else if (other.gameObject.tag == "Terrain")
            {
                Destroy(this.gameObject);
            }
        }
        //玩家的子弹
        else
        {
            if (other.gameObject.tag == "EnemyBullet")
            {
                Debug.Log("两方子弹碰撞：" + this.gameObject.name);
                Destroy(this.gameObject);
            }
            else if(other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<HealthScript>().ApplyDamage(damage);
                Debug.Log("碰撞enemy销毁" + this.gameObject.name);
                Destroy(this.gameObject);
            }
            else if (other.gameObject.tag == "Terrain")
            {
                Destroy(this.gameObject);
            }
        }
    }

}