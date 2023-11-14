using ConsoleTables;
using System.Numerics;

namespace ConsoleApp3
{
    public class StoreManager
    {
        private Character player;

        public StoreManager(Character player)
        {
            this.player = player;
        }

        // 상점 화면
        public void DisplayStore()
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

            for (int i = 0; i < Program.storeItems.Count; i++)
            {
                // 아이템 구매 여부 확인
                string priceOrSoldOut = Program.boughtItems.Contains(i) ? "구매완료" : $"{Program.storeItems[i].Gold}";
                table.AddRow($"- {Program.storeItems[i].ItemName}", $"{Program.storeItems[i].AbilityName} +{Program.storeItems[i].AbilityValue}", $"{Program.storeItems[i].ItemInfo}", priceOrSoldOut);
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

            int input = Program.CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    Program.DisplayGameIntro();
                    break;
                case 1:
                    Store(Program.boughtItems);
                    break;
                case 2:
                    SellStore();
                    break;
            }
        }

        // 상점의 아이템 구매 화면
        void Store(List<int> boughtItems)
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

            for (int i = 0; i < Program.storeItems.Count; i++)
            {
                // 아이템 구매 여부 확인
                string priceOrSoldOut = boughtItems.Contains(i) ? "구매완료" : $"{Program.storeItems[i].Gold}";
                table.AddRow($"- {i + 1} {Program.storeItems[i].ItemName}", $"{Program.storeItems[i].AbilityName} +{Program.storeItems[i].AbilityValue}", $"{Program.storeItems[i].ItemInfo}", priceOrSoldOut);
            }
            table.Write();

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.ResetColor();

            int input = Program.CheckValidInput(0, Program.storeItems.Count);

            if (input == 0)
            {
                Program.DisplayGameIntro();
                return;
            }

            int itemIndex = input - 1;
            StoreItems selectedItem = Program.storeItems[itemIndex];

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
                Program.items.Add(purchasedItem);
                Thread.Sleep(2000);
                Store(boughtItems);
            }
        }

        // 상점의 아이템 판매 화면
        void SellStore()
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

            for (int i = 0; i < Program.items.Count; i++)
            {
                // 아이템 판매 여부 확인
                if (!Program.soldItemsIndexes.Contains(i))
                {
                    string priceOrSoldOut = (Program.items[i] != null) ? (Program.items[i].Gold * 85 / 100).ToString() : "판매완료"; // 아이템 가격의 85%
                    table.AddRow($"- {i + 1} {Program.items[i].ItemName}", $"{Program.items[i].AbilityName} +{Program.items[i].AbilityValue}", $"{Program.items[i].ItemInfo}", priceOrSoldOut);
                }
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

            int itemIndex = input - 1;

            // 이미 판매한 아이템인지 확인
            if (Program.soldItemsIndexes.Contains(itemIndex))
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
                int sellPrice = Program.items[itemIndex].Gold * 85 / 100; // 아이템 가격의 85%
                player.Gold += sellPrice;

                // 판매된 아이템 인덱스를 저장
                //soldItemsIndexes.Add(itemIndex);

                // 'items' 목록과 관련된 리스트에서 아이템 삭제
                Program.items.RemoveAt(itemIndex);
                Program.equippedItems.Remove(itemIndex); // 장착한 아이템 목록에서도 삭제

                Console.WriteLine($"아이템 판매 완료! {sellPrice} G를 얻었습니다. 2초 후 판매 창으로 돌아갑니다.");
                Thread.Sleep(2000);
                SellStore();
            }
        }
    }
}
