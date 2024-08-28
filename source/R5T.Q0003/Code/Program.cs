using System;
using System.Threading.Tasks;


namespace R5T.Q0003.Code
{
    public class Program
    {
        public static async Task Main()
        {
            //await Instances.Explorations.FirstCommand();
            //await Instances.Explorations.SecondCommand();
            //await Instances.Explorations.Command03();
            //await Instances.Explorations.Command04();
            //await Instances.Explorations.Command05();
            await Raw.Explorations.Instance.N_001();
        }
    }
}
