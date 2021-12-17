using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// 對話系統
/// 將需要輸出的文字利用打字效果呈現
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    [Header("對話間隔"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("畫布對話系統")]
    public GameObject goDialogue;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話完成圖示")]
    public GameObject goTip;
    [Header("對話系統")]
    public KeyCode keyDialongue = KeyCode.Mouse0;



    private void Start()
    {
        //StartCoroutine(TypeEffect());
    }

    /// <summary>
    /// 打字效果
    /// </summary>
    /// <param name="contents">想要出現對話系統的對話內容，需使用字串陣列</param>
    /// <returns></returns>

    private IEnumerator TypeEffect(string[] contents)
    {
        //更換名稱快捷鍵 Ctrl + R R
        //測試用
        //string test1 = "哈囉，你好啊";
        //string test2 = "第二段對話";
        //string[] contents = { test1, test2 };
        
        goDialogue.SetActive(true);

        for (int j = 0; j < contents.Length; j++)
        {  
            textContent.text = "";
            goTip.SetActive(false);

            for (int i = 0; i < contents[j].Length; i++)
           {
            textContent.text += contents[j][i];
            yield return new WaitForSeconds(interval);
           } 

          goTip.SetActive(true);

            while (!Input.GetKeyDown(keyDialongue))
            {
                yield return null;
            }

        }

        goDialogue.SetActive(false);
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    public void StartDialogue(string[] contents)
    {
        StartCoroutine(TypeEffect(contents));
    }

    /// <summary>
    /// 停止對話
    /// </summary>
    public void StoptDialogue()
    {
        StopAllCoroutines();
        goDialogue.SetActive(false);

    }


}
