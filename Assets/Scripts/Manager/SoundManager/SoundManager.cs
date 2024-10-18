using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")] //배경음악
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")] //효과음
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels; //한번에 여러개의 효과음 재생하기위해 필요
    AudioSource[] sfxPlayers;
    int channelIndex; // 지금 재생하고 있는 채널의 인덱스

    public enum Sfx {  }; // 이 부분에 클립추가

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
        //배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = true; // 게임이 실행되자마자 bgm이 실행되는것을 방지
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        //효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("SfxObject");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels]; // 배열을 채널 개수만큼 초기화

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>(); //오디오 소스 생성 및 저장
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
            //if (sfx == Sfx.효과음 || sfx == Sfx.효과음)   하나의 사운드가 여러 종류일때 랜덤으로 재생 ex 피격음이 1,2같이 2개일때
            //{
            //    ranIndex = Random.Range(0, 2);
            //}

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx]; // = sfxClips[(int)sfx + ranIndex]; 위 내용을 추가했다면 등식 수정
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
    //AudioManager.instance.PlayBgm(true); - bgm 재생 종료시에는 false 
    //AudioManager.instance.PlaySfx(AudioManager.Sfx.효과음); - 효과음부분에 클립 넣어서 재생
}
