using UnityEngine;
using UnityEngine.SceneManagement;  // �ޥ� �����޲z API

public class SceneControl : MonoBehaviour
{
  public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void Quit()
    {
        Application.Quit();       // ���}���ε{��
        print("�����C��");
    }
}

