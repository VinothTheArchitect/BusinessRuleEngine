using EventProcessor.Contract.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic.PackingSlip
{
    public class PackingSlipManager : IPackingSlipManager
    {
        public Task Generate(PackingSlipInfo packingSlipInfo)
        {
            //Generate Packing Slip logic goes here
            return Task.CompletedTask;
        }

        public Task GenerateForRoyaltyDepartment(PackingSlipInfo packingSlipInfo)
        {
            //Generate Packing Slip for Royalty Department logic goes here
            return Task.CompletedTask;
        }
     
    }
}
