using System.Collections.Generic;
using NAudio.Wave;

namespace AudioPlayer
{
    public class PlayerBuilder
    {
        private List<string> _playList = new List<string>();
        private IWavePlayer _wavePlayer;

        public PlayerBuilder AddTrack(string path)
        {
            _playList.Add(path);
            return this;
        }

        public PlayerBuilder SetWavePlayer(IWavePlayer wavePlayer)
        {
            _wavePlayer = wavePlayer;
            return this;
        }

        public Player Build()
        {
            return new Player(_wavePlayer, _playList);
        }
    }
}