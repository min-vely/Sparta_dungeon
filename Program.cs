using System.Linq;
using System.Runtime.CompilerServices;
using ConsoleTables;

internal class Program
{
    private static Character player;

    // 아이템 장착 정보 유지용 리스트
    private static List<int> equippedItems = new List<int>();
    // 상점용 구매 아이템 리스트
    private static List<int> boughtItems = new List<int>();
    // 상점용 판매 아이템 리스트
    private static List<int> soldItems = new List<int>();
    // 아이템을 판매할 때 판매된 아이템을 저장할 리스트
    private static List<int> soldItemsIndexes = new List<int>();

    // 기존의 items 배열 대신 List<Items>를 사용
    private static List<Items> items = new List<Items>();
    // 기존의 상점용 아이템 배열 storeItems 대신 리스트 사용
    private static List<StoreItems> storeItems = new List<StoreItems>();

    static Random random = new Random();

    // 캐릭터, 인벤토리 아이템, 상점 아이템 정보
    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅(이름, 직업, 레벨, 공격력, 방어력, 체력, 돈)
        player = new Character("루루", "서포터", 1, 47, 26, 595, 15000);

        // 여긴 아이템 1 = 인덱스 0번!!!!!
        // 기본 보유 중인 아이템 정보 세팅(배열 -> 리스트로 변경)
        items.Add(new Items("존야의 모래시계", "방어력", 45, "띵 - ", 1500));
        items.Add(new Items("구인수의 격노검", "공격력", 30, "AD룰루 필수템", 1600));
        items.Add(new Items("몰락한 왕의 검", "공격력", 40, "체력 비례 데미지", 1600));
        items.Add(new Items("부서진 여왕의 왕관", "체력", 250, "챔피언 보호 효과", 1400));

