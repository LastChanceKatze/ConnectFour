using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Game
    {
        Player _currentPlayer;
        Player _firstPlayer;
        Player _secondPlayer;
        GameState _state;

        public event EventHandler<GameOverEventArgs> GameOver;

        public GameState State
        {
            get { return _state; }
        }
        public Game()
        {
            _firstPlayer = new Human(0);
            _secondPlayer = new Human(1);
            _currentPlayer = _firstPlayer;
            _state = GameState.NijeKraj;
        }

        public Move Play(int col)
        {
            Move m=_currentPlayer.Play(col);
            _state = Board.Instance.CheckWinner(_currentPlayer);
            //if (_state != GameState.NijeKraj)
            //{
            //    OnGameOver(new GameOverEventArgs(_state));
            //    return null;
            //}
            SwitchPlayers();
            return m;

        }

        public void OnGameOver(GameOverEventArgs e)
        {
            GameOver?.Invoke(this, e);
        }

        private void SwitchPlayers()
        {
            if (_currentPlayer == _firstPlayer)
                _currentPlayer = _secondPlayer;
            else _currentPlayer = _firstPlayer;
        }
    }
}
