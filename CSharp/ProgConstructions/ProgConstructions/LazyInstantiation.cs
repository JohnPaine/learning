using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal class LazyInstantiation
    {
        public static void RunTests() {
            var player = new MediaPlayer();
            player.Play();
            player.Pause();
            player.Stop();
            player.AllSongs.TrackNames.PrintCollection();
        }

        private class MediaPlayer
        {
            private readonly Lazy<AllTracks> _allSongs = new Lazy<AllTracks>(() => {
                Console.WriteLine("Creating lazy object!!!");
                return new AllTracks();
            });

            public AllTracks AllSongs => _allSongs.Value;

            public void Play() {
                Console.WriteLine("public void Play()");
            }

            public void Stop() {
                Console.WriteLine("public void Stop()");
            }

            public void Pause() {
                Console.WriteLine("public void Pause()");
            }
        }

        private class AllTracks
        {
            public string[] TrackNames { get; }

            public AllTracks() {
                Console.WriteLine("public AllTracks() is called");
                TrackNames = new string[10];
                for (var i = 0; i < TrackNames.Length; ++i) {
                    TrackNames[i] = $"Track {i}";
                }
            }
        }
    }
}