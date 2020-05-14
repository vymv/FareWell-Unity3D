using System.Collections;
using System.Collections.Generic;
using UnityEngine;


////实现点击鼠标，从屏幕正中心向相机朝向发出弹幕的效果（弹幕请使用prefabs中的water bullet）
//代码思路参考：https://www.bilibili.com/video/BV1pE411n7Bg?p=14
public class Weaponhandler : MonoBehaviour
{
    public float SpeedOfBullet = 5f;
    public float damage = 2f;
    public float launch_ahead_length = 5f;
    public float Scale = 1f;

    private Animator anim;
    private Camera mainCam;
    [SerializeField]
    private GameObject PlayerBullet_Prefab;

    void Awake()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
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
        GameObject Bullet = Instantiate(PlayerBullet_Prefab);
        //初始化为相机位置
        Bullet.transform.position = mainCam.transform.position;
        Bullet.transform.position += mainCam.transform.forward * launch_ahead_length;
        //设置大小
        Bullet.transform.localScale = Scale * Bullet.transform.localScale;
        //方向
        Vector3 dir = mainCam.transform.forward;
        //发射
        Bullet.GetComponent<BulletControl>().Launch(SpeedOfBullet, dir, LaunchMode.Straight, damage);

    }

}
