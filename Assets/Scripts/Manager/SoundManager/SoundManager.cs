using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")] //�������
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")] //ȿ����
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels; //�ѹ��� �������� ȿ���� ����ϱ����� �ʿ�
    AudioSource[] sfxPlayers;
    int channelIndex; // ���� ����ϰ� �ִ� ä���� �ε���

    public enum Sfx {  }; // �� �κп� Ŭ���߰�

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Init()
    {
        //����� �÷��̾� �ʱ�ȭ
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = true; // ������ ������ڸ��� bgm�� ����Ǵ°��� ����
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        //ȿ���� �÷��̾� �ʱ�ȭ
        GameObject sfxObject = new GameObject("SfxObject");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels]; // �迭�� ä�� ������ŭ �ʱ�ȭ

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>(); //����� �ҽ� ���� �� ����
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    public void PlayBgm(bool isplay)
    {
        if (isplay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            //int ranIndex = 0;
            //if (sfx == Sfx.ȿ���� || sfx == Sfx.ȿ����)   �ϳ��� ���尡 ���� �����϶� �������� ��� ex �ǰ����� 1,2���� 2���϶�
            //{
            //    ranIndex = Random.Range(0, 2);
            //}

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx]; // = sfxClips[(int)sfx + ranIndex]; �� ������ �߰��ߴٸ� ��� ����
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
    //AudioManager.instance.PlayBgm(true); - bgm ��� ����ÿ��� false 
    //AudioManager.instance.PlaySfx(AudioManager.Sfx.ȿ����); - ȿ�����κп� Ŭ�� �־ ���
}
