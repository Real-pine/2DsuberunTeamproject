using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBar : MonoBehaviour
{
    public AudioSource audioSource; // 소리를 조절할 AudioSource
    public Scrollbar SoundScrollbar; // UI 스크롤바

    void Start()
    {
        // 스크롤바의 값을 현재 볼륨으로 설정
        //audioSource.volume = SoundScrollbar.value;

        // 스크롤바의 값이 변경될 때 호출될 메서드 등록
        //SoundScrollbar.onValueChanged.AddListener(OnVolumeChange);
    }

    void OnVolumeChange(float value)
    {
        // 스크롤바의 값에 따라 AudioSource 볼륨을 조절
        //audioSource.volume = value;
    }
}
