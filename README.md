# 2D-Platformer
- 2D-Platformer project for 2024 CIEN tutorial 2024.07 ~ 2024.08 
- 개발 노트: https://www.notion.so/824b43e110874251adcacf3042a255a3?v=277d33da217744a49c333ea9d17a2e35&p=a5f1ba6ef54f4fec91e88482c6c7f379&pm=s

## 초기 베이스
- 유니티 2D 플랫포머 튜토리얼을 베이스로 개발
- 베이스가 된 시스템: 플레이어 물리 엔진/Scene 기초 설정/인게임 UI
<img src="https://github.com/user-attachments/assets/1fb7932c-9f56-42c3-bda5-442e72738450" width="680" height="415"/>
<img src="https://github.com/user-attachments/assets/6b3a194b-c168-41d3-91c1-3a7fca216c3e" width="680" height="415"/>

## 기초 개발
- 플레이어 물리 엔진 개선
- Scene에 적용할 기본 시스템(2단 점프, 상하 이동 플랫폼, 상호작용 시스템, 이동 키 교체) 개발
  - 2단 점프
    - 기존의 플레이어 물리 엔진에 좌표 이동 코드를 추가하여 개발
    - 개발 시점에서는 사용하지 않았지만 차후 사용이 가능하도록 함
  <img src="https://github.com/user-attachments/assets/0c9948c2-7158-4b20-b4ad-e9842b17a2be" width="540" height="360"/>
  
  - 상하 이동 플랫폼
    -  충돌 부분을 중심으로 상하로 이동하기 때문에 걸치면 자동으로 올라가는 버그가 존재하지만 당시에는 해결하지 못함
  <img src="https://github.com/user-attachments/assets/85df325a-3bd5-4541-871f-653369bedba7" width="540" height="360"/>
  
  - 상호작용 시스템
    - 아이템 획득/오브젝트 상호작용/커스텀 이벤트 트리거로서 개발
    - 결과적으로 커스텀 이벤트 트리거로서만 사용, 다른 기능은 사용하지 못함
  <img src="https://github.com/user-attachments/assets/91eb94b2-88f0-4ecf-a30d-9f1786f51263" width="540" height="360"/>

## 베이스 개발

## 시스템 개발

## UI 개발

## 마무리 및 디버그

## 기타
- 총기 시스템만 다른 팀원이 개발
- 프리팹을 적극적으로 사용하지 않은 것을 후회(개발 시간을 크게 단축시킬 수 있었음)
