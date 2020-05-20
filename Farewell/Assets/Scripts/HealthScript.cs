using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;    //添加UI命名空间
using UnityEngine.AI;

//将被敌人和玩家共用的脚本,由BulletControl脚本调用其中的ApplyDamage函数
//调用UIManager的win()或lose()判断输赢
//创建角色和敌人的UI血条，并用脚本控制血条

//请参考：https://www.bilibili.com/video/BV1pE411n7Bg?p=20
//参考：https://www.bilibili.com/video/BV1pE411n7Bg?p=22
public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private Image health_Stats;


    public float health = 100f;
    public bool is_Player;

    private bool is_Dead;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;
    void Awake()
    {
        if(!is_Player)
        {
            navAgent = GetComponent<NavMeshAgent>();
            enemy_Controller = GetComponent<EnemyController>();
        }
    }
    void Start()
    {
        //HPStrip.value = HPStrip.maxValue = health;    //初始化血条     
    }


    public void ApplyDamage(float damage)
    {
        // if we died don't execute the rest of the code
        if (is_Dead)
            return;
        health -= damage;
        //HPStrip.value = health;
        Display_Healthstats(health);
        if (health<=0f)
        {
            Died();
            is_Dead = true;
        }
    }// apply damage

    public void Display_Healthstats(float healthValue)
    {
        healthValue /= 100f;
        health_Stats.fillAmount = healthValue;
    }

    void Died()
    {
        if(is_Player)
        {
            Debug.Log("player die");
            GameObject enemy = GameObject.FindWithTag("Enemy");
            enemy.GetComponent<EnemyController>().enabled = false;

            GetComponent<PlayerMovement>().enabled = false;
            //UIManager.lose();
        }
        else
        {
            Debug.Log("enemy die");
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerMovement>().enabled = false;
            //navAgent.velocity = Vector3.zero;
            //navAgent.isStopped = true;
            //navAgent.enabled = false;
            enemy_Controller.enabled = false;
            //UIManager.Win();
        }
    }
}