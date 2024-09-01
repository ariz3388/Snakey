using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Snake.Utility
{
    public class MusicPlayer
    {
        private IWavePlayer _waveOutDevice;

        public string CurrentSongPlaying { get; private set; }
        public bool isPlaying { get { return _waveOutDevice.PlaybackState == PlaybackState.Playing; } }

        public MusicPlayer(IWavePlayer waveOutDevice)
        {
            _waveOutDevice = waveOutDevice;
        }

        public void PlayMusic(string path)
        {
            if (_waveOutDevice != null) if (_waveOutDevice.PlaybackState == PlaybackState.Playing) StopMusic();
            CurrentSongPlaying = path;
            _waveOutDevice.Init(new AudioFileReader(path));
            _waveOutDevice.Play();
        }

        public void PauseMusic()
        {
            if (_waveOutDevice != null && _waveOutDevice.PlaybackState != PlaybackState.Paused) _waveOutDevice.Pause();
            else _waveOutDevice.Play();
        }

        public void StopMusic()
        {
            if (_waveOutDevice != null && _waveOutDevice.PlaybackState != PlaybackState.Stopped)
            {
                _waveOutDevice.Dispose();
                CurrentSongPlaying = null;
                _waveOutDevice = new WaveOut();
            }
        }
    }

    public class SoundPlayer
    {
        public IWavePlayer _waveOutDevice;

        public string CurrentSongPlaying { get; private set; }

        public bool isPlaying { get { return _waveOutDevice.PlaybackState == PlaybackState.Playing; } }

        public SoundPlayer(IWavePlayer waveOutDevice)
        {
            _waveOutDevice = waveOutDevice;
        }

        public void PlaySoundFX(string path)
        {
            if (_waveOutDevice != null) if (_waveOutDevice.PlaybackState == PlaybackState.Playing) StopSound();
            CurrentSongPlaying = path;
            _waveOutDevice.Init(new AudioFileReader(path));
            _waveOutDevice.Play();
        }

        public void PauseSound()
        {
            if (_waveOutDevice != null && _waveOutDevice.PlaybackState != PlaybackState.Paused) _waveOutDevice.Pause();
            else _waveOutDevice.Play();
        }

        public void StopSound()
        {
            if (_waveOutDevice != null && _waveOutDevice.PlaybackState != PlaybackState.Stopped)
            {
                _waveOutDevice.Dispose();
                CurrentSongPlaying = null;
                _waveOutDevice = new WaveOut();
            }
        }
    }
}
