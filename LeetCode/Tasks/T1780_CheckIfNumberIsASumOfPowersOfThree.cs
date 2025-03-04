namespace LeetCode.Tasks;

public class T1780_CheckIfNumberIsASumOfPowersOfThree
{
    public bool CheckPowersOfThree(int n)
    {
        while(n>0)
        {
            if(n % 3 == 2)
                return false;
                
            n/=3;
        }

        return true;
    }
}