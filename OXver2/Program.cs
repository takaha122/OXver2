using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OXver2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] TVL = new int[3, 3]{
            {0,0,0},
            {0,0,0},
            {0,0,0}};
            int flg = 0;
            while(flg == 0 )
            {
                Hyouzi(TVL);
                Nyuryoku(TVL);
               flg = Hantei(TVL);
                Aite(TVL);
                flg = Hantei(TVL);
            }
            Hyouzi(TVL);
            if (flg == 1)
            {
                Console.WriteLine("プレイヤーの勝利です");
            }
            else {
                Console.WriteLine("NPCの勝利です");
            }
        }

        private static void Aite(int[,] TVL)
     {
           int seed = Environment.TickCount;
            Random rand = new Random(seed++);
            int[,] aki=new int[9,2];
            int i,j,z = 0;
            for (i = 0; i < TVL.GetLength(0); i++)
           {
                for (j = 0; j < TVL.GetLength(1); j++)
                {
                    if (TVL[i, j] == 0) {
                        aki[z, 0] = z;
                        aki[z, 1] = i * 10 + j;
                        z++;
                    }
                }
            }
                int x = rand.Next(0,z);
                int y =aki[x,1];
                i= y/10;
                j=y-y/10*10;
                Console.WriteLine("{0},{1}",i,j);
                TVL[i, j] = 2;

            }
        private static int Hantei(int[,] TVL)
        {
            for (int i = 0; i < TVL.GetLength(0); i++)
            {
                if (TVL[i, 0] == TVL[i, 1] && TVL[i, 0] == TVL[i, 2] )
                {
                    if (TVL[i, 0] == 1) { return (1); }
                    if (TVL[i, 0] == 2) { return (2); }
                }
            }
            for (int i = 0; i < TVL.GetLength(0); i++)
            {
                if (TVL[0, i] == TVL[1, i] && TVL[0, i] == TVL[2, i])
                {
                    if (TVL[0, i] == 1) { return (1); }
                    if (TVL[0, i] == 2) { return (2); }
                }
            }
            if (TVL[0, 0] == TVL[1, 1] && TVL[0, 0] == TVL[2, 2])
            {
                if (TVL[0, 0] == 1) { return (1); }
                if (TVL[0, 0] == 2) { return (2); }
            }
            else
            if (TVL[0, 2] == TVL[1, 1] && TVL[0, 2] == TVL[2, 0])
            {
                if (TVL[1, 1] == 1) { return (1); }
                if (TVL[1, 1] == 2) { return (2); }
            }
            return (0);
        }

        private static void Nyuryoku(int[,] TVL)
        {
            int flg=0;
            while (flg == 0)
            {
                Console.WriteLine("テンキーの配置で丸を配置");
                var n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1: if (TVL[2, 0] == 0) { TVL[2, 0] = 1; return;}; break;
                    case 2: if (TVL[2, 1] == 0) { TVL[2, 1] = 1; return;}; break;
                    case 3: if (TVL[2, 2] == 0) { TVL[2, 2] = 1; return;}; break;
                    case 4: if (TVL[1, 0] == 0) { TVL[1, 0] = 1; return;}; break;
                    case 5: if (TVL[1, 1] == 0) { TVL[1, 1] = 1; return;}; break;
                    case 6: if (TVL[1, 2] == 0) { TVL[1, 2] = 1; return;}; break;
                    case 7: if (TVL[0, 0] == 0) { TVL[0, 0] = 1; return;}; break;
                    case 8: if (TVL[0, 1] == 0) { TVL[0, 1] = 1; return;}; break;
                    case 9: if (TVL[0, 2] == 0) { TVL[0, 2] = 1; return;}; break;
                }
                Console.WriteLine("そこにはもう入っています"); 
            }
        }

        private static void Hyouzi(int[,] TVL)
        {
            for (int i = 0; i < TVL.GetLength(0); i++)
            {
                for (int j = 0; j < TVL.GetLength(1); j++)
                {
                    switch (TVL[i, j])
                    {
                        case 0:
                            Console.Write("|空");
                            break;
                        case 1:
                            Console.Write("|丸");
                            break;
                        case 2:
                            Console.Write("|伐");
                            break;
                        default:
                            Console.Write("|偽");
                            break;
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}