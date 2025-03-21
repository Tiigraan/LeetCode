namespace LeetCode.Tasks;

public class T2115_FindAllPossibleRecipesFromGivenSupplies
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        var result = new HashSet<string>();
        var suppliesHash = supplies.ToHashSet();
        var resultCount = -1;
        
        while (resultCount != result.Count)
        {
            resultCount = result.Count;
            for (var i = 0; i < recipes.Length; i++)
            {
                if (result.Contains(recipes[i]))
                    continue;


                var canCooked = ingredients[i]
                    .All(x => suppliesHash.Contains(x));

                if (canCooked)
                {
                    result.Add(recipes[i]);
                    suppliesHash.Add(recipes[i]);
                }
            }
        }

        return result.ToList();
    }
}