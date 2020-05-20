using UnityEngine;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class PlotManager : MonoBehaviour
{
    //public List<string> Texts = new List<string>();//要显示的文本内容列表
    //[Space(5)]
    public Text mText = null;//Text组件

    [Range(0.001f, 1.0f)]
    public float RaterLetter = 0.02f;//打字速度
    public float WaitForNext = 5f;//等待执行
    protected int CurrentTextIndex = 0;//当前显示文本的索引值
    bool click_enabled = false;
    private string[] plots;
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        if (mText == null)
            return;

        Debug.Log(Application.dataPath + "/before.txt");
        byte[] b = File.ReadAllBytes(Application.dataPath + "/before.txt");
        string s = Encoding.UTF8.GetString(b);
        plots = s.Split('\n');
        StartCoroutine(Writter(CurrentTextIndex++));

        /*if (Texts.Count < 0)
            return;*/
        //StartCoroutine(Writter(CurrentTextIndex));
    }

    /// <summary>
    /// 写
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    /// 


    IEnumerator Writter(int CurrentTextIndex)
    {
        click_enabled = false;
        mText.text = null;
        string str = plots[CurrentTextIndex];
        foreach (char letter in str.ToCharArray())
        {
            if (mText != null)
            {
                mText.text += letter;
            }
            yield return null;
            yield return new WaitForSeconds(RaterLetter);
        }
        //StopCoroutine(coroutine);
        click_enabled = true;
    }

    /*
    /// <summary>
    /// 等待下一条信息显示
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitNext()
    {
        //int CurrentTextIndex = (CurrentTextIndex + 1) % Texts.Count;
        yield return new WaitForSeconds(WaitForNext);
        mText.text = string.Empty;
        coroutine = Writter(CurrentTextIndex);
        StartCoroutine(coroutine);
    }
    */


    //关联button
    public void NextWords()
    {
        if(click_enabled)
        {
            if (CurrentTextIndex == plots.Length)
            {
                //跳转至游戏
                SceneManager.LoadScene(2);
            }
            else
            {
                //开启协程 index++
                StartCoroutine(Writter(CurrentTextIndex++));
            }
        }
    }


}
