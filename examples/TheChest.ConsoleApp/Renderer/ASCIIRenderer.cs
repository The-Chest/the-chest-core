namespace TheChest.ConsoleApp.Renderer
{
    public sealed class ASCIIRenderer
    {
        public ASCIIRenderer(int maxHeight, int maxWidth)
        {
            SetWindowSize(maxHeight, maxWidth);
        }

        private static void SetWindowSize(int maxHeight, int maxWidth)
        {
            Console.SetWindowSize(maxWidth, maxHeight);
            Console.SetWindowPosition(0, 0);
            Console.ReadKey();
        }

        public void RenderAt(int x, int y, char[] text)
        {

        }

        public void RenderAt(int x, int y, string text)
        {

        }
    }
}
