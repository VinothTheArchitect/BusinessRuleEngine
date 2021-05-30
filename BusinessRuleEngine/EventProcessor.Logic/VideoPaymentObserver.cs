using EventProcessor.Contract.Data;
using EventProcessor.Contract.Events;
using EventProcessor.Logic.Observable;
using EventProcessor.Logic.PackingSlip;
using EventProcessor.Logic.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventProcessor.Logic
{
    public class VideoPaymentObserver : IPaymentReceivedEventObserver
    {
        private readonly IPackingSlipManager _packingSlipManager;
        private readonly IProductManager _productManager;
        private readonly string LearningToSkiVideoName = "Learning to Ski";
        private readonly int FirstAidVideoId = 22;

        public VideoPaymentObserver(IPackingSlipManager packingSlipManager,IProductManager productManager)
        {
            _packingSlipManager = packingSlipManager;
            _productManager = productManager;
        }
        public async Task OnPaymentReceived(IPaymentReceivedEvent paymentEvent)
        {

            if (!(paymentEvent is VideoPaymentReceivedEvent videoPaymentEvent))
            {
                return;
            }

            var productInfo = await _productManager.GetProduct(videoPaymentEvent.ProductId);

            if (productInfo != null)
            {

                var packingSlipInfo = new PackingSlipInfo { CustomerId = videoPaymentEvent.CustomerId, ProductId = videoPaymentEvent.ProductId };

                if (!String.IsNullOrEmpty(productInfo.ProductName) && productInfo.ProductName.Equals(LearningToSkiVideoName, StringComparison.InvariantCultureIgnoreCase))
                {
                    packingSlipInfo.ComplimentaryProductId = FirstAidVideoId;
                }

                await _packingSlipManager.Generate(packingSlipInfo);
            }
        }
    }
}
