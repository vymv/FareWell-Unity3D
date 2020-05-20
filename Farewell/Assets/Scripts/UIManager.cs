using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//场景间的跳转（LoadScene），主界面，星球选择界面，主战场界面button
//点击鼠标阅读剧情，在游戏前应该事先绑定剧情文档文件到TxtFile中
//游戏进度的保存和重载属性 lv exp gold smallTimer bigTimer（可以更改）
//scene0为菜单界面，scene1星球选择界面， scene2游戏主战场界面（可选择开始游戏或继续游戏）

public class UIManager : MonoBehaviour
{
    //属性
    public int lv = 0;
    public int exp = 0;
    public int gold = 1500;
    public const int bigCountdown = 120;
    public const int smallCountdown = 60;
    public float bigTimer = bigCountdown;
    public float smallTimer = smallCountdown;//计时器
    //属性可以根据对应内容修改，这里只是框架
    public Text PlotText;//剧情文本框
    public TextAsset TxtFile; //建立TextAsset，读取文本内容
    public int i = 0;//控制剧情进度
    public GameObject GameWin;//游戏胜利标志
    public GameObject GameLose;//游戏失败标志
    public GameObject target;
    public int speed = 5;
    public void NewGame()//开始游戏（重新开始）主战场界面
    {
        PlayerPrefs.DeleteKey("gold");//删除保存的属性
        PlayerPrefs.DeleteKey("lv");
        PlayerPrefs.DeleteKey("exp");
        PlayerPrefs.DeleteKey("scd");
        PlayerPrefs.DeleteKey("bcd");
        SceneManager.LoadScene(3);
    }
    public void OldGame()//继续游戏主战场界面
    {
        gold = PlayerPrefs.GetInt("gold", gold);//开始读取游戏存储
        lv = PlayerPrefs.GetInt("lv", lv);
        exp = PlayerPrefs.GetInt("exp", exp);
        smallTimer = PlayerPrefs.GetFloat("scd", smallCountdown);
        bigTimer = PlayerPrefs.GetFloat("bcd", bigCountdown);
        SceneManager.LoadScene(2);//切换（加载）游戏场景
    }
    public void SelectGame()//星球选择界面
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnGame()// 返回游戏
    {
        //保存游戏属性设置
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("lv", lv);
        PlayerPrefs.SetFloat("scd", smallTimer);
        PlayerPrefs.SetFloat("bcd", bigTimer);
        PlayerPrefs.SetInt("exp", exp);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);//回到菜单界面
    }
    //上述四个函数分别挂载在对应button上面
    public void OnCloseButton()//退出游戏
    {
        Application.Quit();
    }
    public void Plot()//enter点击阅读剧情
    {
        string[] Mytxt = TxtFile.text.Split('\n'); //用来存放动态读取的剧情文本内容
        if (Input.GetKeyDown(KeyCode.KeypadEnter))//监测鼠标左键点击
        {
            foreach (string str in Mytxt)//逐行显示
            {
                PlotText.text = str;  // 文本框显示剧情
            }
        }
    }
    public void Win()
    {
        GameWin.SetActive(true);//展示胜利标志
    }
    public void lose()
    {
        GameLose.SetActive(true);//展示失败标志
    }
    public void SelectPlantRight()//星球选择（火星）
    {
        float step = speed * Time.deltaTime;
        while (target.transform.localPosition != new Vector3(-520, 0, 0))
            target.transform.localPosition = Vector3.MoveTowards(target.transform.localPosition, new Vector3(-520, 0, 0), step);
    }
    public void SelectPlantLeft()//星球选择（水星）
    {
        float step = speed * Time.deltaTime;
        while (target.transform.localPosition != new Vector3(0, 0, 0))
            target.transform.localPosition = Vector3.MoveTowards(target.transform.localPosition, new Vector3(0, 0, 0), step);
    }
}