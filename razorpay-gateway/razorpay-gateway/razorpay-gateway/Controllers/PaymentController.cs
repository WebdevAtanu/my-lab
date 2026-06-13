using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Razorpay.Api;
using System.Text;

namespace razorpay_gateway.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public class PaymentRequest
        {
            public int PaymentAmount { get; set; }
        }

        public class VerifyPaymentRequest
        {
            public string? razorpay_payment_id { get; set; }
            public string? razorpay_order_id { get; set; }
            public string? razorpay_signature { get; set; }
        }

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("create-order")]
        public IActionResult CreateOrder(PaymentRequest paymentRequest)
        {
            var key = _configuration["Razorpay:Key"];
            var secret = _configuration["Razorpay:Secret"];

            RazorpayClient razorpayClient = new RazorpayClient(key, secret);

            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", paymentRequest.PaymentAmount * 100); // amount in paise
            options.Add("currency", "INR");
            options.Add("receipt", "order_rcptid_11");

            Order order = razorpayClient.Order.Create(options);

            return Ok(new
            {
                id = order["id"].ToString(),
                amount = order["amount"],
                currency = order["currency"]
            });
        }

        [HttpPost("verify")]
        public IActionResult VerifyPayment([FromBody] VerifyPaymentRequest data)
        {
            string? key = _configuration["Razorpay:Key"];
            string secret = _configuration["Razorpay:Secret"] ?? "";

            string paymentId = data.razorpay_payment_id ?? "";
            string orderId = data.razorpay_order_id ?? "";
            string signature = data.razorpay_signature ?? "";

            string generatedSignature = "";

            using (var hmac = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(secret)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(orderId + "|" + paymentId));
                generatedSignature = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }

            string message = "Payment Verified";

            if (generatedSignature == signature)
            {
                return Ok(new
                {
                    message,
                    paymentId,
                    orderId,
                    signature
                });
            }

            return BadRequest("Invalid Signature");
        }
    }
}
