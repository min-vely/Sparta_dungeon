using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class DungeonManager
    {
        private Character player;

        static Random random = new Random();

        public DungeonManager(Character player)
        {
            this.player = player;
        }

        // 난이도에 따른 던전 입장 화면
        public void DisplayDungeon()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("던전입장\n");
            Console.ResetColor();

            Console.WriteLine("                ┌─────────·········♡");
            Console.WriteLine();
            Console.WriteLine(" ┌──── “ 도 전 하 시 겠 습 니 까 ? ¿ “ ");
            Console.WriteLine(" │");
            Console.WriteLine(" └─▶ 화 이 팅 。 ─────┐");
            Console.WriteLine("                                           ♡");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"현재 내 방어력 : {player.Def + CalculateBonusStat(Program.equippedItems, "방어력")}");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("1. 쉬운 던전     | 방어력 25 이상 권장");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.ResetColor();

            int input = Program.CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    Program.DisplayGameIntro();
                    break;
                case 1:
                    LoadDungeon();
                    break;
            }
        }

        // 던전 진행 중 화면
        void LoadDungeon()
        {
            Console.Clear();
            Console.WriteLine(" 　　 　 던\n");
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
        void ClearDungeon()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" C┃ L┃ E┃ A┃ R┃");
            Console.WriteLine(" ━┛ ━┛ ━┛ ━┛ ━┛\n");
            Console.ResetColor();
            Console.WriteLine("축하합니다!");
            Console.WriteLine("쉬운 던전을 클리어하였습니다 (/>ω<)/");
            Console.WriteLine();

            // 권장 방어력(25)에 따른 체력 감소량 계산
            int defGap = CalculateBonusStat(Program.equippedItems, "방어력") - 25;
            int minusHp = random.Next(100 - defGap, 200 - defGap);

            // 아이템으로 얻은 능력치가 반영된 총 체력
            int totalHp = CalculateBonusStat(Program.equippedItems, "체력") + player.Hp;

            // 아이템으로 얻은 공격력에 따른 골드 획득량 계산
            int bonusAtk = CalculateBonusStat(Program.equippedItems, "공격력");
            float atkRandomValue = random.Next((player.Atk + bonusAtk), (player.Atk + bonusAtk * 2 + 1)) / 100f;
            int getGold = (int)(1000 + 1000 * atkRandomValue);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[탐험 결과]");
            Console.ResetColor();
            Console.WriteLine($"체력 {totalHp} -> {totalHp - minusHp}");
            Console.WriteLine($"Gold {player.Gold} G -> {player.Gold + getGold} G");
            Console.WriteLine();

            player.Hp -= minusHp;
            player.Gold += getGold;

            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.ResetColor();

            int input = Program.CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    Program.DisplayGameIntro();
                    break;
            }
        }

        // 던전 클리어 실패 시 화면
        void FailDungeon()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("던전 클리어 실패");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("■■■■    ■■     ■■■■   ■");
            Console.WriteLine("■         ■  ■       ■      ■");
            Console.WriteLine("■■■    ■■■■      ■      ■");
            Console.WriteLine("■        ■    ■      ■      ■");
            Console.WriteLine("■        ■    ■   ■■■■   ■■■■");
            Console.WriteLine();
            Console.WriteLine("쉬운 던전 클리어에 실패하였습니다 (°□°)");
            Console.WriteLine("방어력을 좀 더 올려보세요.");
            Console.WriteLine();

            // 권장 방어력에 따른 체력 감소량 계산
            int defGap = CalculateBonusStat(Program.equippedItems, "방어력") - 25;
            int minusHp = random.Next(100 - defGap, 200 - defGap) / 2;

            // 아이템으로 얻은 능력치가 반영된 총 체력
            int totalHp = CalculateBonusStat(Program.equippedItems, "체력") + player.Hp;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[탐험 결과]");
            Console.ResetColor();
            Console.WriteLine($"체력 {totalHp} -> {totalHp - minusHp}");
            Console.WriteLine();

            player.Hp -= minusHp;

            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.ResetColor();

            int input = Program.CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    Program.DisplayGameIntro();
                    break;
            }
        }

        // 아이템으로 얻은 능력치를 계산하는 메서드
        static int CalculateBonusStat(List<int> equippedItems, string statName)
        {
            int bonusValue = 0;

            foreach (int itemIndex in equippedItems)
            {
                Items equippedItem = Program.items[itemIndex];

                if (equippedItem.AbilityName == statName)
                {
                    bonusValue += equippedItem.AbilityValue;
                }
            }

            return bonusValue;
        }
    }
}
