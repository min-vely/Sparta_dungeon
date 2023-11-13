# 🔮 루루의 스파르타 던전 탐험기


롤 모스트 1이 룰루라 ,, 플레이어랑 아이템 다 바꿔봤습니다. 


'각 타입별로 하나의 아이템만 장착가능' 이라고 써있길래 아이템 목록은 아무거나(?) 적었습니다. 


---
## ⭐ 구현 사항


1. 필수요구사항 완료


   1-1. 필수요구사항 3 : 3-1에서 기본 아이템의 장착 여부에 따른 [E] 표시 추가 및 제거

   1-2. 필수요구사항 3-1 : 아이템 장착 개수는 무제한 허용, 장착한 아이템의 능력치는 상태 보기에 반영

   
2. 선택요구사항 2, 3, 4, 5번 완료

   
   2-1. 선택요구사항 2 : 아이템 정보를 배열로 관리 (+배열과 리스트 혼용)

   
   2-2. 선택요구사항 3 : 기본 인벤토리 아이템을 총 4개로 늘림


   2-3. 선택요구사항 4 : 아스키아트, 폰트 컬러 변경을 이용한 콘솔 꾸미기


   2-4. 선택요구사항 5 : ConsoleTables 라이브러리를 이용한 콘솔 줄 맞춤(인벤토리, 상점의 아이템에 적용)


3. 선택요구사항 7번 구현 중


   3-1. 선택요구사항 7 : 상점에서 아이템 구매완료 시 구매완료 표기, 구매한 아이템은 자동적으로 인벤토리 추가


   ❗ 기본 아이템은 장착 시 능력치가 정상적으로 표기됨.


   그러나 구매한 아이템을 장착 시 [E] 표시는 뜨지만, 장착 후 상태 보기를 할 때 능력치가 추가되지 않고 IndexOutOfRangeException이 뜨는 현상 미해결 ❗


   
---
### 🥔 1차 제출(~11.13.14:00) 이후 수정 및 개선 사항


1. 선택요구사항 7번 구현 중

   
   1-1. 선택요구사항 7 : '구매한 아이템 장착 후 상태보기 할 때 능력치가 추가되지 않고 IndexOutOfRangeException이 뜨는 현상' 해결 완료 및 능력치가 정상적으로 추가되는 것 확인


   1-2. 선택요구사항 7-1 : 상점 판매 기능 구현 중



---
### 🔗 참고
1. [룰루 나무위키](https://namu.wiki/w/%EB%A3%B0%EB%A3%A8(%EB%A6%AC%EA%B7%B8%20%EC%98%A4%EB%B8%8C%20%EB%A0%88%EC%A0%84%EB%93%9C)#s-9.1.2)
2. [롤 아이템 나무위키](https://namu.wiki/w/%EB%A6%AC%EA%B7%B8%20%EC%98%A4%EB%B8%8C%20%EB%A0%88%EC%A0%84%EB%93%9C/%EC%95%84%EC%9D%B4%ED%85%9C/%EC%A0%84%EC%84%A4#s-2.4.10)
3. [ConsoleTables 사용법](https://www.nuget.org/packages/ConsoleTables/)
