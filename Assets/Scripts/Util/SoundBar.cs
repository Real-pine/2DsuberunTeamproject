using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBar : MonoBehaviour
{
    public Scrollbar bgmScrollbar; // BGM ���� ��ũ�ѹ�
    public Scrollbar sfxScrollbar; // SFX ���� ��ũ�ѹ�

    void Start()
    {
        // ��ũ�ѹ� �ʱ� �� ����
        bgmScrollbar.value = AudioManager.instance.bgmVolume;
        sfxScrollbar.value = AudioManager.instance.sfxVolume;

        // ��ũ�ѹ��� ���� ����� �� ȣ��� �޼��� ���
        bgmScrollbar.onValueChanged.AddListener(OnBgmVolumeChange);
        sfxScrollbar.onValueChanged.AddListener(OnSfxVolumeChange);
    }

    public void OnBgmVolumeChange(float value)
    {
        // AudioManager�� bgmVolume ����
        AudioManager.instance.bgmVolume = value;
        AudioManager.instance.bgmPlayer.volume = value; // BGM ���� ������Ʈ
    }

    public void OnSfxVolumeChange(float value)
    {
        // AudioManager�� sfxVolume ����
        AudioManager.instance.sfxVolume = value;

        // ��� SFX �÷��̾��� ���� ������Ʈ
        foreach (var sfxPlayer in AudioManager.instance.sfxPlayers)
        {
            sfxPlayer.volume = value; // SFX �÷��̾� ���� ������Ʈ
        }
    }
}
