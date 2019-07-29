using PYPA.Bankrupt.Core;
using PYPA.Bankrupt.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PYPA.Bankrupt.Game
{
    class Game : Entity, IGame
    {
        public int NúmeroDePropriedades { get; }
        public IRoller Roller { get; }
        public bool Iniciado { get; private set; }
        public List<Player> Players { get; private set; }
        public int Rodada { get; private set; }
        public Boolean Terminou { get; private set; }

        public List<Player> PlayersVencendo
        {
            get
            {
                var rank = _gameState.PlayersRank;
                return _gameState.PlayersRank
                    .Where(p => !p.Carteira.Bankrupt)
                    .Where(p => p.Carteira.Coins == rank[0].Carteira.Coins)
                    .Select(p => Players.First(pl => pl.Id == p.Player)).ToList();
            }
        }
        public Player Vencendor
        {
            get
            {                
                return PlayersVencendo.FirstOrDefault();
            }
        }


        private int _playerAtual;
        private GameState _gameState;
        private bool _rodadaIniciada;
        private IJogada _jogadaAtual;
        public Game(List<IDadosPropriedade> propriedades, List<Player> players, IRoller roller, DateTime dataCriação) : base(Guid.NewGuid(), dataCriação)
        {
            Iniciado = false;
            Roller = roller;
            Players = players;
            Rodada = 1;

            _gameState = new GameState(propriedades, players, GameConfig.VALOR_INICIAL);
            _playerAtual = 0;
        }

        public Player JogadorDaRodada()
        {
            return Players[_playerAtual];
        }

        public IJogada ComeçarRodada()
        {
            if (_rodadaIniciada) throw new Exception("Rodada já iniciada");
            _rodadaIniciada = true;
            var jogador = JogadorDaRodada();
            var passos = Roller.Roll();
            var playerState = _gameState.MoverPlayer(jogador.Id, passos);
            _jogadaAtual = CriarJogada(playerState, passos);
            return _jogadaAtual;
        }

        public void Jogar(Ação ação)
        {
            if (!_rodadaIniciada) throw new Exception("Rodada não iniciada");
            if (!_jogadaAtual.AçõesPossíveis.Contains(ação)) throw new Exception("Jogada não é possível");
            var player = Players.ElementAt(_playerAtual);
            var playerState = _gameState.Jogar(player.Id, ação);
            DefinirProximoPlayer();
            VerificarFimDeJogo();
            _rodadaIniciada = false;
        }

        private void DefinirProximoPlayer()
        {
            _playerAtual = PróximoNumPlayer();
            var p = Players.ElementAt(_playerAtual);
            var playerState = _gameState.PlayerGameState(p.Id);
            while (playerState.Carteira.Bankrupt)
            {
                _playerAtual = PróximoNumPlayer();
                p = Players.ElementAt(_playerAtual);
                playerState = _gameState.PlayerGameState(p.Id);
            }
        }

        private int PróximoNumPlayer()
        {
            var prox = _playerAtual + 1;
            if (prox >= Players.Count()) Rodada++;
            return prox % Players.Count();
        }

        private IJogada CriarJogada(IPlayerGameState playerState, int dado)
        {
            var jogada = new Jogada()
            {
                Dado = dado,
                Propriedade = _gameState.Propriedades[playerState.PosiçãoAtual],
                Saldo = playerState.Carteira.Coins,
                AçõesPossíveis = new List<Ação>()
            };
            var propriedade = _gameState.Propriedades[playerState.PosiçãoAtual];
            AdicionaPassar(playerState, jogada);
            AdicionaComprar(playerState, jogada);
            AdicionaPagarAluguel(playerState, jogada);
            return jogada;
        }

        private void VerificarFimDeJogo()
        {
            Terminou = Rodada >= GameConfig.MAX_RODADAS || _gameState.PlayersAtivos <= 1;
        }

        private void AdicionaPassar(IPlayerGameState playerState, Jogada jogada)
        {
            var propriedade = _gameState.Propriedades[playerState.PosiçãoAtual];
            if ((propriedade.TemDono && propriedade.Dono == playerState.Player) ||
                !propriedade.TemDono)
                jogada.AçõesPossíveis.Add(Ação.Passar);
        }
        private void AdicionaComprar(IPlayerGameState playerState, Jogada jogada)
        {
            var propriedade = _gameState.Propriedades[playerState.PosiçãoAtual];
            if (!propriedade.TemDono && propriedade.ValorDeVenda <= playerState.Carteira.Coins)
                jogada.AçõesPossíveis.Add(Ação.Comprar);
        }
        private void AdicionaPagarAluguel(IPlayerGameState playerState, Jogada jogada)
        {
            var propriedade = _gameState.Propriedades[playerState.PosiçãoAtual];
            if (propriedade.TemDono && propriedade.Dono != playerState.Player)
                jogada.AçõesPossíveis.Add(Ação.PagarAluguel);
        }

    }
}
