using EventProcessor.Contract.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic.Agent
{
    public interface IAgentManager
    {
        Task ProcessCommission(AgentInfo agentInfo, double commissionAmount);
    }
}
