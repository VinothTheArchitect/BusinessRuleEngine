using EventProcessor.Contract.Data;
using EventProcessor.Contract.Events;
using EventProcessor.Logic;
using EventProcessor.Logic.Agent;
using EventProcessor.Logic.Membership;
using EventProcessor.Logic.PackingSlip;
using EventProcessor.Logic.Product;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventProcessor.Unit.Tests
{
    public class VideoPaymentObserverTests
    {
        private readonly IPackingSlipManager _packingSlipManager = Substitute.For<IPackingSlipManager>();
        private readonly IProductManager _productManager = Substitute.For<IProductManager>();
        private readonly VideoPaymentObserver _videoPaymentObserver;

        public VideoPaymentObserverTests()
        {
            _videoPaymentObserver = new VideoPaymentObserver(_packingSlipManager, _productManager);
        }

        [Fact]
        public async Task PaymentReceived_VideoPackingSlipGenerated()
        {
            _productManager.GetProduct(Arg.Any<int>()).Returns(new ProductInfo());
            _packingSlipManager.Generate(Arg.Any<PackingSlipInfo>()).Returns(Task.CompletedTask);

            await _videoPaymentObserver.OnPaymentReceived(new VideoPaymentReceivedEvent());

            await _productManager.Received().GetProduct(Arg.Any<int>());
            await _packingSlipManager.Received().Generate(Arg.Any<PackingSlipInfo>());
        }
    }
}
