using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch06
{
    public interface IPlayable
    {
        void Play();
        void Pause();
        void Stop() => WriteLine("Default implementation of Stop.");
    }
}