using EventProcessor.Contract.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic.PackingSlip
{
    public interface IPackingSlipManager
    {
        Task Generate(PackingSlipInfo packingSlipInfo);
        Task GenerateForRoyaltyDepartment(PackingSlipInfo packingSlipInfo);
    }
}
