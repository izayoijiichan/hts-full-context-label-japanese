// ----------------------------------------------------------------------
// @Namespace : Izayoi.Hts.FullContextLabel.Japanese
// @Class     : LabelStringReader
// ----------------------------------------------------------------------
namespace Izayoi.Hts.FullContextLabel.Japanese.IO
{
    using System;

    /// <summary>
    /// Label String Reader
    /// </summary>
    public class LabelStringReader
    {
        #region Fields

        /// <summary></summary>
        private readonly string _input;

        /// <summary></summary>
        private int _curentIndex;

        #endregion

        #region Properties

        /// <summary></summary>
        public bool CanSeek => _curentIndex <= _input.Length - 1;

        /// <summary></summary>
        public int CurentIndex => _curentIndex;

        /// <summary></summary>
        public int Length => _input.Length;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public LabelStringReader(string input)
        {
            _input = input;

            _curentIndex = 0;
        }

        #endregion

        #region Methods

        public string ReadUntil(char symbol)
        {
            int symbolIndex = _input.AsSpan(_curentIndex).IndexOf(symbol);

            if (symbolIndex == -1)
            {
                throw new LabelParseException(LabelParseErrorType.SymbolNotFound, $"Symbol '{symbol}' not found.");
            }

            string value = _input.Substring(_curentIndex, symbolIndex);

            _curentIndex += symbolIndex + 1;

            return value;
        }

        public string ReadUntil(string symbol)
        {
            int symbolIndex = _input.AsSpan(_curentIndex).IndexOf(symbol);

            if (symbolIndex == -1)
            {
                throw new LabelParseException(LabelParseErrorType.SymbolNotFound, $"Symbol '{symbol}' not found.");
            }

            string value = _input.Substring(_curentIndex, symbolIndex);

            _curentIndex += symbolIndex + symbol.Length;

            return value;
        }

        public string ReadToEnd()
        {
            string value = _input.Substring(_curentIndex);

            _curentIndex += _input.Length - 1;

            return value;
        }

        public void Seek(int index)
        {
            _curentIndex = index;
        }

        public void SeekAfter(char symbol)
        {
            int symbolIndex = _input.AsSpan(_curentIndex).IndexOf(symbol);

            if (symbolIndex == -1)
            {
                throw new LabelParseException(LabelParseErrorType.SymbolNotFound, $"Symbol '{symbol}' not found.");
            }

            _curentIndex += symbolIndex + 1;
        }

        public void SeekAfter(string symbol)
        {
            int symbolIndex = _input.AsSpan(_curentIndex).IndexOf(symbol);

            if (symbolIndex == -1)
            {
                throw new LabelParseException(LabelParseErrorType.SymbolNotFound, $"Symbol '{symbol}' not found.");
            }

            _curentIndex += symbolIndex + symbol.Length;
        }

        #endregion
    }
}
