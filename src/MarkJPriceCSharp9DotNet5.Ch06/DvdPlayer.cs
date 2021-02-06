using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch06
{
    public class DvdPlayer : IPlayable
    {
        public void Play() => WriteLine("DVD player is playing.");
        public void Pause() => WriteLine("DVD player is pausing.");
    }
}