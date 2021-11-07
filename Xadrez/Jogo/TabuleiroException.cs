using System;

namespace Jogo
{
    /// <summary>ApplicationException do Tabuleiro.</summary>
    class TabuleiroException : Exception
    {
        /// <summary>Contrutor do TabuleiroException.</summary>
        public TabuleiroException(string msg) : base(msg) { }
    }
}