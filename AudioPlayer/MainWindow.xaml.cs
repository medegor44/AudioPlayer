using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Wave;

namespace AudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player _player;

        public MainWindow()
        {
            InitializeComponent();
            _player = new PlayerBuilder()
                .SetWavePlayer(new WaveOutEvent())
                .AddTrack("A.mp3")
                .AddTrack("B.mp3")
                .Build();
            _player.Next();
        }

        private void PlayClicked(object sender, RoutedEventArgs e)
        {
            _player.Play();
        }

        private void PauseClicked(object sender, RoutedEventArgs e)
        {
            _player.Pause();
        }

        private void StopClicked(object sender, RoutedEventArgs e)
        {
            _player.Stop();
        }

        private void NextClicked(object sender, RoutedEventArgs e)
        {
            if (_player.Next())
                _player.Play();
        }

        private void LoadClicked(object sender, RoutedEventArgs e)
        {
            var builder = new PlayerBuilder();
            builder.SetWavePlayer(new WaveOutEvent());

            foreach (var path in playlist.Text.Split(Environment.NewLine.ToCharArray()))
                builder.AddTrack(path);

            _player = builder.Build();
        }
    }
}
