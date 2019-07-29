using System;
using System.Collections.Generic;
using PYPA.Bankrupt.Game.Interfaces;

namespace PYPA.Bankrupt.Game
{
    interface IGame
    {
        bool Iniciado { get; }
        int NúmeroDePropriedades { get; }
        List<Player> Players { get; }
        List<Guid> PlayersVencendo { get; }
        int Rodada { get; }
        IRoller Roller { get; }
        bool Terminou { get; }

        IJogada ComeçarRodada();
        Player JogadorDaRodada();
        void Jogar(Ação ação);
    }
}