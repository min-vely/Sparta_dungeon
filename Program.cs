using System.Linq;
using System.Runtime.CompilerServices;
using ConsoleTables;

internal class Program
{
    private static Character player;

    private static Items item1;
    private static Items item2;
    private static Items item3;
    private static Items item4;

    private static StoreItems storeItem1;
    private static StoreItems storeItem2;
    private static StoreItems storeItem3;

    // 아이템 장착 정보 유지용 리스트
    private static List<int> equippedItems = new List<int>();
    // 상점용 아이템 리스트
    private static List<int> boughtItems = new List<int>();
    // 상점 아이템 구매 후 인벤토리 리스트
    private static List<Items> inventory = new List<Items>();


    // 기본 보유 중인 아이템 배열
    static Items[] items;
    // 상점용 아이템 배열
    static StoreItems[] storeItems;

    // 캐릭터, 인벤토리 아이템, 상점 아이템 정보
    static void Main(string[] args)
    {
        //Console.BackgroundColor = ConsoleColor.White;
        

        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅(이름, 직업, 레벨, 공격력, 방어력, 체력, 돈)
        player = new Character("루루", "서포터", 1, 47, 26, 595, 15000);

        // 기본 보유 중인 아이템 정보 세팅(배열 사용)
        items = new Items[]
        {
        new Items("존야의 모래시계", "방어력", 45, "띵 - "),
        new Items("구인수의 격노검", "공격력", 30, "AD룰루 필수템"),
        new Items("몰락한 왕의 검", "공격력", 40, "체력 비례 데미지"),
        new Items("부서진 여왕의 왕관", "체력", 250, "챔피언 보호 효과")
        };

        // switch문으로 배열을 변수에 할당
        // 여긴 아이템 1 = 인덱스 0번!!!!!
        for (int i = 0; i < items.Length; i++)
        {
            switch (i)
            {
                case 0:
                    item1 = items[i];
                    break;
                case 1:
                    item2 = items[i];
                    break;
                case 2:
                    item3 = items[i];
                    break;
                case 3:
                    item4 = items[i];
                    break;
            }
        }

        // 상점용 아이템 정보 세팅(배열 사용) 
        storeItems = new StoreItems[]
        {
        new StoreItems("스태틱의 단검", "공격력", 50, "찌릿찌릿", 1500),
        new StoreItems("강철심장", "체력", 800, "깡!", 1600),
        new StoreItems("가고일 돌갑옷", "방어력", 60, "룰루로 이걸 왜 삼", 1600)
        };

        for (int i = 0; i < storeItems.Length; i++)
        {
            switch (i)
            {
                case 0:
                    storeItem1 = storeItems[i];
                    break;
                case 1:
                    storeItem2 = storeItems[i];
                    break;
                case 2:
                    storeItem3 = storeItems[i];
                    break;
            }
        }
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
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(1, 3);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                DisplayInventory();
                break;
            case 3:
                StoreDisplay();
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

        // 기존 보유 아이템
        for (int i = 0; i < items.Length; i++)
        {
            table.AddRow($"- {(equippedItems.Contains(i) ? "[E]" : "")}{items[i].ItemName}", $"{items[i].AbilityName} +{items[i].AbilityValue}", $"{items[i].ItemInfo}");
        }
        // 상점에서 구매한 아이템
        for (int i = 0; i < inventory.Count; i++)
        {
            table.AddRow($"- {(equippedItems.Contains(i) ? "[E]" : "")}{inventory[i].ItemName}", $"{inventory[i].AbilityName} +{inventory[i].AbilityValue}", $"{inventory[i].ItemInfo}");
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, 1);

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
        for (int i = 0; i < items.Length; i++)
        {
            table.AddRow($"- {i + 1} {(equippedItems.Contains(i) ? "[E]" : "")}{items[i].ItemName}", $"{items[i].AbilityName} +{items[i].AbilityValue}", $"{items[i].ItemInfo}");
        }
        // 상점에서 구매한 아이템
        for (int i = 0; i < inventory.Count; i++)
        {
            table.AddRow($"- {i + 1} {(equippedItems.Contains(i) ? "[E]" : "")}{inventory[i].ItemName}", $"{inventory[i].AbilityName} +{inventory[i].AbilityValue}", $"{inventory[i].ItemInfo}");
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.ResetColor();

        int input = CheckValidInput(0, inventory.Count);
        // 사용자 입력값에서 1을 빼서 아이템의 인덱스로 변환
        int itemIndex = input - 1;

        if (input == 0)
        {
            DisplayInventory();
            return;
        }

        // 여긴 아이템 1 = 인덱스 1번!!!!!
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                ItemEquipped(equippedItems, itemIndex);
                EquipItems();
                break;
                // 추가적인 아이템 핸들링 코드 추가
                // case 2:
                //     ItemEquipped(equippedItems, itemIndex);
                //     EquipItems();
                //     break;
                // case 3:
                //     ItemEquipped(equippedItems, itemIndex);
                //     EquipItems();
                //     break;
                // case 4:
                //     ItemEquipped(equippedItems, itemIndex);
                //     EquipItems();
                //     break;
        }
    }


    // 장착한 아이템 리스트에 추가/삭제
    static void ItemEquipped(List<int> equippedItems, int itemNum)
    {
        if (equippedItems.Contains(itemNum))
        {
            equippedItems.Remove(itemNum);
        }
        else
        {
            equippedItems.Add(itemNum);
        }
    }

    // 상점 화면
    // 상점 화면
    static void StoreDisplay()
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

        for (int i = 0; i < storeItems.Length; i++)
        {
            // 아이템 구매 여부 확인
            string priceOrSoldOut = boughtItems.Contains(i) ? "구매완료" : $"{storeItems[i].Gold}";
            table.AddRow($"- {storeItems[i].ItemName}", $"{storeItems[i].AbilityName} +{storeItems[i].AbilityValue}", $"{storeItems[i].ItemInfo}", priceOrSoldOut);
        }
        table.Write();

        Console.WriteLine();
        Console.WriteLine("1. 아이템 구매");
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
                Store(boughtItems);
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

        for (int i = 0; i < storeItems.Length; i++)
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

        int input = CheckValidInput(0, storeItems.Length);

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
        // 보유 골드가 아이템 가격보다 많다면
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
            // 아이템 구매 시 골드 차감
            player.Gold -= selectedItem.Gold;
            boughtItems.Add(itemIndex);

            // 구매한 아이템을 인벤토리에 추가
            Items purchasedItem = new Items(selectedItem.ItemName, selectedItem.AbilityName, selectedItem.AbilityValue, selectedItem.ItemInfo);
            inventory.Add(purchasedItem);

            Store(boughtItems);
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
    public int Hp { get; }
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

    public Items(string itemname, string abilityname, int abilityvalue, string iteminfo)
    {
        ItemName = itemname;
        AbilityName = abilityname;
        AbilityValue = abilityvalue;
        ItemInfo = iteminfo;
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
