using PYPA.Bankrupt.Core;
using PYPA.Bankrupt.Game;
using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PYPA.Bankrupt
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = $"gameConfig.txt";
            var props = ConfigReader.Read(file);
            var numJogadas = 300;

            var repetições = 1;
            if (args.Length > 0 && int.TryParse(args[0], out repetições))
                repetições = repetições <= 0 ? 1 : repetições;
            for (int i = 0; i < repetições; i++)
            {
                GameSimulationEngine engine = new GameSimulationEngine(props, numJogadas);
                engine.Executar();

                Console.WriteLine("Quantas partidas terminam por time out:");
                Console.WriteLine($"\t => {engine.NumSimulaçõesComTimeout}");

                Console.WriteLine("Quantos turnos em média demora uma partida:");
                Console.WriteLine($"\t => {engine.MédiaDeDuraçãoDeSimulações}");

                Console.WriteLine("Qual a porcentagem de vitórias por comportamento dos jogadores:");
                engine.VencedorPercentual
                    .ForEach(c =>
                    {
                        Console.WriteLine($"\t => {c}");
                    });
                Console.WriteLine("Qual o comportamento que mais vence:");
                Console.WriteLine($"\t => { engine.MaiorVencedor}");
                if (repetições > 1) Console.WriteLine("---------------------------------------------------");
            }

            Console.ReadKey();
        }
    }
}
