using System;
using System.Text;

namespace Utilities
{
    public static class StringEx
    {
        public static string HankakuToZenkaku(this string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length == 0) return string.Empty;

            var sb = new StringBuilder();
            var i = 0;
            var last = value.Length - 1;
            while (i < last)
            {
                char merged;
                if (TryMerge(value[i], value[i + 1], out merged))
                {
                    sb.Append(merged);
                    i += 2;
                }
                else
                {
                    sb.Append(HankakuToZenkaku(value[i]));
                    i += 1;
                }
            }
            if (i == last)
            {
                sb.Append(HankakuToZenkaku(value[i]));
            }
            return sb.ToString();
        }

        public static string ZenkakuToHankaku(this string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length == 0) return string.Empty;

            var sb = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                var pair = ZenkakuToHankaku(value[i]);
                sb.Append(pair.First);
                if (pair.Second != default(char)) sb.Append(pair.Second);
            }
            return sb.ToString();
        }

        public static string HankakuEisuuToZenkakuEisuu(this string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length == 0) return string.Empty;

            var sb = new StringBuilder(value.Length);
            for (var i = 0; i < value.Length; i++)
            {
                sb.Append(HankakuEisuuToZenkakuEisuu(value[i]));
            }
            return sb.ToString();
        }

        public static string ZenkakuEisuuToHankakuEisuu(this string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length == 0) return string.Empty;

            var sb = new StringBuilder(value.Length);
            for (var i = 0; i < value.Length; i++)
            {
                sb.Append(ZenkakuEisuuToHankakuEisuu(value[i]));
            }
            return sb.ToString();
        }

        public static string HankakuKanaToZenkakuKana(this string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length == 0) return string.Empty;

            var sb = new StringBuilder();
            var i = 0;
            var last = value.Length - 1;
            while (i < last)
            {
                char merged;
                if (TryMerge(value[i], value[i + 1], out merged))
                {
                    sb.Append(merged);
                    i += 2;
                }
                else
                {
                    sb.Append(HankakuKanaToZenkakuKana(value[i]));
                    i += 1;
                }
            }
            if (i == last)
            {
                sb.Append(HankakuKanaToZenkakuKana(value[i]));
            }
            return sb.ToString();
        }

        public static string ZenkakuKanaToHankakuKana(this string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (value.Length == 0) return string.Empty;

            var sb = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                var pair = ZenkakuKanaToHankakuKana(value[i]);
                sb.Append(pair.First);
                if (pair.Second != default(char)) sb.Append(pair.Second);
            }
            return sb.ToString();
        }

        private static char HankakuToZenkaku(char value)
        {
            var result = HankakuEisuuToZenkakuEisuu(value);
            return HankakuKanaToZenkakuKana(result);
        }

        private static CharPair ZenkakuToHankaku(char value)
        {
            var result = ZenkakuEisuuToHankakuEisuu(value);
            return ZenkakuKanaToHankakuKana(result);
        }

        private static char HankakuEisuuToZenkakuEisuu(char value)
        {
            switch (value)
            {
                case ' ': return '　';
                case '!': return '！';
                case '"': return '”';
                case '#': return '＃';
                case '$': return '＄';
                case '%': return '％';
                case '&': return '＆';
                case '\'': return '’';
                case '(': return '（';
                case ')': return '）';
                case '*': return '＊';
                case '+': return '＋';
                case ',': return '，';
                case '-': return '－';
                case '.': return '．';
                case '/': return '／';
                case '0': return '０';
                case '1': return '１';
                case '2': return '２';
                case '3': return '３';
                case '4': return '４';
                case '5': return '５';
                case '6': return '６';
                case '7': return '７';
                case '8': return '８';
                case '9': return '９';
                case ':': return '：';
                case ';': return '；';
                case '<': return '＜';
                case '=': return '＝';
                case '>': return '＞';
                case '?': return '？';
                case '@': return '＠';
                case 'A': return 'Ａ';
                case 'B': return 'Ｂ';
                case 'C': return 'Ｃ';
                case 'D': return 'Ｄ';
                case 'E': return 'Ｅ';
                case 'F': return 'Ｆ';
                case 'G': return 'Ｇ';
                case 'H': return 'Ｈ';
                case 'I': return 'Ｉ';
                case 'J': return 'Ｊ';
                case 'K': return 'Ｋ';
                case 'L': return 'Ｌ';
                case 'M': return 'Ｍ';
                case 'N': return 'Ｎ';
                case 'O': return 'Ｏ';
                case 'P': return 'Ｐ';
                case 'Q': return 'Ｑ';
                case 'R': return 'Ｒ';
                case 'S': return 'Ｓ';
                case 'T': return 'Ｔ';
                case 'U': return 'Ｕ';
                case 'V': return 'Ｖ';
                case 'W': return 'Ｗ';
                case 'X': return 'Ｘ';
                case 'Y': return 'Ｙ';
                case 'Z': return 'Ｚ';
                case '[': return '［';
                case '\\': return '￥';
                case ']': return '］';
                case '^': return '＾';
                case '_': return '＿';
                case '`': return '‘';
                case 'a': return 'ａ';
                case 'b': return 'ｂ';
                case 'c': return 'ｃ';
                case 'd': return 'ｄ';
                case 'e': return 'ｅ';
                case 'f': return 'ｆ';
                case 'g': return 'ｇ';
                case 'h': return 'ｈ';
                case 'i': return 'ｉ';
                case 'j': return 'ｊ';
                case 'k': return 'ｋ';
                case 'l': return 'ｌ';
                case 'm': return 'ｍ';
                case 'n': return 'ｎ';
                case 'o': return 'ｏ';
                case 'p': return 'ｐ';
                case 'q': return 'ｑ';
                case 'r': return 'ｒ';
                case 's': return 'ｓ';
                case 't': return 'ｔ';
                case 'u': return 'ｕ';
                case 'v': return 'ｖ';
                case 'w': return 'ｗ';
                case 'x': return 'ｘ';
                case 'y': return 'ｙ';
                case 'z': return 'ｚ';
                case '{': return '｛';
                case '|': return '｜';
                case '}': return '｝';
                case '~': return '～';
                default: return value;
            }
        }

        private static char ZenkakuEisuuToHankakuEisuu(char value)
        {
            switch (value)
            {
                case '‘': return '\'';
                case '’': return '\'';
                case '“': return '"';
                case '”': return '"';
                case '　': return ' ';
                case '！': return '!';
                case '＃': return '#';
                case '＄': return '$';
                case '％': return '%';
                case '＆': return '&';
                case '（': return '(';
                case '）': return ')';
                case '＊': return '*';
                case '＋': return '+';
                case '，': return ',';
                case '－': return '-';
                case '．': return '.';
                case '／': return '/';
                case '０': return '0';
                case '１': return '1';
                case '２': return '2';
                case '３': return '3';
                case '４': return '4';
                case '５': return '5';
                case '６': return '6';
                case '７': return '7';
                case '８': return '8';
                case '９': return '9';
                case '：': return ':';
                case '；': return ';';
                case '＜': return '<';
                case '＝': return '=';
                case '＞': return '>';
                case '？': return '?';
                case '＠': return '@';
                case 'Ａ': return 'A';
                case 'Ｂ': return 'B';
                case 'Ｃ': return 'C';
                case 'Ｄ': return 'D';
                case 'Ｅ': return 'E';
                case 'Ｆ': return 'F';
                case 'Ｇ': return 'G';
                case 'Ｈ': return 'H';
                case 'Ｉ': return 'I';
                case 'Ｊ': return 'J';
                case 'Ｋ': return 'K';
                case 'Ｌ': return 'L';
                case 'Ｍ': return 'M';
                case 'Ｎ': return 'N';
                case 'Ｏ': return 'O';
                case 'Ｐ': return 'P';
                case 'Ｑ': return 'Q';
                case 'Ｒ': return 'R';
                case 'Ｓ': return 'S';
                case 'Ｔ': return 'T';
                case 'Ｕ': return 'U';
                case 'Ｖ': return 'V';
                case 'Ｗ': return 'W';
                case 'Ｘ': return 'X';
                case 'Ｙ': return 'Y';
                case 'Ｚ': return 'Z';
                case '［': return '[';
                case '＼': return '\\';
                case '］': return ']';
                case '＾': return '^';
                case '＿': return '_';
                case '｀': return '`';
                case 'ａ': return 'a';
                case 'ｂ': return 'b';
                case 'ｃ': return 'c';
                case 'ｄ': return 'd';
                case 'ｅ': return 'e';
                case 'ｆ': return 'f';
                case 'ｇ': return 'g';
                case 'ｈ': return 'h';
                case 'ｉ': return 'i';
                case 'ｊ': return 'j';
                case 'ｋ': return 'k';
                case 'ｌ': return 'l';
                case 'ｍ': return 'm';
                case 'ｎ': return 'n';
                case 'ｏ': return 'o';
                case 'ｐ': return 'p';
                case 'ｑ': return 'q';
                case 'ｒ': return 'r';
                case 'ｓ': return 's';
                case 'ｔ': return 't';
                case 'ｕ': return 'u';
                case 'ｖ': return 'v';
                case 'ｗ': return 'w';
                case 'ｘ': return 'x';
                case 'ｙ': return 'y';
                case 'ｚ': return 'z';
                case '｛': return '{';
                case '｜': return '|';
                case '｝': return '}';
                case '～': return '~';
                default: return value;
            }
        }

        private static bool TryMerge(char first, char second, out char result)
        {
            switch (second)
            {
                case 'ﾞ':
                    switch (first)
                    {
                        case 'ｳ': result = 'ヴ'; return true;
                        case 'ｶ': result = 'ガ'; return true;
                        case 'ｷ': result = 'ギ'; return true;
                        case 'ｸ': result = 'グ'; return true;
                        case 'ｹ': result = 'ゲ'; return true;
                        case 'ｺ': result = 'ゴ'; return true;
                        case 'ｻ': result = 'ザ'; return true;
                        case 'ｼ': result = 'ジ'; return true;
                        case 'ｽ': result = 'ズ'; return true;
                        case 'ｾ': result = 'ゼ'; return true;
                        case 'ｿ': result = 'ゾ'; return true;
                        case 'ﾀ': result = 'ダ'; return true;
                        case 'ﾁ': result = 'ヂ'; return true;
                        case 'ﾂ': result = 'ヅ'; return true;
                        case 'ﾃ': result = 'デ'; return true;
                        case 'ﾄ': result = 'ド'; return true;
                        case 'ﾊ': result = 'バ'; return true;
                        case 'ﾋ': result = 'ビ'; return true;
                        case 'ﾌ': result = 'ブ'; return true;
                        case 'ﾍ': result = 'ベ'; return true;
                        case 'ﾎ': result = 'ボ'; return true;
                        default: result = default(char); return false;
                    }
                case 'ﾟ':
                    switch (first)
                    {
                        case 'ﾊ': result = 'パ'; return true;
                        case 'ﾋ': result = 'ピ'; return true;
                        case 'ﾌ': result = 'プ'; return true;
                        case 'ﾍ': result = 'ペ'; return true;
                        case 'ﾎ': result = 'ポ'; return true;
                        default: result = default(char); return false;
                    }
                default:
                    result = default(char); return false;
            }
        }

        private static char HankakuKanaToZenkakuKana(char value)
        {
            switch (value)
            {
                case '｡': return '。';
                case '｢': return '「';
                case '｣': return '」';
                case '､': return '、';
                case '･': return '・';
                case 'ｦ': return 'ヲ';
                case 'ｧ': return 'ァ';
                case 'ｨ': return 'ィ';
                case 'ｩ': return 'ゥ';
                case 'ｪ': return 'ェ';
                case 'ｫ': return 'ォ';
                case 'ｬ': return 'ャ';
                case 'ｭ': return 'ュ';
                case 'ｮ': return 'ョ';
                case 'ｯ': return 'ッ';
                case 'ｰ': return 'ー';
                case 'ｱ': return 'ア';
                case 'ｲ': return 'イ';
                case 'ｳ': return 'ウ';
                case 'ｴ': return 'エ';
                case 'ｵ': return 'オ';
                case 'ｶ': return 'カ';
                case 'ｷ': return 'キ';
                case 'ｸ': return 'ク';
                case 'ｹ': return 'ケ';
                case 'ｺ': return 'コ';
                case 'ｻ': return 'サ';
                case 'ｼ': return 'シ';
                case 'ｽ': return 'ス';
                case 'ｾ': return 'セ';
                case 'ｿ': return 'ソ';
                case 'ﾀ': return 'タ';
                case 'ﾁ': return 'チ';
                case 'ﾂ': return 'ツ';
                case 'ﾃ': return 'テ';
                case 'ﾄ': return 'ト';
                case 'ﾅ': return 'ナ';
                case 'ﾆ': return 'ニ';
                case 'ﾇ': return 'ヌ';
                case 'ﾈ': return 'ネ';
                case 'ﾉ': return 'ノ';
                case 'ﾊ': return 'ハ';
                case 'ﾋ': return 'ヒ';
                case 'ﾌ': return 'フ';
                case 'ﾍ': return 'ヘ';
                case 'ﾎ': return 'ホ';
                case 'ﾏ': return 'マ';
                case 'ﾐ': return 'ミ';
                case 'ﾑ': return 'ム';
                case 'ﾒ': return 'メ';
                case 'ﾓ': return 'モ';
                case 'ﾔ': return 'ヤ';
                case 'ﾕ': return 'ユ';
                case 'ﾖ': return 'ヨ';
                case 'ﾗ': return 'ラ';
                case 'ﾘ': return 'リ';
                case 'ﾙ': return 'ル';
                case 'ﾚ': return 'レ';
                case 'ﾛ': return 'ロ';
                case 'ﾜ': return 'ワ';
                case 'ﾝ': return 'ン';
                case 'ﾞ': return '゛';
                case 'ﾟ': return '゜';
                default: return value;
            }
        }

        private static CharPair ZenkakuKanaToHankakuKana(char value)
        {
            switch (value)
            {
                case 'ァ': return new CharPair('ｧ');
                case 'ア': return new CharPair('ｱ');
                case 'ィ': return new CharPair('ｨ');
                case 'イ': return new CharPair('ｲ');
                case 'ゥ': return new CharPair('ｩ');
                case 'ウ': return new CharPair('ｳ');
                case 'ェ': return new CharPair('ｪ');
                case 'エ': return new CharPair('ｴ');
                case 'ォ': return new CharPair('ｫ');
                case 'オ': return new CharPair('ｵ');
                case 'カ': return new CharPair('ｶ');
                case 'ガ': return new CharPair('ｶ', 'ﾞ');
                case 'キ': return new CharPair('ｷ');
                case 'ギ': return new CharPair('ｷ', 'ﾞ');
                case 'ク': return new CharPair('ｸ');
                case 'グ': return new CharPair('ｸ', 'ﾞ');
                case 'ケ': return new CharPair('ｹ');
                case 'ゲ': return new CharPair('ｹ', 'ﾞ');
                case 'コ': return new CharPair('ｺ');
                case 'ゴ': return new CharPair('ｺ', 'ﾞ');
                case 'サ': return new CharPair('ｻ');
                case 'ザ': return new CharPair('ｻ', 'ﾞ');
                case 'シ': return new CharPair('ｼ');
                case 'ジ': return new CharPair('ｼ', 'ﾞ');
                case 'ス': return new CharPair('ｽ');
                case 'ズ': return new CharPair('ｽ', 'ﾞ');
                case 'セ': return new CharPair('ｾ');
                case 'ゼ': return new CharPair('ｾ', 'ﾞ');
                case 'ソ': return new CharPair('ｿ');
                case 'ゾ': return new CharPair('ｿ', 'ﾞ');
                case 'タ': return new CharPair('ﾀ');
                case 'ダ': return new CharPair('ﾀ', 'ﾞ');
                case 'チ': return new CharPair('ﾁ');
                case 'ヂ': return new CharPair('ﾁ', 'ﾞ');
                case 'ッ': return new CharPair('ｯ');
                case 'ツ': return new CharPair('ﾂ');
                case 'ヅ': return new CharPair('ﾂ', 'ﾞ');
                case 'テ': return new CharPair('ﾃ');
                case 'デ': return new CharPair('ﾃ', 'ﾞ');
                case 'ト': return new CharPair('ﾄ');
                case 'ド': return new CharPair('ﾄ', 'ﾞ');
                case 'ナ': return new CharPair('ﾅ');
                case 'ニ': return new CharPair('ﾆ');
                case 'ヌ': return new CharPair('ﾇ');
                case 'ネ': return new CharPair('ﾈ');
                case 'ノ': return new CharPair('ﾉ');
                case 'ハ': return new CharPair('ﾊ');
                case 'バ': return new CharPair('ﾊ', 'ﾞ');
                case 'パ': return new CharPair('ﾊ', 'ﾟ');
                case 'ヒ': return new CharPair('ﾋ');
                case 'ビ': return new CharPair('ﾋ', 'ﾞ');
                case 'ピ': return new CharPair('ﾋ', 'ﾟ');
                case 'フ': return new CharPair('ﾌ');
                case 'ブ': return new CharPair('ﾌ', 'ﾞ');
                case 'プ': return new CharPair('ﾌ', 'ﾟ');
                case 'ヘ': return new CharPair('ﾍ');
                case 'ベ': return new CharPair('ﾍ', 'ﾞ');
                case 'ペ': return new CharPair('ﾍ', 'ﾟ');
                case 'ホ': return new CharPair('ﾎ');
                case 'ボ': return new CharPair('ﾎ', 'ﾞ');
                case 'ポ': return new CharPair('ﾎ', 'ﾟ');
                case 'マ': return new CharPair('ﾏ');
                case 'ミ': return new CharPair('ﾐ');
                case 'ム': return new CharPair('ﾑ');
                case 'メ': return new CharPair('ﾒ');
                case 'モ': return new CharPair('ﾓ');
                case 'ャ': return new CharPair('ｬ');
                case 'ヤ': return new CharPair('ﾔ');
                case 'ュ': return new CharPair('ｭ');
                case 'ユ': return new CharPair('ﾕ');
                case 'ョ': return new CharPair('ｮ');
                case 'ヨ': return new CharPair('ﾖ');
                case 'ラ': return new CharPair('ﾗ');
                case 'リ': return new CharPair('ﾘ');
                case 'ル': return new CharPair('ﾙ');
                case 'レ': return new CharPair('ﾚ');
                case 'ロ': return new CharPair('ﾛ');
                case 'ワ': return new CharPair('ﾜ');
                case 'ヲ': return new CharPair('ｦ');
                case 'ン': return new CharPair('ﾝ');
                case 'ヴ': return new CharPair('ｳ', 'ﾞ');
                default: return new CharPair(value);
            }
        }

        private struct CharPair
        {
            private readonly char first;
            private readonly char second;

            public CharPair(char first)
            {
                this.first = first;
                second = default(char);
            }

            public CharPair(char first, char second)
            {
                this.first = first;
                this.second = second;
            }

            public char First
            {
                get
                {
                    return first;
                }
            }

            public char Second
            {
                get
                {
                    return second;
                }
            }
        }
    }
}
