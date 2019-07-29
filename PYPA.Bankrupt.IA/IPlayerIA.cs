using PYPA.Bankrupt.Game;
using PYPA.Bankrupt.Game.Interfaces;

namespace PYPA.Bankrupt.IA
{
    public interface IPlayerIA
    {
        Ação Jogar(IJogada jogada);
    }
}