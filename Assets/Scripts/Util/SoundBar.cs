using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBar : MonoBehaviour
{
    public AudioSource audioSource; // �Ҹ��� ������ AudioSource
    public Scrollbar SoundScrollbar; // UI ��ũ�ѹ�

    void Start()
    {
        // ��ũ�ѹ��� ���� ���� �������� ����
        //audioSource.volume = SoundScrollbar.value;

        // ��ũ�ѹ��� ���� ����� �� ȣ��� �޼��� ���
        //SoundScrollbar.onValueChanged.AddListener(OnVolumeChange);
    }

    void OnVolumeChange(float value)
    {
        // ��ũ�ѹ��� ���� ���� AudioSource ������ ����
        //audioSource.volume = value;
    }
}
