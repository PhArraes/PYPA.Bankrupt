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
            for (int i = 0; i < 1; i++)
            {
                GameSimulationEngine engine = new GameSimulationEngine(props, numJogadas);
                engine.Executar();


                Console.WriteLine(engine.NumSimulaçõesComTimeout);
                Console.WriteLine(engine.MédiaDeDuraçãoDeSimulações);
                engine.VencedorPercentual
                    .ForEach(c =>
                    {
                        Console.WriteLine(c);
                    });
                Console.WriteLine(engine.MaiorVencedor);
                //Console.WriteLine("---------------------------------------------------");
            }

            Console.ReadKey();
        }
    }
}
