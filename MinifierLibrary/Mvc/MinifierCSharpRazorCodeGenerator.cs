using System.CodeDom;
using System.Web.Razor;
using System.Web.Razor.Generator;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Text;
using System.Web.Razor.Tokenizer.Symbols;
using MinifierLibrary.Minifiers;

namespace MinifierLibrary.Mvc
{
    internal class MinifierCSharpRazorCodeGenerator : CSharpRazorCodeGenerator
    {
        private sealed class MarkupSymbol : ISymbol
        {
            public string Content { get; set; }

            public SourceLocation Start { get; private set; }

            public MarkupSymbol()
            {
                Start = SourceLocation.Zero;
            }

            public void ChangeStart(SourceLocation newStart)
            {
                Start = newStart;
            }


            public void OffsetStart(SourceLocation documentStart)
            {
                Start = documentStart;
            }
        }

        private readonly IMinifier _minifier;

        public MinifierCSharpRazorCodeGenerator(RazorEngineHost codeGeneratorHost, RazorCodeGenerator incomingCodeGenerator, IMinifier minifier)
            : base(incomingCodeGenerator.ClassName,
                incomingCodeGenerator.RootNamespaceName,
                incomingCodeGenerator.SourceFileName,
                codeGeneratorHost)
        {
            //var webPageRazorHost = codeGeneratorHost as MvcWebPageRazorHost;
            //if (webPageRazorHost == null || webPageRazorHost.IsSpecialPage)
            //    return;
            SetBaseType("dynamic");
            _minifier = minifier;
        }

        public override void VisitSpan(Span span)
        {
            if (span.Kind == SpanKind.Markup)
            {
                var content = span.Content;

                content = _minifier.Minify(content);

                var builder = new SpanBuilder { CodeGenerator = span.CodeGenerator, EditHandler = span.EditHandler, Kind = span.Kind, Start = span.Start };
                var symbol = new MarkupSymbol { Content = content };
                builder.Accept(symbol);
                span.ReplaceWith(builder);
            }

            base.VisitSpan(span);
        }

        private void SetBaseType(string modelTypeName)
        {
            var codeTypeReference = new CodeTypeReference(string.Format("{0}<{1}>", Context.Host.DefaultBaseClass, modelTypeName));
            Context.GeneratedClass.BaseTypes.Clear();
            Context.GeneratedClass.BaseTypes.Add(codeTypeReference);
        }
    }
}