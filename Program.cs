using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFA
{
    class Program
    {
        static void Main(string[] args)
        {
            DFA dfa = new DFA();

            dfa.showDFAModel();
            dfa.runDFA();
        }
    }

    class DFA
    {
        const int MAX_STATE = 3; //状態の数
        const int MAX_INPUT = 2; //入力数

        private int state = 0; //現在の状態


        private int[,] model = new int[MAX_STATE, MAX_INPUT] {
            { 1, 0},
            { 1, 2},
            { 1, 0}
        };//DFAモデル

        //DFAモデルの表示
        public void showDFAModel()
        {
            Console.WriteLine("DFA Model");
            for (int i = 0; i < MAX_STATE; i++)
            {
                for (int j = 0; j < MAX_INPUT; j++)
                {
                    Console.WriteLine("δ(q{0}, {1}) = q{2}", i.ToString(), j, model[i, j]);
                }
            }
        }

        //DFAの実行
        public void runDFA()
        {
            int input = 0;　//入力
            int stateBefore = 0;　//遷移する前の状態

            Console.WriteLine("Running DFA Model.Input -1 to finish");

            while(input != -1){
                Console.Write("Input:");
                input = int.Parse(Console.ReadLine());

                if (input >= MAX_INPUT || input < -1)
                {
                    //未定義な入力
                    Console.WriteLine("Undefined Input");
                }
                else if (input == -1)
                {
                    //実行の停止
                    Console.WriteLine("Finished run DFA Model");
                }
                else
                {
                    //状態遷移
                    stateBefore = state;
                    state = model[state, input];
                    Console.WriteLine("Moved q{0} --> q{1}", stateBefore, state);
                }
            }
        }
    }
}
