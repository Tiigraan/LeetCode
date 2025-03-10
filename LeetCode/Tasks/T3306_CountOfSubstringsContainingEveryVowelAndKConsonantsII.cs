namespace LeetCode.Tasks;

public class T3306_CountOfSubstringsContainingEveryVowelAndKConsonantsII
{
    public long CountOfSubstrings(string word, int k)
        => AtLeastK(word, k) - AtLeastK(word, k + 1);
    
    private long AtLeastK(string word, int k)
    {
        long validSubstringCount = 0;
        var startIndex = 0;
        var endIndex = 0;
        var consonantCount = 0;
        var vowelCounts = new Dictionary<char, int>();

        while (endIndex < word.Length)
        {
            var letter = word[endIndex];

            if (IsVowel(letter))
                vowelCounts[letter] = vowelCounts.GetValueOrDefault(letter) + 1;
            else
                consonantCount++;

            while (vowelCounts.Count == 5 && consonantCount >= k)
            {
                validSubstringCount += word.Length - endIndex;
                var startLetter = word[startIndex];
                if (IsVowel(startLetter))
                {
                    vowelCounts[startLetter] -= 1;
                    if (vowelCounts[startLetter] == 0)
                        vowelCounts.Remove(startLetter);
                }
                else
                    consonantCount--;

                startIndex++;
            }

            endIndex++;
        }
        
        return validSubstringCount;
    }

    private static bool IsVowel(char value)
        => value is 'a' or 'e' or 'i' or 'o' or 'u';
}