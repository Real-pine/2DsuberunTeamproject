using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBar : MonoBehaviour
{
    public Scrollbar bgmScrollbar; // BGM 조절 스크롤바
    public Scrollbar sfxScrollbar; // SFX 조절 스크롤바

    void Start()
    {
        // 스크롤바 초기 값 설정
        bgmScrollbar.value = AudioManager.instance.bgmVolume;
        sfxScrollbar.value = AudioManager.instance.sfxVolume;

        // 스크롤바의 값이 변경될 때 호출될 메서드 등록
        bgmScrollbar.onValueChanged.AddListener(OnBgmVolumeChange);
        sfxScrollbar.onValueChanged.AddListener(OnSfxVolumeChange);
    }

    public void OnBgmVolumeChange(float value)
    {
        // AudioManager의 bgmVolume 변경
        AudioManager.instance.bgmVolume = value;
        AudioManager.instance.bgmPlayer.volume = value; // BGM 볼륨 업데이트
    }

    public void OnSfxVolumeChange(float value)
    {
        // AudioManager의 sfxVolume 변경
        AudioManager.instance.sfxVolume = value;

        // 모든 SFX 플레이어의 볼륨 업데이트
        foreach (var sfxPlayer in AudioManager.instance.sfxPlayers)
        {
            sfxPlayer.volume = value; // SFX 플레이어 볼륨 업데이트
        }
    }
}
