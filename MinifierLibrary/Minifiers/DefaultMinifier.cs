using System.Text.RegularExpressions;

namespace MinifierLibrary.Minifiers
{
    internal class DefaultMinifier : IMinifier
    {
        private static readonly Regex EmptySpaces = new Regex(@"\s*\n\s*");
        private static readonly Regex OptimizerRegex = new Regex(@"\s{2,}");
        private readonly MelezeWebMinifier _minifier = new MelezeWebMinifier();
        private MelezeWebMinifierState _state = new MelezeWebMinifierState(true, false, false, false, false, false);

        public string Minify(string content)
        {
            _state = _minifier.AnalyseContent(content, _state);
            content = _minifier.Minify(content, _state);
            content = EmptySpaces.Replace(content, "\n");
            content = OptimizerRegex.Replace(content, " ");
            return content;
        }
    }
}