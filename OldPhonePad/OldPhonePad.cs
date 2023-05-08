using System.Text;

namespace IronSW;

public class OldPhonePadTranslator
{
    private static readonly Dictionary<char, string> OLDPAD_MAP = new Dictionary<char, string>() {
        {'1', "&'("},
        {'2', "ABC"},
        {'3', "DEF"},
        {'4', "GHI"},
        {'5', "JKL"},
        {'6', "MNO"},
        {'7', "PQRS"},
        {'8', "TUV"},
        {'9', "WXYZ"},
        {'0', " "}
    };

    public static string OldPhonePad(string input)
    {
        StringBuilder output = new StringBuilder();
        char prevChar = ' ';
        int consecutiveCount = 0;

        foreach (char c in input)
        {
            if (c == '#')
            {
                break;
            }
            else if (c == '*')
            {
                if (output.Length > 0)
                {
                    output.Remove(output.Length - 1, 1);
                    prevChar = ' ';
                }
            }
            else if (c == ' ')
            {
                prevChar = ' ';
            }
            else
            {
                if (c == prevChar)
                {
                    if (consecutiveCount == OLDPAD_MAP[c].Length)
                    {
                        consecutiveCount = 0;
                    }

                    output.Remove(output.Length - 1, 1);
                    output.Append(OLDPAD_MAP[c][consecutiveCount]);
                    consecutiveCount++;
                }
                else
                {
                    output.Append(OLDPAD_MAP[c][0]);
                    prevChar = c;
                    consecutiveCount = 1;
                }
            }
        }

        return output.ToString();
    }
}
