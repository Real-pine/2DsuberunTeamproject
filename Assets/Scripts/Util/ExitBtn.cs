using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBtn : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("StartScene");
    }

}
