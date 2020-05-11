using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//将被敌人和玩家共用的脚本,由BulletControl脚本调用其中的ApplyDamage函数
//调用UIManager的win()或lose()判断输赢
//创建角色和敌人的UI血条，并用脚本控制血条

//请参考：https://www.bilibili.com/video/BV1pE411n7Bg?p=20
//参考：https://www.bilibili.com/video/BV1pE411n7Bg?p=22
public class HealthScript : MonoBehaviour
{
    
    public float health=100f;
    public bool is_player;

    private bool is_dead;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        // if we died don't execute the rest of the code
        if (is_dead)
            return;
        health -= damage;
    }// apply damage
}
