using Semifinals.Apim.Policies;

namespace Semifinals.Apim.CLI.Models
{
    public class Trigger
    {
        public string Name { get; set; }
        
        public Policy Policy { get; set; }

        public Trigger(string name, Policy policy)
        {
            Name = name;
            Policy = policy;
        }
    }
}