        // 상점용 아이템 정보 세팅(배열 -> 리스트로 변경) 
        storeItems.Add(new StoreItems("스태틱의 단검", "공격력", 50, "찌릿찌릿", 1500));
        storeItems.Add(new StoreItems("강철심장", "체력", 800, "깡!", 1600));
        storeItems.Add(new StoreItems("가고일 돌갑옷", "방어력", 60, "룰루로 이걸 왜 삼", 1600));
    }

    // 콘솔 들어가면 메인으로 뜨는 화면
    static void DisplayGameIntro()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다. >ㅅ< ♡♡ °˚");
        Console.ResetColor();
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("|　　|　 | 　 |     |　   |　 |");
        Console.WriteLine("|　　|　 | 　☆     |　   |　 |");
        Console.WriteLine("|　　|　 * 　 　    *     |　 |");
        Console.WriteLine("| 　★ 　　　 　 　   　 ★　 |");
        Console.WriteLine("☆ 　　 　　　 　 　  　　   ☆");
        Console.ResetColor();
        Console.WriteLine();


        Console.WriteLine("┻┳ |");
        Console.WriteLine("┳┻ |∧__∧");
        Console.WriteLine("┻┳ |o _ o)");
        Console.WriteLine("┳┻ |⊂ /");
        Console.WriteLine("┻┳ | Ｊ");

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("┏━━━━━━━━━━━━━━━━━━┓");
        Console.WriteLine("┃  보라색 맛 났어!!┃");
        Console.WriteLine("┗━━━━━━━━━━━━━━━━━━┛");
        Console.ResetColor();


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine("4. 던전입장");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(1, 4);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;
            case 2:
                DisplayInventory();
                break;
            case 3:
                DisplayStore();
                break;
            case 4:
                DisplayDungeon();
                break;
        }
    }

    // 상태보기 화면
    static void DisplayMyInfo()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("상태보기");
        Console.ResetColor();
        Console.WriteLine("캐릭터의 정보를 표시합니다.");
        Console.WriteLine();

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("     ###               ###    ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("     ###      ###  ##  ###      ###  ## ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("     ###      ###  ##  ###      ###  ## ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("     ###      ###  ##  ###      ###  ## ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("     ###      ###  ##  ###      ###  ## ");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("     #######   #####   #######   #####  ");
        Console.ResetColor();
        Console.WriteLine();




        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name} ( {player.Job} )");

        // 장착한 아이템이 하나도 없다면
        if (equippedItems.Count == 0)
        {
            // 기본 능력치 출력
            Console.WriteLine($"공격력 : {player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
        }
        // 장착한 아이템이 하나 이상 존재한다면
        else
        {
            int bonusAtk = 0;
            int bonusDef = 0;
            int bonusHp = 0;

            // 장착한 아이템 리스트에 1~4번이 들어가 있다면
            foreach (int itemIndex in equippedItems)
            {
                // 아이템 인덱스로 실제 아이템을 가져옴
                Items equippedItem = items[itemIndex];

                // 아이템으로 얻은 능력치를 계산
                if (equippedItem.AbilityName == "공격력")
                {
                    bonusAtk += equippedItem.AbilityValue;
                }
                else if (equippedItem.AbilityName == "방어력")
                {
                    bonusDef += equippedItem.AbilityValue;
                }
                else if (equippedItem.AbilityName == "체력")
                {
                    bonusHp += equippedItem.AbilityValue;
                }
            }

            // 아이템으로 얻은 능력치가 0보다 큰 경우에만 표시
            if (bonusAtk > 0)
            {
                Console.WriteLine($"공격력 : {player.Atk + bonusAtk} (+{bonusAtk})");
            }
            // 공격력 아이템을 장착하지 않았다면 기본 능력치 표시
            else
            {
                Console.WriteLine($"공격력 : {player.Atk}");
            }
            if (bonusDef > 0)
            {
                Console.WriteLine($"방어력 : {player.Def + bonusDef} (+{bonusDef})");
            }
            else
            {
                Console.WriteLine($"방어력 : {player.Def}");
            }
            if (bonusHp > 0)
            {
                Console.WriteLine($"체력 : {player.Hp + bonusHp} (+{bonusHp})");
            }
            else
            {
                Console.WriteLine($"체력 : {player.Hp}");
            }
        }

        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요");
        Console.ResetColor();

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    // 인벤토리 화면
    static void DisplayInventory()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("인벤토리");
        Console.ResetColor();
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[아이템 목록]");
        Console.ResetColor();

        var table = new ConsoleTable("아이템명", "효과", "아이템 설명");

        // 모든 아이템 목록을 표시 (기존 보유 아이템과 상점에서 구매한 아이템)
        for (int i = 0; i < items.Count; i++)
        {
            table.AddRow($"- {(items[i].IsEquipped ? "[E]" : "")}{items[i].ItemName}", $"{items[i].AbilityName} +{items[i].AbilityValue}", $"{items[i].ItemInfo}");
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("2. 아이템 정렬");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, 2);

        if (input == 0)
        {
            DisplayGameIntro();
            return;
        }
        if (input == 1)
        {
            EquipItems();
            return;
        }
        if (input == 2)
        {
            OrderItems();
            return;
        }
    }

    //장착 관리 화면
    static void EquipItems()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("인벤토리 - 장착 관리");
        Console.ResetColor();
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[아이템 목록]");
        Console.ResetColor();

        var table = new ConsoleTable("아이템명", "효과", "아이템 설명");

        // 기존 보유 아이템
        for (int i = 0; i < items.Count; i++)
        {
            table.AddRow($"- {i + 1} {(items[i].IsEquipped ? "[E]" : "")}{items[i].ItemName}", $"{items[i].AbilityName} +{items[i].AbilityValue}", $"{items[i].ItemInfo}");
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, items.Count);

        if (input == 0)
        {
            DisplayGameIntro();
            return;
        }
        // 사용자 입력값에서 1을 뺴서 아이템의 인덱스로 변환
        int itemIndex = input - 1;
        ItemEquipped(equippedItems, itemIndex, items[itemIndex]);
        EquipItems();
    }

    // 장착한 아이템 리스트에 추가/삭제
    static void ItemEquipped(List<int> equippedItems, int itemNum, Items item)
    {
        if (equippedItems.Contains(itemNum))
        {
            // 이미 해당 아이템이 장착되어 있는 경우, 아이템을 장착 해제
            item.IsEquipped = false;
            equippedItems.Remove(itemNum);
        }
        else
        {
            // 이미 같은 종류의 능력을 가진 아이템이 장착되어 있는지 확인
            foreach (int equippedIndex in equippedItems)
            {
                Items equippedItem = items[equippedIndex];
                if (equippedItem.AbilityName == item.AbilityName)
                {
                    // 이미 해당 종류의 능력을 가진 아이템이 장착되어 있으므로 장착 불가
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("이미 같은 종류의 능력을 가진 아이템이 장착되어 있습니다. 2초 후 인벤토리 화면으로 돌아갑니다.");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    DisplayInventory();
                    return;
                }
            }
            item.IsEquipped = true;
            equippedItems.Add(itemNum);
        }
    }

    static void OrderItems()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("인벤토리 - 아이템 정렬");
        Console.ResetColor();
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[아이템 목록]");
        Console.ResetColor();

        var table = new ConsoleTable("아이템명", "효과", "아이템 설명");

        // 모든 아이템 목록을 표시 (기존 보유 아이템과 상점에서 구매한 아이템)
        for (int i = 0; i < items.Count; i++)
        {
            table.AddRow($"- {(items[i].IsEquipped ? "[E]" : "")}{items[i].ItemName}", $"{items[i].AbilityName} +{items[i].AbilityValue}", $"{items[i].ItemInfo}");
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("1. 아이템명 가나다순");
        Console.WriteLine("2. 장착순");
        Console.WriteLine("3. 공격력");
        Console.WriteLine("4. 방어력");
        Console.WriteLine("5. 체력");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, 5);

        if (input == 0)
        {
            DisplayGameIntro();
            return;
        }
        if (input == 1)
        {
            OrderItemsByName();
            return;
        }
        if (input == 2)
        {
            OrderItemsByEquipped();
            return;
        }
        if (input == 3)
        {
            OrderItemsByAbility("공격력");
        }
        if (input == 4)
        {
            OrderItemsByAbility("방어력");
        }
        if (input == 5)
        {
            OrderItemsByAbility("체력");
        }
    }

    // 아이템 가나다순 정렬
    static void OrderItemsByName()
    {
        items.Sort((item1, item2) => item1.ItemName.CompareTo(item2.ItemName));
        DisplayInventory();
    }

    // 아이템 장착순 정렬
    static void OrderItemsByEquipped()
    {
        items.Sort((item1, item2) =>
        {
            bool equipped1 = item1.IsEquipped;
            bool equipped2 = item2.IsEquipped;

            if (equipped1 && !equipped2)
            {
                return -1;
            }
            else if (!equipped1 && equipped2)
            {
                return 1;
            }
            else
            {
                return item1.ItemName.CompareTo(item2.ItemName);
            }
        });
        DisplayInventory();
    }

    // 아이템 능력치순 정렬
    static void OrderItemsByAbility(string statName)
    {
        items.Sort((item1, item2) =>
        {
            if (item1.AbilityName == statName && item2.AbilityName != statName)
            {
                return -1;
            }
            else if (item1.AbilityName != statName && item2.AbilityName == statName)
            {
                return 1;
            }
            else
            {
                // 내림차순 정렬
                int result = item2.AbilityValue.CompareTo(item1.AbilityValue);
                if (result == 0)
                {
                    return item1.ItemName.CompareTo(item2.ItemName);
                }
                return result;
            }
        });
        DisplayInventory();
    }



    // 상점 화면
    static void DisplayStore()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("상점");
        Console.ResetColor();
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[보유 골드]");
        Console.ResetColor();
        Console.WriteLine($"{player.Gold} G");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[아이템 목록]");
        Console.ResetColor();

        var table = new ConsoleTable("아이템명", "효과", "아이템 설명", "가격");

        for (int i = 0; i < storeItems.Count; i++)
        {
            // 아이템 구매 여부 확인
            string priceOrSoldOut = boughtItems.Contains(i) ? "구매완료" : $"{storeItems[i].Gold}";
            table.AddRow($"- {storeItems[i].ItemName}", $"{storeItems[i].AbilityName} +{storeItems[i].AbilityValue}", $"{storeItems[i].ItemInfo}", priceOrSoldOut);
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("2. 아이템 판매");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, 2);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                Store(boughtItems);
                break;
            case 2:
                SellStore();
                break;
        }
    }

    // 상점의 아이템 구매 화면
    static void Store(List<int> boughtItems)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("상점 - 아이템 구매");
        Console.ResetColor();
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[보유 골드]");
        Console.ResetColor();
        Console.WriteLine($"{player.Gold} G");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[아이템 목록]");
        Console.ResetColor();

        var table = new ConsoleTable("아이템명", "효과", "아이템 설명", "가격");

        for (int i = 0; i < storeItems.Count; i++)
        {
            // 아이템 구매 여부 확인
            string priceOrSoldOut = boughtItems.Contains(i) ? "구매완료" : $"{storeItems[i].Gold}";
            table.AddRow($"- {i + 1} {storeItems[i].ItemName}", $"{storeItems[i].AbilityName} +{storeItems[i].AbilityValue}", $"{storeItems[i].ItemInfo}", priceOrSoldOut);
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, storeItems.Count);

        if (input == 0)
        {
            DisplayGameIntro();
            return;
        }

        int itemIndex = input - 1;
        StoreItems selectedItem = storeItems[itemIndex];

        // 이미 구매한 아이템인지 확인
        if (boughtItems.Contains(itemIndex))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("이미 구매한 아이템입니다. 2초 후 구매 창으로 돌아갑니다.");
            Console.ResetColor();
            Thread.Sleep(2000);
            Store(boughtItems);
        }
        // 보유 골드가 아이템 가격보다 적다면
        else if (player.Gold < selectedItem.Gold)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("보유 골드가 부족해요 ㅠㅅㅠ 2초 후 구매 창으로 돌아갑니다.");
            Console.ResetColor();
            Thread.Sleep(2000);
            Store(boughtItems);
        }
        else
        {
            Console.WriteLine("구매 완료! 2초 후 구매 창으로 돌아갑니다.");
            // 아이템 구매 시 골드 차감
            player.Gold -= selectedItem.Gold;
            boughtItems.Add(itemIndex);

            // 구매한 아이템을 items 리스트에 추가
            Items purchasedItem = new Items(selectedItem.ItemName, selectedItem.AbilityName, selectedItem.AbilityValue, selectedItem.ItemInfo, selectedItem.Gold);
            items.Add(purchasedItem);
            Thread.Sleep(2000);
            Store(boughtItems);
        }
    }

    // 상점의 아이템 판매 화면
    static void SellStore()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("상점 - 아이템 판매");
        Console.ResetColor();
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[보유 골드]");
        Console.ResetColor();
        Console.WriteLine($"{player.Gold} G");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[아이템 목록]");
        Console.ResetColor();

        var table = new ConsoleTable("아이템명", "효과", "아이템 설명", "판매 가격");

        for (int i = 0; i < items.Count; i++)
        {
            // 아이템 판매 여부 확인
            if (!soldItemsIndexes.Contains(i))
            {
                string priceOrSoldOut = (items[i] != null) ? (items[i].Gold * 85 / 100).ToString() : "판매완료"; // 아이템 가격의 85%
                table.AddRow($"- {i + 1} {items[i].ItemName}", $"{items[i].AbilityName} +{items[i].AbilityValue}", $"{items[i].ItemInfo}", priceOrSoldOut);
            }
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, items.Count);

        if (input == 0)
        {
            DisplayGameIntro();
            return;
        }

        int itemIndex = input - 1;

        // 이미 판매한 아이템인지 확인
        if (soldItemsIndexes.Contains(itemIndex))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("이미 판매한 아이템입니다. 2초 후 판매 창으로 돌아갑니다.");
            Console.ResetColor();
            Thread.Sleep(2000);
            SellStore();
        }
        else
        {
            // 아이템 판매 시 골드 얻음
            int sellPrice = items[itemIndex].Gold * 85 / 100; // 아이템 가격의 85%
            player.Gold += sellPrice;

            // 판매된 아이템 인덱스를 저장
            //soldItemsIndexes.Add(itemIndex);

            // 'items' 목록과 관련된 리스트에서 아이템 삭제
            items.RemoveAt(itemIndex);
            equippedItems.Remove(itemIndex); // 장착한 아이템 목록에서도 삭제

            Console.WriteLine($"아이템 판매 완료! {sellPrice} G를 얻었습니다. 2초 후 판매 창으로 돌아갑니다.");
            Thread.Sleep(2000);
            SellStore();
        }
    }

    // 난이도에 따른 던전 입장 화면
    static void DisplayDungeon()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("던전입장");
        Console.ResetColor();
        Console.WriteLine("던전 클리어는 랜덤한 확률로 가능합니다.");
        Console.WriteLine();
        Console.WriteLine("1. 쉬운 던전     | 방어력 25 이상 권장");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                LoadDungeon();
                break;
        }
    }

    // 던전 진행 중 화면
    static void LoadDungeon()
    {
        Console.Clear();
        Console.WriteLine(".　　 　 던\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　 　 전\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　　　  을\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　　　 　 탐\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　　　　　 험\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　　 　　　 하\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　　　　　 는\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　　 　　중\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　　　 。\n");
        Thread.Sleep(500);
        Console.WriteLine("　　　　　♡\n");
        Thread.Sleep(500);
        Console.WriteLine("(/●'o'●)/\n");
        Thread.Sleep(1500);

        if (player.Def >= 25)
        {
            ClearDungeon();
        }
        else // 던전 권장 방어력보다 낮은 경우
        {
            int randomValue = random.Next(100);
            // 60% 확률로 던전 클리어
            if (randomValue < 60)
            {
                ClearDungeon();
            }
            else
            {
                FailDungeon();
            }
        }
    }

    // 던전 클리어 시 화면
    static void ClearDungeon()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(" C┃ L┃ E┃ A┃ R┃");
        Console.WriteLine(" ━┛ ━┛ ━┛ ━┛ ━┛\n");
        Console.ResetColor();
        Console.WriteLine("축하합니다!");
        Console.WriteLine("쉬운 던전을 클리어하였습니다 (/>ω<)/");
        Console.WriteLine();
        
        // 권장 방어력에 따른 체력 감소량 계산
        int defGap = player.Def - 25;
        int minusHp = random.Next(20 - defGap, 36 - defGap);

        // 공격력에 따른 골드 획득량 계산
        float atkRandomValue = random.Next(player.Atk, player.Atk * 2 + 1) / 100f;
        int getGold = (int)(1000 + 1000 * atkRandomValue);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[탐험 결과]");
        Console.ResetColor();
        Console.WriteLine($"체력 {player.Hp} -> {player.Hp - minusHp}");
        Console.WriteLine($"Gold {player.Gold} G -> {player.Gold + getGold} G");
        Console.WriteLine();

        player.Hp -= minusHp;
        player.Gold += getGold;

        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    // 던전 클리어 실패 시 화면
    static void FailDungeon()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("던전 클리어 실패");
        Console.ResetColor();
        Console.WriteLine("쉬운 던전 클리어에 실패하였습니다 (°□°)");
        Console.WriteLine("방어력을 좀 더 올려보세요.");
        Console.WriteLine();

        // 권장 방어력에 따른 체력 감소량 계산
        int defGap = player.Def - 25;
        int minusHp = random.Next(20 - defGap, 36 - defGap) / 2;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("[탐험 결과]");
        Console.ResetColor();
        Console.WriteLine($"체력 {player.Hp} -> {player.Hp - minusHp}");
        Console.WriteLine();

        player.Hp -= minusHp;

        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }
    }

    // 사용자의 콘솔창 입력 시 예외처리
    static int CheckValidInput(int min, int max)
    {
        while (true)
        {
            string input = Console.ReadLine();

            bool parseSuccess = int.TryParse(input, out var ret);
            if (parseSuccess)
            {
                if (ret >= min && ret <= max)
                    return ret;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("     ＿人人人人人人人人人人人人人人人人人人人＿");
            Console.WriteLine("     ＞잘못된 입력입니다. 다시 입력해 주세요.＜");
            Console.WriteLine("     ￣^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y^Y￣");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}


public class Character
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Atk { get; }
    public int Def { get; }
    public int Hp { get; set; }
    public int Gold { get; set; }

    public Character(string name, string job, int level, int atk, int def, int hp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Atk = atk;
        Def = def;
        Hp = hp;
        Gold = gold;
    }

}

public class Items
{
    public string ItemName { get; }
    public string AbilityName { get; }
    public int AbilityValue { get; }
    public string ItemInfo { get; }
    public int Gold { get; }
    public bool IsEquipped { get; set; } // 아이템이 장착되었는지를 나타내는 속성

    public Items(string itemname, string abilityname, int abilityvalue, string iteminfo, int gold)
    {
        ItemName = itemname;
        AbilityName = abilityname;
        AbilityValue = abilityvalue;
        ItemInfo = iteminfo;
        Gold = gold;
        IsEquipped = false; // 아이템 초기 상태로 장착되지 않았음을 나타냄
    }
}

public class StoreItems
{
    public string ItemName { get; }
    public string AbilityName { get; }
    public int AbilityValue { get; }
    public string ItemInfo { get; }
    public int Gold { get; }

    public StoreItems(string itemname, string abilityname, int abilityvalue, string iteminfo, int gold)
    {
        ItemName = itemname;
        AbilityName = abilityname;
        AbilityValue = abilityvalue;
        ItemInfo = iteminfo;
        Gold = gold;
    }
}
