using System.Linq;
using System.Runtime.CompilerServices;
using ConsoleApp3;
using ConsoleTables;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    public static Character player;
    public static StoreManager storeManager;
    public static InventoryManager inventoryManager;
    public static DungeonManager dungeonManager;

    // 아이템 장착 정보 유지용 리스트
    public static List<int> equippedItems = new List<int>();
    // 상점용 구매 아이템 리스트
    public static List<int> boughtItems = new List<int>();
    // 상점용 판매 아이템 리스트
    private static List<int> soldItems = new List<int>();
    // 아이템을 판매할 때 판매된 아이템을 저장할 리스트
    public static List<int> soldItemsIndexes = new List<int>();

    // 기존의 items 배열 대신 List<Items>를 사용
    public static List<Items> items = new List<Items>();

    // 기존의 상점용 아이템 배열 storeItems 대신 리스트 사용
    public static List<StoreItems> storeItems = new List<StoreItems>();

    // 캐릭터, 인벤토리 아이템, 상점 아이템 정보
    static void Main(string[] args)
    {
        GameDataSetting();
        storeManager = new StoreManager(player);
        inventoryManager = new InventoryManager();
        dungeonManager = new DungeonManager(player);
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
    public static void DisplayGameIntro()
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
                inventoryManager.DisplayInventory();
                break;
            case 3:
                storeManager.DisplayStore();
                break;
            case 4:
                dungeonManager.DisplayDungeon();
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
        Console.WriteLine($"Lv. {player.Level}");
        Console.WriteLine($"{player.Name} ( {player.Job} )");

        DisplayCharacterStatus();

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

    // 캐릭터 능력치를 표시하는 메소드
    static void DisplayCharacterStatus()
    {
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
            DisplayBonusStat("공격력", bonusAtk);
            DisplayBonusStat("방어력", bonusDef);
            DisplayBonusStat("체력", bonusHp);
        }
    }

    // 아이템으로 얻은 능력치를 표시하는 메소드
    static void DisplayBonusStat(string statName, int bonusValue)
    {
        // 아이템으로 얻은 능력치가 0보다 큰 경우에만 표시
        if (bonusValue > 0)
        {
            Console.WriteLine($"{statName} : {GetPlayerStatValue(statName) + bonusValue} (+{bonusValue})");
        }
        else
        {
            Console.WriteLine($"{statName} : {GetPlayerStatValue(statName)}");
        }
    }

    // 캐릭터의 특정 스탯 값을 가져오는 메소드
    static int GetPlayerStatValue(string statName)
    {
        switch (statName)
        {
            case "공격력":
                return player.Atk;
            case "방어력":
                return player.Def;
            case "체력":
                return player.Hp;
            default:
                return 0;
        }
    }

    // 사용자의 콘솔창 입력 시 예외처리
    public static int CheckValidInput(int min, int max)
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

public class StoreItems : Items
{
    public StoreItems(string itemName, string abilityName, int abilityValue, string itemInfo, int gold)
        : base(itemName, abilityName, abilityValue, itemInfo, gold)
    {
        
    }
}
