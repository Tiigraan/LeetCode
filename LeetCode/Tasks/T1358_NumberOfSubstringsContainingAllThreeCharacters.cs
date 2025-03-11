namespace LeetCode.Tasks;

public class T1358_NumberOfSubstringsContainingAllThreeCharacters
{
    // acbbcac
    // acb | acbb | acbbc | acbbca | acbbcac | 5
    // cbbca | cbbcac | 2
    // bbca | bbcac | 2
    // bca | bcac | 2
    public int NumberOfSubstrings(string s)
    {
        var result = 0;
        int[] lastIndex = [-1, -1, -1];
        
        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];
            lastIndex[letter - 'a'] = i;
            
            if (lastIndex[0] == -1 || lastIndex[1]  == -1 || lastIndex[2] == -1)
                continue;
        
            var lastMin = Math.Min(lastIndex[0], Math.Min(lastIndex[1], lastIndex[2]));
            result += 1 + lastMin;
        }
        
        return result;
    }
}