# 포르댕댕 도시질주

## 📖 목차

1. [프로젝트 소개](#프로젝트-소개)
2. [팀소개](#팀소개)
3. [개발기간](#개발기간)
4. [팀노션](#팀노션)
5. [기술스택](#기술스택)
6. [와이어프레임](#와이어프레임)
7. [클래스다이어그램](#클래스다이어그램)
8. [Trouble Shooting](#trouble-shooting)

## 👨‍🏫 프로젝트 소개

포르댕댕 도시질주는 SUBERUNKER게임을 오마쥬해 재구성해본 게임입니다.

'기본아이디어는 떨어지는 물체를 피한다' 이지만 맵을 동시에 스크롤함으로써
캐릭터가 앞으로 속도감있게 나아간다라는 느낌을 주면서 물체를 피하는것이 핵심아이디어입니다.

![인게임영상](https://i.ibb.co/vL7hsn3/2024-10-21-22-53-33.gif)

[플레이영상-유튜브](https://youtu.be/YJ_QoOSKQsk)

## 👨🏻‍🤝‍👨🏻 팀소개
|  |이름|깃허브|
|---|---|:---|
|팀장|박참솔|https://github.com/Real-pine|
|팀원|이태훈|https://github.com/xoxohoon01|
|팀원|김찬우|https://github.com/simple2126|
|팀원|이호영|https://github.com/leecoading|
|팀원|지현민|https://github.com/LackDDD|

## 개발기간

___2024. 10. 15 ~ 2024. 10. 22___

## 📄팀 노션(TeamNotion)

[팀노션](https://bush-wineberry-088.notion.site/4-118824ff462c80fb94b1e53c9c083bb5?pvs=4)

## 기술스택

- Language: C#
- IDE: Visual Studio
- GameEngine: Unity - 2022.3.17f1

## 와이어프레임

![와이어프레임](https://i.ibb.co/rFMbBQm/image.png)

## 클래스다이어그램

> UI
> 
> ![UI1](https://i.ibb.co/Rb3NWM0/UI-drawio-1.png)
> 
> ![UI2](https://i.ibb.co/ckxmspw/drawio.png)
>
> ---
> 인게임
> 
> ![GamePlay](https://i.ibb.co/TcVCCmm/drawio-3.png)

## 🚀Trouble Shooting

<details>
<summary>물리 연산시 계단 현상? 버퍼링 현상? 발생</summary>
<div markdown="1">
  
  장애물은 rigidbody.velocity 값을 변경하여 위에서 아래로 내려오도록 설정했으며, FixedUpdate에서 이를 처리했습니다. 
  
  하지만 FixedUpdate는 고정된 시간마다 호출되며, 사람 눈으로 봤을 때 자연스럽게 보이기 위해 1초에 60프레임이 되어야합니다. 
  
  기본설정값에 의해 FixedUpdate는 50프레임이며, 이 때문에 부자연스러워 보였습니다. 
  
  Project Setting에서 FixedTimeStep값을 조절하여 FixedUpdate가 호출되는 빈도를 높여 자연스럽게 보이도록 수정하여 해결했습니다.
</div>
</details>

<details>
<summary>장애물 생성 빈도수 설정 이슈</summary>
<div markdown="1">
  
  난이도 구분을 int형인 1, 2, 3으로 구분지었으며 수가 높을수록 어려운 난이도입니다. 장애물 생성 딜레이를 (1 / 난이도)의 값으로 설정했습니다. 
  
  float delay = ( 1 / gameDifficulty )의 형태였습니다.
  
  이때 gameDifficulty는 int형이기 때문에 반환값은 int형이 되어버렸습니다.
  
  int형 나누기 int형의 경우 float형이 아닌 int형으로 반환되며 나머지는 버려집니다.
 
  그래서 ( 1 / gameDifficulty ) 식에서 1을 float형으로 바꿔주었습니다.
 
  float delay = (1.0f / gameDifficulty)
</div>
</details>

<details>
<summary>스코어링 이슈</summary>
<div markdown="1">
  
  이슈는 두 가지입니다.
  
  1. 로컬멀티플레이 중 먼저 죽은 플레이어의 스코어가 계속해서 올라가는 현상
 
  2. 게임오버 시 다시하기를 선택하면 전판스코어가 이어져서 올라가는 현상



  1번문제의 경우
  
  SettingPlayerScore클래스에서 isScoring이란 bool값을 추가한 뒤 true로 초기화.
 
  저 값을 false로 만드는 메서드를 작성.
  
  hp<=0를 판별하고 게임매니저에서 OnPlayerDeath를 호출하는 메서드 HitCharacter()에
  
  캐릭터 오브젝트를 파괴하고, isScoring을 false로 만드는 메서드를 호출문 추가
  
  그리고 Update()에서 SetPlayerScore() 바로 호출하지않고
 
  if(isScoring)작성해서 호출기준을 변경해서 문제해결



  2번문제의 경우
 
  다시하기는 단순히 씬매니저로 게임씬을 호출하는 것임을 인지.
  
  그래서 playerScore를 초기화시키는 함수 작성 후 Start()에 Initialize함수 배치
  
  항상 씬을 새로 불러올때면 스코어를 0으로 초기화 시키는 것으로 문제 해결
</div>
</details>

