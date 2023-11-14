using ConsoleTables;

namespace ConsoleApp3
{
    public class InventoryManager
    {
        // 인벤토리 화면
        public void DisplayInventory()
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
            for (int i = 0; i < Program.items.Count; i++)
            {
                table.AddRow($"- {(Program.items[i].IsEquipped ? "[E]" : "")}{Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}");
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

            int input = Program.CheckValidInput(0, 2);

            if (input == 0)
            {
                Program.DisplayGameIntro();
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
        void EquipItems()
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
            for (int i = 0; i < Program.items.Count; i++)
            {
                table.AddRow($"- {i + 1} {(Program.items[i].IsEquipped ? "[E]" : "")}{Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}");
            }
            table.Write();

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.ResetColor();

            int input = Program.CheckValidInput(0, Program.items.Count);

            if (input == 0)
            {
                Program.DisplayGameIntro();
                return;
            }
            // 사용자 입력값에서 1을 뺴서 아이템의 인덱스로 변환
            int itemIndex = input - 1;
            ItemEquipped(Program.equippedItems, itemIndex, Program.items[itemIndex]);
            EquipItems();
        }

        // 장착한 아이템 리스트에 추가/삭제
        void ItemEquipped(List<int> equippedItems, int itemNum, Items item)
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
                    Items equippedItem = Program.items[equippedIndex];
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

        void OrderItems()
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
            for (int i = 0; i < Program.items.Count; i++)
            {
                table.AddRow($"- {(Program.items[i].IsEquipped ? "[E]" : "")}{Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}");
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

            int input = Program.CheckValidInput(0, 5);

            if (input == 0)
            {
                Program.DisplayGameIntro();
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
        void OrderItemsByName()
        {
            Program.items.Sort((item1, item2) => item1.ItemName.CompareTo(item2.ItemName));
            DisplayInventory();
        }

        // 아이템 장착순 정렬
        void OrderItemsByEquipped()
        {
            Program.items.Sort((item1, item2) =>
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
        void OrderItemsByAbility(string statName)
        {
            Program.items.Sort((item1, item2) =>
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
    }
}
