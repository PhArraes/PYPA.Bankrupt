using System;
using System.Collections.Generic;
using PYPA.Bankrupt.Core;
using PYPA.Bankrupt.Game.Interfaces;

namespace PYPA.Bankrupt.Game
{
    public interface IGame
    {
        bool Iniciado { get; }
        int NúmeroDePropriedades { get; }
        List<Player> Players { get; }
        List<Player> PlayersVencendo { get; }
        Player Vencendor { get; }
        int Rodada { get; }
        IRoller Roller { get; }
        bool Terminou { get; }

        IJogada ComeçarRodada();
        Player JogadorDaRodada();
        void Jogar(Ação ação);
    }
}