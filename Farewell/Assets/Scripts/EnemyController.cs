using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //实现每隔一段时间发射弹幕，弹幕为prefab中的fireBullet
    // Start is called before the first frame update
    public float damage=1f;
    public float Scale=1f;
    public float SpeedOfBullet = 5f;
    public float LaunchInterval = 1f;
    public float direction_amount = 5f;
    public float dispersion_angle = 30;

    [SerializeField]
    private GameObject EnemyBullet_Prefab;
    [SerializeField]
    private Transform launch_point;
    private Camera mainCam;
    private Transform target;

    void Awake()
    {
        mainCam = Camera.main;
        target= GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        StartCoroutine(CreateBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateBullet()
    {


        for(int i=0;i<1000;i++)
        {
            Vector3 maindir = target.position - transform.position;


            //计算需要发射的角度
            Vector3 dir = maindir.normalized;
            if ((direction_amount % 2) == 1)
                dir = Quaternion.AngleAxis(-(direction_amount - 1) * dispersion_angle / 2, Vector3.up) * dir;
            else
                dir = Quaternion.AngleAxis((-(direction_amount / 2) + 0.5f) * dispersion_angle, Vector3.up) * dir;
            //朝各个方向发出
            for (int j = 0; j < direction_amount; j++)
            {
                //创建Bullet
                GameObject Bullet = Instantiate(EnemyBullet_Prefab);

                //Bullet.AddComponent<BulletControl>();

                //初始化为enemy位置
                Bullet.transform.position = launch_point.position;
                //设定大小
                Bullet.transform.localScale = Scale * Bullet.transform.localScale;
                //Debug.Log(Bullet.transform.localScale);
                //方向
                dir = Quaternion.AngleAxis(dispersion_angle, Vector3.up) * dir;
                //发射
                Bullet.GetComponent<BulletControl>().Launch(SpeedOfBullet, dir, LaunchMode.Straight, damage);
            }

            yield return new WaitForSeconds(LaunchInterval);
        }



    }
}
