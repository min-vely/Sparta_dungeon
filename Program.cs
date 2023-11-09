using System.Runtime.CompilerServices;

internal class Program
{
    private static Character player;

    private static Items item1;
    private static Items item2;
    private static Items item3;
    private static Items item4;
    private static Items item5;
    private static Items item6;

    // 아이템 장착 정보 유지용 리스트
    private static List<int> equippedItems = new List<int>();

    Items[] items;

    static void Main(string[] args)
    {
        GameDataSetting();
        DisplayGameIntro();
    }

    static void GameDataSetting()
    {
        // 캐릭터 정보 세팅(이름, 직업, 레벨, 공격력, 방어력, 체력, 돈)
        player = new Character("루루", "서포터", 1, 47, 26, 595, 1500);

        // 아이템 정보 세팅(배열 사용)
        Items[] items = new Items[]
        {
        new Items("존야의 모래시계", "방어력", 45, "띵 - "),
        new Items("구인수의 격노검", "공격력", 30, "AD룰루 필수템"),
        new Items("몰락한 왕의 검", "공격력", 40, "체력 비례 데미지"),
        new Items("강철심장", "체력", 800, "깡!"),
        new Items("부서진 여왕의 왕관", "체력", 250, "챔피언 보호 효과"),
        new Items("가고일 돌갑옷", "방어력", 60, "룰루로 이걸 왜 삼")
        };

        // switch문으로 배열을 변수에 할당
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
                case 4:
                    item5 = items[i];
                    break;
                case 5:
                    item6 = items[i];
                    break;
            }
        }
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
