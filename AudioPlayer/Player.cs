using System;
using System.Collections.Generic;
using NAudio.Wave;

namespace AudioPlayer
{
    public class Player : IDisposable
    {
        private IWavePlayer _wavePlayer;
        private AudioFileReader _audioReader;

        private List<string> _playList = new List<string>();
        private int _current = -1;

        public Player(IWavePlayer player, List<string> playList)
        {
            _wavePlayer = player;
            _wavePlayer.PlaybackStopped += (obj, args) => { Next(); Play(); };

            _playList = playList;
        }

        public bool Next()
        {
            Pause();
            _audioReader?.Dispose();
            _audioReader = null;

            _current++;

            if (_current < _playList.Count)
            {
                _audioReader = new AudioFileReader(_playList[_current]);
                return true;
            }

            return false;
        }

        public void Play()
        {
            _wavePlayer.Init(_audioReader);
            _wavePlayer.Play();
        }

        public void Stop()
        {
            _wavePlayer.Stop();
        }

        public void Pause()
        {
            _wavePlayer.Pause();
        }

        public void Dispose()
        {
            _wavePlayer?.Dispose();
            _audioReader?.Dispose();
        }
    }
}