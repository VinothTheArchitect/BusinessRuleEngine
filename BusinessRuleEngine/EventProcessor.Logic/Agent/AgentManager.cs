using EventProcessor.Contract.Data;
using System.Threading.Tasks;

namespace EventProcessor.Logic.Agent
{
    public class AgentManager : IAgentManager
    {
        public Task ProcessCommission(AgentInfo agentInfo, double commissionAmount)
        {
            //Commission Logic goes here
            return Task.CompletedTask;
        }
    }
}
