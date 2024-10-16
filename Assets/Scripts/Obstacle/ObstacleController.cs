using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public ObstacleInfo info;
    public ObstacleInfo Info 
    { 
        get
        {
            if (info != null)
            {
                return info;
            }
            else
            {
                info = new ObstacleInfo();
                return info;
            }
        }
    }
}
