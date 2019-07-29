using PYPA.Bankrupt.Game.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PYPA.Bankrupt
{
    class ConfigReader
    {
        public static List<IDadosPropriedade> Read(string file)
        {
            var basePath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            List<IDadosPropriedade> props = new List<IDadosPropriedade>();
            string[] lines = File.ReadAllLines($"{basePath}\\{file}", Encoding.UTF8);
            foreach (var line in lines)
            {
                var nums = line.Split(" ").Where(str => !string.IsNullOrEmpty(str)).ToList();
                int venda = int.Parse(nums[0]);
                int aluguel = int.Parse(nums[1]);
                props.Add(new DadosPropriedade(1, venda, aluguel));
            }
            return props;
        }
    }
}
