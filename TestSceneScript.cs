using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneScript : MonoBehaviour
{
    public void BackToChapSelect()
    {
        SceneManager.LoadScene("ChapSelect");
    }
}