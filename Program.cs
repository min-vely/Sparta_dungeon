using System.Runtime.CompilerServices;

internal class Program
{
    private static Character player;
    private static Items item1;
    private static Items item2;
    private static List<int> equippedItems = new List<int>(); // 아이템 장착 정보를 유지하는 리스트

    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅
        player = new Character("루루", "원거리 딜러", 1, 47, 26, 595, 1500);

        // 아이템 정보 세팅
        item1 = new Items("존야의 모래시계", "방어력", 45, "띵 - ");
        item2 = new Items("구인수의 격노검", "공격력", 30, "AD룰루 필수템");
    }

    static void DisplayGameIntro()
    {
        Console.Clear();

        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("1. 상태보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(1, 2);
        switch (input)
        {
            case 1:
                DisplayMyInfo();
                break;

            case 2:
                DisplayInventory();
                break;
        }
    }

    static void DisplayMyInfo()
    {
        // 아이템 장착 여부에 따라 능력치 계산
        int totalAtk = player.Atk;
        int totalDef = player.Def;
        int totalHp = player.Hp;

        Console.Clear();


        
        if (equippedItems.Contains(1))
        {
            totalDef += item1.AbilityValue;
        }
        if (equippedItems.Contains(2))
        {
            totalAtk += item2.AbilityValue;
        }

        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보를 표시합니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Level}");
        Console.WriteLine($"{player.Name}({player.Job})");
        Console.WriteLine($"공격력: {totalAtk}");
        Console.WriteLine($"방어력: {totalDef}");
        Console.WriteLine($"체력: {totalHp}");
        Console.WriteLine($"Gold : {player.Gold} G");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(0, 0);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
        }


    }

    static void DisplayInventory()
    {
        //List<int> equippedItems = new List<int>();

        Console.Clear();

        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine($"- {(equippedItems.Contains(1) ? "[E]" : "")}{item1.ItemName}      | {item1.AbilityName} +{item1.AbilityValue} | {item1.ItemInfo}");
        Console.WriteLine($"- {(equippedItems.Contains(2) ? "[E]" : "")}{item2.ItemName}      | {item2.AbilityName} +{item2.AbilityValue} | {item2.ItemInfo}");
        Console.WriteLine();

        Console.WriteLine("1. 장착 관리");
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(0, 1);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                EquipItems(equippedItems);
                break;

        }
    }

    static void EquipItems(List<int> equippedItems)
    {
        Console.Clear();

        Console.WriteLine("인벤토리 - 장착 관리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine($"- 1 {(equippedItems.Contains(1) ? "[E]" : "")}{item1.ItemName}      | {item1.AbilityName} +{item1.AbilityValue} | {item1.ItemInfo}");
        Console.WriteLine($"- 2 {(equippedItems.Contains(2) ? "[E]" : "")}{item2.ItemName}      | {item2.AbilityName} +{item2.AbilityValue} | {item2.ItemInfo}");
        Console.WriteLine();
        Console.WriteLine("0. 나가기");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        int input = CheckValidInput(0, 2);
        switch (input)
        {
            case 0:
                DisplayGameIntro();
                break;
            case 1:
                ItemEquipped(equippedItems, 1);
                EquipItems(equippedItems);
                break;
            case 2:
                ItemEquipped(equippedItems, 2);
                EquipItems(equippedItems);
                break;
        }
    }

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

            Console.WriteLine("잘못된 입력입니다.");
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
    public int Gold { get; }

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
